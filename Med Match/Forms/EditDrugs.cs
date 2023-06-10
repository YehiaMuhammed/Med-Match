using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Med_Match.Forms
{
    public partial class EditDrugs : UserControl
    {
        IMongoCollection<BsonDocument> collection;
        private int savedSelectionStart;
        private string drugId;
        public EditDrugs()
        {
            InitializeComponent();
            var connectionString = "mongodb+srv://admin:cdoGLvJ6bxxneHQn@cluster0.a0hbnon.mongodb.net";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Project");
            collection = database.GetCollection<BsonDocument>("drugs");
        }

        private void cbDrugs_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Wait for the timer to elapse
            await System.Threading.Tasks.Task.Delay(timer1.Interval);

            // Retrieve the entered drug name
            var drugName = cbDrugs.Text.Trim();

            if (!string.IsNullOrEmpty(drugName))
            {

                // Perform a search in the drugs collection
                var filter = Builders<BsonDocument>.Filter.Regex("name", new BsonRegularExpression($"^{drugName}", "i"));
                var similarDrugs = await collection.Find(filter).ToListAsync();

                savedSelectionStart = cbDrugs.SelectionStart;

                // Clear existing items and add similar drug names to the ComboBox
                cbDrugs.Items.Clear();
                foreach (var drug in similarDrugs)
                {
                    var similarDrugName = drug["name"].AsString;
                    var similarDrugId = drug["_id"].ToString();
                    cbDrugs.Items.Add(new KeyValuePair<string, string>(similarDrugName, similarDrugId));
                }
                cbDrugs.DisplayMember = "Key";
                cbDrugs.ValueMember = "Value";

                cbDrugs.SelectionStart = savedSelectionStart;
            }
        }



        private void cbDrugs_Enter(object sender, EventArgs e)
        {
            if (cbDrugs.Text == "Drug")
            {
                cbDrugs.Text = string.Empty;
            }

        }

        private void cbDrugs_Leave(object sender, EventArgs e)
        {
            if (cbDrugs.Text == string.Empty)
            {
                cbDrugs.Text = "Drug";
            }
        }

        private void cbDrugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected drug item from the ComboBox
            var selectedDrug = cbDrugs.SelectedItem as KeyValuePair<string, string>?;

            if (selectedDrug != null)
            {
                // Find the drug document by _id in the collection
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(selectedDrug.Value.Value));
                var selectedDrugDocument = collection.Find(filter).FirstOrDefault();

                if (selectedDrugDocument != null)
                {
                    // Retrieve the drug name and ID
                    if(selectedDrugDocument.Contains("name"))
                    {
                        var drugName = selectedDrugDocument["name"].AsString;
                        Drugname_txt.Text = drugName.ToString();
                    }
                    if(selectedDrugDocument.Contains("price"))
                    {
                        var drugPrice = selectedDrugDocument["price"];
                        drugPrice_txt.Text = drugPrice.ToString();
                    }
                    if(selectedDrugDocument.Contains("activeIngredient"))
                    {
                        var drugActiveIngredient = selectedDrugDocument["activeIngredient"].AsString;
                        activeIngredient_txt.Text = drugActiveIngredient;
                    }
                    if (selectedDrugDocument.Contains("category"))
                    {
                        var drugCat = selectedDrugDocument["category"].AsString; ;
                        drugCat_txt.Text = drugCat;
                    }
                    drugId = selectedDrugDocument["_id"].ToString();
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {

            if (drugId != null)
            {
                // Find the drug document by _id in the collection
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(drugId));
                var selectedDrugDocument = collection.Find(filter).FirstOrDefault();

                if (selectedDrugDocument != null)
                {

                    selectedDrugDocument["name"] = Drugname_txt.Text;
                    selectedDrugDocument["price"] = drugPrice_txt.Text;
                    selectedDrugDocument["activeIngredient"] = activeIngredient_txt.Text;
                    selectedDrugDocument["category"] = drugCat_txt.Text;



                    // Replace the existing drug document with the updated document
                    collection.ReplaceOne(filter, selectedDrugDocument);

                    // Show a message indicating successful update
                    MessageBox.Show("Drug updated successfully.");
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                save_btn.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

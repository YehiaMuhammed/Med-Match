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

                // Clear existing items and add similar drug names to the ComboBox
                cbDrugs.Items.Clear();
                foreach (var drug in similarDrugs)
                {
                    var similarDrugName = drug["name"].AsString;
                    cbDrugs.Items.Add(similarDrugName);
                }
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
    }
}

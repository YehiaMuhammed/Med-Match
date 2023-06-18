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
    public partial class ShowDrugs : UserControl
    {
        IMongoCollection<BsonDocument> collection;
        public ShowDrugs()
        {
            InitializeComponent();
            var connectionString = "mongodb+srv://admin:cdoGLvJ6bxxneHQn@cluster0.a0hbnon.mongodb.net";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Project");
            collection = database.GetCollection<BsonDocument>("drugs");
        }

        private void Drugname_txt_Enter(object sender, EventArgs e)
        {
            if (Drugname_txt.Text == "Enter drug name...")
            {
                Drugname_txt.Text = string.Empty;
                Drugname_txt.ForeColor = Color.Black;
            }
        }

        private void Drugname_txt_Leave(object sender, EventArgs e)
        {
            if (Drugname_txt.Text == string.Empty)
            {
                Drugname_txt.ForeColor = Color.Gray;
                Drugname_txt.Text = "Enter drug name...";
            }
        }

        private void DrugCat_txt_Enter(object sender, EventArgs e)
        {
            if (DrugCat_txt.Text == "Enter drug category...")
            {
                DrugCat_txt.Text = string.Empty;
                DrugCat_txt.ForeColor = Color.Black;
            }
        }

        private void DrugCat_txt_Leave(object sender, EventArgs e)
        {
            if (DrugCat_txt.Text == string.Empty)
            {
                DrugCat_txt.ForeColor = Color.Gray;
                DrugCat_txt.Text = "Enter drug category...";
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Drugname_txt.Text == "Enter drug name...")
                {
                    Drugname_txt.Text = "";
                    Drugname_txt.ForeColor = Color.Black;
                }
                if (DrugCat_txt.Text == "Enter drug category...")
                {
                    DrugCat_txt.Text = "";
                    DrugCat_txt.ForeColor = Color.Black;
                }
                var drugName = Drugname_txt.Text;
                var drugCat = DrugCat_txt.Text;
                var drugNameFilter = Builders<BsonDocument>.Filter.Regex("name", new BsonRegularExpression($"^{drugName}", "i"));
                var drugCatFilter = Builders<BsonDocument>.Filter.Regex("category", new BsonRegularExpression($"^{drugCat}", "i"));
                var filter = Builders<BsonDocument>.Filter.And(drugNameFilter, drugCatFilter);
                var projection = Builders<BsonDocument>.Projection.Include("name").Include("price").Include("activeIngredient").Include("category");
                var documents = collection.Find(filter).Project(projection).ToList();
                var dataTable = new DataTable();
                if (documents.Count > 0)
                {
                    foreach (var document in documents)
                    {
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (var element in document.Elements)
                            {
                                dataTable.Columns.Add(element.Name);
                            }
                        }

                        var row = dataTable.NewRow();
                        foreach (var element in document.Elements)
                        {
                            row[element.Name] = element.Value;
                        }

                        dataTable.Rows.Add(row);
                    }
                    dataGridView1.DataSource = dataTable;
                    DataGridViewImageColumn deleteButton = new DataGridViewImageColumn();
                    Image image = Properties.Resources.remove__1_;
                    deleteButton.Image = image;
                    deleteButton.Name = "Delete";
                    deleteButton.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    int columnIndex = 5;
                    if (dataGridView1.Columns["Delete"] == null)
                    {
                        dataGridView1.Columns.Insert(columnIndex, deleteButton);

                    }
                    dataGridView1.Columns["_id"].Visible = false;
                }
                else
                {
                    MessageBox.Show("No Matching Drugs Found!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                search_btn.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                {
                    var documentId = dataGridView1.Rows[e.RowIndex].Cells["_Id"].Value.ToString();
                    var drugName = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(documentId));
                    DialogResult dr = MessageBox.Show("Do You Want To Delete This Drug?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        collection.DeleteOne(filter);
                        MessageBox.Show(drugName + " Deleted Successfully");
                        search_btn.PerformClick();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ShowDrugs_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Bebas Neue",18, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("Bebas Neue", 15, FontStyle.Regular);

        }
    }
}

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
    public partial class UsersControl : UserControl
    {
        IMongoCollection<BsonDocument> collection;
        public UsersControl()
        {
            InitializeComponent();
            var connectionString = "mongodb+srv://admin:cdoGLvJ6bxxneHQn@cluster0.a0hbnon.mongodb.net";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Project");
            collection = database.GetCollection<BsonDocument>("users");
            populateGrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
        }

        private void Username_txt_Enter(object sender, EventArgs e)
        {
            if (Username_txt.Text == "Enter username...")
            {
                Username_txt.Text = string.Empty;
                Username_txt.ForeColor = Color.Black;
            }
        }

        private void email_txt_Enter(object sender, EventArgs e)
        {
            if (email_txt.Text == "Enter email...")
            {
                email_txt.Text = string.Empty;
                email_txt.ForeColor = Color.Black;
            }
        }

        private void Username_txt_Leave(object sender, EventArgs e)
        {
            if (Username_txt.Text == string.Empty)
            {
                Username_txt.ForeColor = Color.Gray;
                Username_txt.Text = "Enter username...";
            }
        }

        private void email_txt_Leave(object sender, EventArgs e)
        {
            if (email_txt.Text == string.Empty)
            {
                email_txt.ForeColor = Color.Gray;
                email_txt.Text = "Enter email...";
            }
        }
     
        public void populateGrid()
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Empty;
                var projection = Builders<BsonDocument>.Projection.Include("userName").Include("email").Include("role");
                var documents = collection.Find(filter).Project(projection).ToList();
                var dataTable = new DataTable();

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
                int columnIndex = 4;
                if(dataGridView1.Columns["Delete"] == null)
                {
                    dataGridView1.Columns.Insert(columnIndex, deleteButton);

                }
                dataGridView1.Columns["userName"].HeaderText = "User Name";


                dataGridView1.Columns["_id"].Visible = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Username_txt.Text == "Enter username...")
                {
                    Username_txt.Text = "";
                    Username_txt.ForeColor = Color.Black;
                }
                if (email_txt.Text == "Enter email...")
                {
                    email_txt.Text = "";
                    email_txt.ForeColor = Color.Black;
                }
                var username = Username_txt.Text;
                var email = email_txt.Text;
                var userNameFilter = Builders<BsonDocument>.Filter.Regex("userName", new BsonRegularExpression($"^{username}", "i"));
                var emailFilter = Builders<BsonDocument>.Filter.Regex("email", new BsonRegularExpression($"^{email}", "i"));
                var filter = Builders<BsonDocument>.Filter.And(userNameFilter, emailFilter);
                var projection = Builders<BsonDocument>.Projection.Include("userName").Include("email").Include("role");
                var documents = collection.Find(filter).Project(projection).ToList();
                var dataTable = new DataTable();
                if(documents.Count > 0)
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
                    int columnIndex = 4;
                    if (dataGridView1.Columns["Delete"] == null)
                    {
                        dataGridView1.Columns.Insert(columnIndex, deleteButton);

                    }
                    dataGridView1.Columns["userName"].HeaderText = "User Name";


                    dataGridView1.Columns["_id"].Visible = false;
                }
                else
                {
                    MessageBox.Show("No Matching Users Found!");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                {
                    var documentId = dataGridView1.Rows[e.RowIndex].Cells["_Id"].Value.ToString();
                    var userName = dataGridView1.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(documentId));
                    DialogResult dr = MessageBox.Show("Do You Want To Delete This User?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        collection.DeleteOne(filter);
                        MessageBox.Show(userName + " Deleted Successfully");
                        search_btn.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void UsersControl_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Bebas Neue", 18, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("Bebas Neue", 15, FontStyle.Regular);
        }
    }
}

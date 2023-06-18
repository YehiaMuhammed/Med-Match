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
    public partial class ShowOrders : UserControl
    {
        IMongoCollection<BsonDocument> collection;
        public ShowOrders()
        {
            InitializeComponent();
            var connectionString = "mongodb+srv://admin:cdoGLvJ6bxxneHQn@cluster0.a0hbnon.mongodb.net";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Project");
            collection = database.GetCollection<BsonDocument>("orders");
            populateGrid();
        }

        private void populateGrid()
        {
            DateTime currentDate = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var filter = Builders<BsonDocument>.Filter.Gte("createdAt", firstDayOfMonth) & Builders<BsonDocument>.Filter.Lte("createdAt", lastDayOfMonth);
            var projection = Builders<BsonDocument>.Projection.Include("phone").Include("shippingAddress").Include("paymentMethod").Include("status").Include("totalPrice").Include("createdAt");

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
            dataGridView1.Columns["_id"].Visible = false;
        }

        private void Uphone_txt_Enter(object sender, EventArgs e)
        {
            if (Uphone_txt.Text == "User Phone number...")
            {
                Uphone_txt.Text = string.Empty;
                Uphone_txt.ForeColor = Color.Black;
            }
        }

        private void Uphone_txt_Leave(object sender, EventArgs e)
        {
            if (Uphone_txt.Text == string.Empty)
            {
                Uphone_txt.ForeColor = Color.Gray;
                Uphone_txt.Text = "User Phone number...";
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string phoneNumber = Uphone_txt.Text.Trim();
            DateTime selectedDate = dateTimePicker1.Value.Date;

            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Empty;


            if (Uphone_txt.Text == "User Phone number...")
            {
                Uphone_txt.Text = string.Empty;
                Uphone_txt.ForeColor = Color.Black;
            }
            else
            {
                filter &= filterBuilder.Eq("phone", phoneNumber);
            }

            if (selectedDate != DateTime.Now.Date)
            {
                DateTime startDate = selectedDate.Date;
                DateTime endDate = selectedDate.Date.AddDays(1).AddTicks(-1);
                filter &= filterBuilder.Gte("createdAt", startDate) & filterBuilder.Lte("createdAt", endDate);
            }
            var projection = Builders<BsonDocument>.Projection.Include("phone").Include("shippingAddress").Include("paymentMethod").Include("status").Include("totalPrice").Include("createdAt");

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
                dataGridView1.Columns["_id"].Visible = false;

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
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Bebas Neue", 18, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("Bebas Neue", 15, FontStyle.Regular);
        }

    
    }
}

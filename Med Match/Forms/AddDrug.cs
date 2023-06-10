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
    public partial class AddDrug : UserControl
    {
        IMongoCollection<BsonDocument> collection;
        public AddDrug()
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

        private void drugPrive_txt_Enter(object sender, EventArgs e)
        {
            if (drugPrive_txt.Text == "Enter price...")
            {
                drugPrive_txt.Text = string.Empty;
                drugPrive_txt.ForeColor = Color.Black;
            }
        }

        private void drugPrive_txt_Leave(object sender, EventArgs e)
        {
            if (drugPrive_txt.Text == string.Empty)
            {
                drugPrive_txt.ForeColor = Color.Gray;
                drugPrive_txt.Text = "Enter price...";
            }
        }

        private void drugCat_txt_Enter(object sender, EventArgs e)
        {
            if (drugCat_txt.Text == "Enter Category...")
            {
                drugCat_txt.Text = string.Empty;
                drugCat_txt.ForeColor = Color.Black;
            }
        }

        private void drugCat_txt_Leave(object sender, EventArgs e)
        {
            if (drugCat_txt.Text == string.Empty)
            {
                drugCat_txt.ForeColor = Color.Gray;
                drugCat_txt.Text = "Enter Category...";
            }
        }

        private void activelngredient_txt_Enter(object sender, EventArgs e)
        {
            if (activelngredient_txt.Text == "Enter activeIngredient ...")
            {
                activelngredient_txt.Text = string.Empty;
                activelngredient_txt.ForeColor = Color.Black;
            }
        }

        private void activelngredient_txt_Leave(object sender, EventArgs e)
        {
            if (activelngredient_txt.Text == string.Empty)
            {
                activelngredient_txt.ForeColor = Color.Gray;
                activelngredient_txt.Text = "Enter activeIngredient ...";
            }
        }

        private void addDrug_btn_Click(object sender, EventArgs e)
        {
            if(Drugname_txt.Text == "Enter drug name..." || drugCat_txt.Text == "Enter Category..." || drugPrive_txt.Text == "Enter price..." || activelngredient_txt.Text == "Enter activeIngredient ...")
            {
                MessageBox.Show("Please Fill Missing Info");
            }
            else
            {
                string drugName = Drugname_txt.Text;
                string drugCat = drugCat_txt.Text;
                int drugPrice = int.Parse(drugPrive_txt.Text);
                string drugActiveIngredient = activelngredient_txt.Text;

                BsonDocument newDrug = new BsonDocument
                {
                    {"name", drugName },
                    {"category", drugCat },
                    {"price", drugPrice },
                    {"activeIngredient", drugActiveIngredient },
                };

             

                collection.InsertOne(newDrug);
                MessageBox.Show("Drug Added Successfully!");
            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                addDrug_btn.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

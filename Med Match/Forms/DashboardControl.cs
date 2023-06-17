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
    public partial class DashboardControl : UserControl
    {
        IMongoCollection<BsonDocument> drugsCollection;
        IMongoCollection<BsonDocument> ordersCollection;
        IMongoCollection<BsonDocument> usersCollection;
        public DashboardControl()
        {
            InitializeComponent();
            var connectionString = "mongodb+srv://admin:cdoGLvJ6bxxneHQn@cluster0.a0hbnon.mongodb.net";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Project");
            drugsCollection = database.GetCollection<BsonDocument>("drugs");
            ordersCollection = database.GetCollection<BsonDocument>("orders");
            usersCollection = database.GetCollection<BsonDocument>("users");
            var countDrugs = drugsCollection.CountDocuments(FilterDefinition<BsonDocument>.Empty);
            label6.Text = countDrugs.ToString();
            var countOrders = ordersCollection.CountDocuments(FilterDefinition<BsonDocument>.Empty);
            label3.Text = countOrders.ToString();
            var countUsers = usersCollection.CountDocuments(FilterDefinition<BsonDocument>.Empty);
            label4.Text = countUsers.ToString();

            var filter = Builders<BsonDocument>.Filter.Empty;
            var orders = ordersCollection.Find(filter).ToList();
            int totalPrice = 0;
            foreach (var order in orders)
            {
                totalPrice += order["totalPrice"].AsInt32;
            }
            label9.Text = totalPrice.ToString();    
            
        }
    }
    
}

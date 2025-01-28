using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesarPBO
{
    internal class MongoDBConnection
    {
        public static readonly IMongoDatabase database;

        static MongoDBConnection()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("plant_monitoring_db");
        }

        public static IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return database.GetCollection<BsonDocument>(collectionName);
        }
        public static void UpdateDocument(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            // Dapatkan koleksi yang sesuai
            var collection = GetCollection(collectionName);

            // Perbarui dokumen sesuai filter dan update yang diberikan
            var result = collection.UpdateOne(filter, update);
        }
    }
}

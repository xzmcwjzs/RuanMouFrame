using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MongoDB
{
    public class GetMongoDB
    {
        public IMongoDatabase GetDB()
        {
            string connStr = ConfigurationManager.AppSettings["MongoServerSettings"];
            var client = new MongoClient(connStr);
            var db = client.GetDatabase(new MongoUrl(connStr).DatabaseName);
            return db;

        }
    }
}

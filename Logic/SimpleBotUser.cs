using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            var cliente = new MongoClient();
            var db = cliente.GetDatabase("Bot");
            var col = db.GetCollection<BsonDocument>("Messages");

            var doc = new BsonDocument
            {
                { "User", message.User },
                { "Message", message.Text }
            };
            col.InsertOne(doc);
            return $"{message.User}: {message.Text}";

        }

    }
}
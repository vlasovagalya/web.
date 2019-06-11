using g_mvc.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson.IO;

namespace g_mvc.Services
{
    public class RoomService
    {
        private IMongoCollection<Room> rooms;

        public RoomService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDB"));
            var db = client.GetDatabase("RoomsDB");
            rooms = db.GetCollection<Room>("Rooms");
        }

        public List<Room> Get()
        {
            return rooms.Find(book => true).ToList();
        }

        public void Create(Room room)
        {
            rooms.InsertOne(room);
        }
    }
}
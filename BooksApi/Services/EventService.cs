using System.Linq;
using WorkoutApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace WorkoutApi.Services
{
    public class EventService
    {
        private readonly IMongoCollection<Event> _events;

        public EventService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _events = database.GetCollection<Event>("Events");
        }

        public List<Event> Get()
        {
            return _events.Find(book => true).ToList();
        }

        public Event Get(string id)
        {
            return _events.Find<Event>(book => book.id == id).FirstOrDefault();
        }

        public Event Create(Event book)
        {
            _events.InsertOne(book);
            return book;
        }

        public void Update(string id, Event bookIn)
        {
            _events.ReplaceOne(book => book.id == id, bookIn);
        }

        public void Remove(Event bookIn)
        {
            _events.DeleteOne(book => book.id == bookIn.id);
        }

        public void Remove(string id)
        {
            _events.DeleteOne(book => book.id == id);
        }
    }
}
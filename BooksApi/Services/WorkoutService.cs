using System.Collections.Generic;
using System.Linq;
using WorkoutApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace WorkoutApi.Services
{
    public class WorkoutService
    {
        private readonly IMongoCollection<Workout> _workouts;

        public WorkoutService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _workouts = database.GetCollection<Workout>("Workouts");
        }

        public List<Workout> Get()
        {
            return _workouts.Find(book => true).ToList();
        }

        public Workout Get(string id)
        {
            return _workouts.Find<Workout>(book => book.Id == id).FirstOrDefault();
        }

        public Workout Create(Workout book)
        {
            _workouts.InsertOne(book);
            return book;
        }

        public void Update(string id, Workout bookIn)
        {
            _workouts.ReplaceOne(book => book.Id == id, bookIn);
        }

        public void Remove(Workout bookIn)
        {
            _workouts.DeleteOne(book => book.Id == bookIn.Id);
        }

        public void Remove(string id)
        {
            _workouts.DeleteOne(book => book.Id == id);
        }
    }
}
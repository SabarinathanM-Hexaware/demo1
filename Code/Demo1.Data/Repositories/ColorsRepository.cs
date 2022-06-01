using Demo1.Data.Interfaces;
using Demo1.Entities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1.Data.Repositories
{
    public class ColorsRepository : IColorsRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Colors";

        public ColorsRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Colors> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Colors>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Colors GetById(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Colors>(_collectionName)
                         .Find(o => o.Id == id)
                         .SingleOrDefault();
            return result;
        }

        public void Save(Colors entity)
        {
            _gateway.GetMongoDB().GetCollection<Colors>(_collectionName)
                .InsertOne(entity);
        }

        public Colors Update(string id, Colors entity)
        {
            var update = Builders<Colors>.Update
                .Set(e => e.Desc, entity.Desc );

            var result = _gateway.GetMongoDB().GetCollection<Colors>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public void Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Colors>(_collectionName)
                         .DeleteOne(e => e.Id == id);
            Console.WriteLine(result);
        }
    }
}

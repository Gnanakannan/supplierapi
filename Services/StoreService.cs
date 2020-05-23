using supplierapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace supplierapi.Services
{
    public class StoreService
    {
        private readonly IMongoCollection<Store> _stores;

        public StoreService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _stores = database.GetCollection<Store>(settings.StoresCollectionName);
        }

        public List<Store> Get() =>
            _stores.Find(stores => true).ToList();

        public Store Get(string id) =>
            _stores.Find<Store>(stores => stores.Id == id).FirstOrDefault();

        public Store Create(Store store)
        {
            _stores.InsertOne(store);
            return store;
        }

        public void Update(string id, Store storeIn) =>
            _stores.ReplaceOne(store => store.Id == id, storeIn);

        public void Remove(Store storeIn) =>
            _stores.DeleteOne(store => store.Id == storeIn.Id);

        public void Remove(string id) => 
            _stores.DeleteOne(store => store.Id == id);
    }
}

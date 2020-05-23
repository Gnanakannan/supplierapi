using System.Text.Json.Serialization;

namespace supplierapi
{
    public class StoreUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Token { get; set; }
    }

    public class StoreUsersDatabaseSettings : IStoreUsersDatabaseSettings
    {
        public string StoreUsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStoreUsersDatabaseSettings
    {
        string StoreUsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
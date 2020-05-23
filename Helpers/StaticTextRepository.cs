// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Options;
// using Microsoft.Extensions.Caching.Distributed;
// //using Microsoft.Azure.Documents;
// using Newtonsoft.Json;
// using supplierapi;


// namespace supplierapi.Helpers
// {
//     public class StaticTextRepository : IStaticTextRepository
//     {
//         #region Variables

//         private readonly ICosmosDatabaseRepository cosmos_database_repository;
//         private readonly IDistributedCache distributed_cache;
//         private readonly CacheOptions cache_options;
//         private readonly ILanguageRepository language_repository;

//         #endregion

//         #region Constructors

//         public StaticTextRepository(ICosmosDatabaseRepository cosmos_database_repository, IDistributedCache distributed_cache, IOptions<CacheOptions> cache_options, 
//             ILanguageRepository language_repository)
//         {
//             // Set values for instance variables
//             this.cosmos_database_repository = cosmos_database_repository;
//             this.distributed_cache = distributed_cache;
//             this.cache_options = cache_options.Value;
//             this.language_repository = language_repository;

//         } // End of the constructor

//         #endregion

//         #region Add methods

//         public async Task<bool> Add(StaticTextsDocument item)
//         {
//             // Create a document
//             return await this.cosmos_database_repository.Add<StaticTextsDocument>(item);

//         } // End of the Add method

//         #endregion

//         #region Update methods

//         public async Task<bool> Upsert(StaticTextsDocument item)
//         {
//             // Upsert a document
//             return await this.cosmos_database_repository.Upsert<StaticTextsDocument>(item);

//         } // End of the Upsert method

//         public async Task<bool> Update(StaticTextsDocument item)
//         {
//             // Replace a document
//             return await this.cosmos_database_repository.Update<StaticTextsDocument>(item.id, item);

//         } // End of the Update method

//         #endregion

//         #region Get methods

//         public async Task<ModelItem<StaticTextsDocument>> GetById(string id)
//         {
//             // Return the post
//             return await this.cosmos_database_repository.GetById<StaticTextsDocument>(id, id);

//         } // End of the GetById method

//         public async Task<ModelItem<StaticTextsDocument>> GetByLanguageCode(string language_code)
//         {
//             // Create the sql string
//             string sql = "SELECT VALUE s FROM s WHERE s.language_code = @language_code AND s.model_type = @model_type";

//             // Create parameters
//             SqlParameterCollection parameters = new SqlParameterCollection()
//             {
//                 new SqlParameter("@language_code", language_code),
//                 new SqlParameter("@model_type", "static_text")
//             };

//             // Return the post
//             return await this.cosmos_database_repository.GetByQuery<StaticTextsDocument>(sql, parameters);

//         } // End of the GetByLanguageCode method

//         public async Task<KeyStringList> GetFromCache(string language_code)
//         {
//             // Create the cacheId
//             string cacheId = "StaticTexts_" + language_code.ToString();

//             // Get the cached settings
//             string data = this.distributed_cache.GetString(cacheId);

//             // Create the list to return
//             KeyStringList posts = new KeyStringList();

//             if (data == null)
//             {
//                 // Get the post
//                 ModelItem<StaticTextsDocument> static_texts_model = await GetByLanguageCode(language_code);

//                 // Make sure that something was found in the database
//                 if (static_texts_model.item == null)
//                 {
//                     return posts;
//                 }
//                 else
//                 {
//                     posts = new KeyStringList(static_texts_model.item.dictionary);
//                 }

//                 // Create cache options
//                 DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions();
//                 cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromMinutes(this.cache_options.ExpirationInMinutes));
//                 cacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(this.cache_options.ExpirationInMinutes));

//                 // Save data in cache
//                 this.distributed_cache.SetString(cacheId, JsonConvert.SerializeObject(posts), cacheEntryOptions);
//             }
//             else
//             {
//                 posts = JsonConvert.DeserializeObject<KeyStringList>(data);
//             }

//             // Return the post
//             return posts;

//         } // End of the GetFromCache method

//         #endregion

//         #region Delete methods

//         public async Task<bool> DeleteOnId(string id)
//         {
//             // Delete a document
//             return await this.cosmos_database_repository.DeleteOnId(id, id);

//         } // End of the DeleteOnId method

//         #endregion

//         #region Helper methods

//         public async Task RemoveFromCache()
//         {
//             // Get all languages
//             ModelItem<LanguagesDocument> languages_model = await this.language_repository.GetByType();

//             // Loop languages
//             foreach (KeyValuePair<string, string> entry in languages_model.item.dictionary)
//             {
//                 // Get the data
//                 string data = this.distributed_cache.GetString("StaticTexts_" + entry.Key);

//                 // Only remove the cache if it exists
//                 if (data != null)
//                 {
//                     // Remove data from cache
//                     this.distributed_cache.Remove("StaticTexts_" + entry.Key);
//                 }
//             }

//         } // End of the RemoveFromCache method

//         #endregion

//     } // End of the class
// }
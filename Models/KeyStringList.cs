// using System;
// using System.Collections.Generic;
// using MongoDB.Bson;
// using MongoDB.Bson.Serialization.Attributes;

// namespace supplierapi
// {
//     public class KeyStringList
//     {
//         #region Variables

//         public IDictionary<string, string> dictionary;

//         #endregion

//         #region Constructors

//         public KeyStringList()
//         {
//             // Set values for instance variables
//             this.dictionary = new Dictionary<string, string>(10);

//         } // End of the constructor

//         public KeyStringList(Int32 capacity)
//         {
//             // Set values for instance variables
//             this.dictionary = new Dictionary<string, string>(capacity);

//         } // End of the constructor

//         public KeyStringList(IDictionary<string, string> dictionary)
//         {
//             // Set values for instance variables
//             this.dictionary = dictionary;

//         } // End of the constructor

//         #endregion

//         #region Insert methods

//         public void Add(string key, string value)
//         {
//             // Add the value to the dictionary
//             dictionary.Add(key, value);

//         } // End of the Add method

//         #endregion

//         #region Update methods

//         public void Update(string key, string value)
//         {
//             // Update the value
//             dictionary[key] = value;

//         } // End of the Update method

//         #endregion

//         #region Get methods

//         public string Get(string key)
//         {
//             // Create the string to return
//             string value = key;

//             // Check if the dictionary contains the key
//             if (this.dictionary.ContainsKey(key))
//             {
//                 value = this.dictionary[key];
//             }

//             // Return the value
//             return value;

//         } // End of the Get method

//         #endregion

//     } // End of the class
// }

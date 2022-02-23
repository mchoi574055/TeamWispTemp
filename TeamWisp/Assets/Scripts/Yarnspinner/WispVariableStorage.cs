
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using SQLite;

public class WispVariableStorage : VariableStorageBehaviour
{
    // TO DO STILL: Database
    public class YarnString
    {
        [PrimaryKey]
        public string key { get; set; }
        public string value { get; set; }
    }
    public class YarnFloat
    {
        [PrimaryKey]
        public string key { get; set; }
        public float value { get; set; }
    }
    public class YarnBool
    {
        [PrimaryKey]
        public string key { get; set; }
        public bool value { get; set; }
    }
    public override bool TryGetValue<T>(string variableName, out T result) // Figure out whether a value exists for given key + return as correct type
    {
        string query = "";
        List<object> results = null;
        // Try to get value from given table, as a generic object
        if (typeof(T) == typeof(string))
        {
            query = $"SELECT value FROM YarnString WHERE key = {variableName}";
        }
        // (other cases go here)
        else if (typeof(T) == typeof(bool))
        {

        }
        else if (typeof(T) == typeof(float))
        {

        }
        #2#
        // if a result was found, convert it to type T and assign it
        results = db.Query<object>(query);
        if (results?.Count > 0)
        {
            result = (T)results[0];
            return true;
        }

        // otherwise TryGetValue has failed
        result = default(T);
        return false;
    }
    private bool Exists(string variableName, System.Type type) // Checks if a vlue exists with that key in a specific table
    {
        if (type == typeof(string))
        {
            string stringResult;
            if (TryGetValue<string>(variableName, out stringResult))
            {
                return (stringResult != null);
            }
        }
        else if (type == typeof(bool))
        {
            string boolResult;
            if (TryGetValue<string>(variableName, out boolResult))
            {
                return (boolResult != null);
            }
        }
        else if (type == typeof(float))
        {
            string floatResult;
            if (TryGetValue<string>(variableName, out floatResult))
            {
                return (floatResult != null);
            }
        }
        return false;
    }
    public override void SetValue(string variableName, string stringValue)
    {
        // check it doesn't exist already in other table
        if (Exists(variableName, typeof(bool)))
        {
            throw new System.ArgumentException($"{variableName} is a bool.");
            // check if doesn't exist already in other other table
        }
        else if (Exists(variableName, typeof(float)))
        {
            throw new System.ArgumentException($"{variableName} is a float.");
        }
        // if not, insert or update row in this table to the given value
        string query = "INSERT OR REPLACE INTO YarnString (key, value)";
        query += $"VALUES ({variableName}, {stringValue})";
        db.Execute(query);
    }
    public override void SetValue(string variableName, float floatValue) { }
    public override void SetValue(string variableName, bool boolValue) { }
    public override void Clear() // Telling each database to clear its entries
    {
        db.Execute("DELETE * FROM YarnString;");
        db.Execute("DELETE * FROM YarnBool;");
        db.Execute("DELETE * FROM YarnFloat;");
    }
    public override bool Contains(string variableName)
    {
        return Exists(variableName, typeof(string)) ||
            Exists(variableName, typeof(bool)) ||
            Exists(variableName, typeof(float));
    }

    // Start is called before the first frame update
    void Start()
    {
        // Need to pick place on disk for database to save to
        string path = Application.persistentDataPath + "/db.sqlite";
        // Create a new database connection to speak to it
        db = new SQLiteConnection(path);
        // Tables we need
        db.CreateTable<YarnString>();
        db.CreateTable<YarnFloat>();
        db.CreateTable<YarnBool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/


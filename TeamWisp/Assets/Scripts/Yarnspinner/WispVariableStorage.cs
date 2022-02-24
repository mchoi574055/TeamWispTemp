//
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Yarn.Unity;
//
// public class WispVariableStorage : VariableStorageBehaviour
// {
//
//     public override bool TryGetValue<T>(string variableName, out T result) // Figure out whether a value exists for given key + return as correct type
//     {
//         
//     }
//
//     public override void Clear()
//     {
//         
//     }
//
//     public override void SetValue(string variableName, string stringValue) { }
//     public override void SetValue(string variableName, float floatValue) { }
//     public override void SetValue(string variableName, bool boolValue) { }
//     public override bool Contains(string variableName)
//     {
//         return Exists(variableName, typeof(string)) ||
//             Exists(variableName, typeof(bool)) ||
//             Exists(variableName, typeof(float));
//     }
//
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
//     
//     // Private Methods
//     private bool Exists(string variableName, System.Type type) // Checks if a vlue exists with that key in a specific table
//     {
//         if (type == typeof(string))
//         {
//             string stringResult;
//             if (TryGetValue<string>(variableName, out stringResult))
//             {
//                 return (stringResult != null);
//             }
//         }
//         else if (type == typeof(bool))
//         {
//             string boolResult;
//             if (TryGetValue<string>(variableName, out boolResult))
//             {
//                 return (boolResult != null);
//             }
//         }
//         else if (type == typeof(float))
//         {
//             string floatResult;
//             if (TryGetValue<string>(variableName, out floatResult))
//             {
//                 return (floatResult != null);
//             }
//         }
//         return false;
//     }
// }


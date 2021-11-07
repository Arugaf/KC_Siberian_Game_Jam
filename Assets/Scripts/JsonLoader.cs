using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

static public class JsonLoader
{
   static public void LoadInfoFromFile<T>(string fileName, ref List<T> container) {
        string filePath = Application.dataPath + "/Scripts/" + fileName + ".json";

        if(File.Exists(filePath))
            container = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));
        else
            Debug.LogError("File - " + filePath + " doesn't exist");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable] public struct Dialog_t {
    public uint ID;
    public string author; // speaker's name 
    public List<string> text;
}

static public class Dialog
{
   static public void LoadDialogsFromFile(string fileName, ref List<Dialog_t> container) {
        string filePath = Application.dataPath + "/Scripts/" + fileName + ".json";

        if(File.Exists(filePath))
            container = JsonConvert.DeserializeObject<List<Dialog_t>>(File.ReadAllText(filePath));
        else
            Debug.LogError("File - " + filePath + " doesn't exist");
    
    }
}

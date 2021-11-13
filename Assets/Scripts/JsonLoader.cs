using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

static public class JsonLoader
{
   static string fileText;
   static string filePath;
   static bool isReady;
   static UnityWebRequest www;
   static public void LoadInfoFromFile<T>(string fileName, ref List<T> container) {
        #if UNITY_WEBGL
            filePath = Path.Combine(Application.streamingAssetsPath, "/StreamingAssets" + fileName);
            www = UnityWebRequest.Get(filePath);
            Debug.Log("try get file - " + filePath);
            StartCoroutine(LoadFile(filePath));
            container = JsonConvert.DeserializeObject<List<T>>(fileText);
        #else
            filePath = Application.streamingAssetsPath + fileName;//Application.dataPath + "/Scripts/" + fileName + ".json";
            if(!File.Exists(filePath))
                Debug.LogError("File - " + filePath + " doesn't exist");
            container = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));
        #endif
    }

    static IEnumerator LoadFile(string _s) {
        Debug.Log("Coroutine started in - " + _s);
        yield return www.SendWebRequest();
        Debug.LogWarning("www - " + www.result);
        fileText = www.downloadHandler.text;
        if(www.downloadHandler.isDone)
            isReady = www.downloadHandler.isDone;
        Debug.Log("Load from server - " + www.downloadHandler.text);
    }
}

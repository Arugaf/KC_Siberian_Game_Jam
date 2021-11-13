using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour {
    public string phrasesFile;
    public string questionsFile;
    public string itemsFile;

    // Key phrases ID's
    public int guiltyID;
    public int notGuiltyID;
    public int startPhraseID;
    public int firstPlayerPhraseID;
    //public JsonLoader _jl;
    //__//
    [SerializeField] TMP_Text dialogField;
    [SerializeField] TMP_Text nameField;
    [SerializeField] ActorController actor;
    List<Phrase_t> phrases = new List<Phrase_t>();
    
    void Start() {
        JsonLoader.LoadInfoFromFile(phrasesFile, ref phrases);
        Debug.Log("Load - " + phrases.Count + " phrases");
    }

    public void ShowPhrase(int id) {
        var currentPhrase = phrases.Find(item => item.ID.Equals(id));
        if(currentPhrase == null)
            Debug.LogError("Phrase - " + id + " can't be found");
        UpdateText(currentPhrase);
        UpdateActor(currentPhrase.emotion);
    }

    public void UpdateActor(Emotion _e) {
        //update emotion images
        actor.ChangeEmotion(_e);
    }

    public void UpdateText(Phrase_t phrase, int st = 0) { 
        nameField.text = phrase.author;
        dialogField.text = phrase.text[0];
    }

    // public T FindByID<T>(List<T> list, int ID) {
    //     return list.Find( item => item.ID.Equals(ID));
    //     // if(res != null)
    //     //     return res;
    // }


}

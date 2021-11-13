using System.Collections;
using System.Collections.Generic;

public enum Emotion {
        Neutral,
        Happy,
        Sad
    }

[System.Serializable] 
public class Phrase_t {
    public int ID;
    public string author; // speaker's name 
    public List<string> text;
    public Emotion emotion;
}

[System.Serializable]
public struct Item_t {
    public int ID;
    public string name; // speaker's name 
    public string description;
    public string icon;
    public int phrase;
}

[System.Serializable] 
public struct Question_t {
    public int ID;
    public string _description; // commentary
    public int text;
    public int keyID; // right item ID 
    public int wrongAnswerReactionID;
    public int rightAnswerReactionID;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Inventory_t {
    public bool isOpen;
    public List<int> items;
    public int pickedItem;
}

public class Court : MonoBehaviour {
    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject textBoxUI;
    [SerializeField] GameObject actor1;
    [SerializeField] GameObject actor2;
    [SerializeField] DialogManager dialogManager;
    G _g;
    const int MIN_SCORE = 1; // TODO: move to G
    Inventory_t inventory = new Inventory_t();
    Queue<int> phrasesQueue = new Queue<int>();
    List<Question_t> questions = new List<Question_t>();
    List<Item_t> items = new List<Item_t>();
    int score = 0; // TODO: move to G
    int currQuestion = 0;

    public void Start() {
        _g = FindObjectOfType<G>();

        JsonLoader.LoadInfoFromFile(dialogManager.questionsFile.name, ref questions);
        Debug.Log("Load - " + questions.Count + " questions");

        JsonLoader.LoadInfoFromFile(dialogManager.itemsFile.name, ref items);
        Debug.Log("Load - " + items.Count + " items");
    }

    public void ChangeState() {
        if(_g != null) {
            _g.CurrentState = GameState.Ending;
            _g.sceneController.SwitchScene(_g.CurrentState);
        }
    }

    public void InventoryHandler() {
        if(inventory.isOpen){
            inventoryUI.SetActive(false);
            inventory.isOpen = false;
            textBoxUI.SetActive(true);
            Debug.Log("Inventory is closed");
        }
        else{
            inventoryUI.SetActive(true);
            inventory.isOpen = true;
            textBoxUI.SetActive(false);
            Debug.Log("Inventory is opened");
        }
    }

    //new stuff

    void InitDialog() {
        //fetching
        phrasesQueue.Enqueue(dialogManager.startPhraseID);
        phrasesQueue.Enqueue(dialogManager.firstPlayerPhraseID);

        currQuestion = 0;
        phrasesQueue.Enqueue(questions[currQuestion].text);
        Step();
    }

    public void Step() {
        if(phrasesQueue.Count > 0) {
            dialogManager.ShowPhrase(phrasesQueue.Dequeue());
        }
        else{
            if(inventory.items.Count > 0 ) {
                InventoryHandler(); //show panels
            }
            else {
                GetVerdict();
                dialogManager.ShowPhrase(phrasesQueue.Dequeue());
            }
                
        }
    }

    void GetVerdict() {
        if(score < MIN_SCORE)
            phrasesQueue.Enqueue(dialogManager.guiltyID);
        else
            phrasesQueue.Enqueue(dialogManager.notGuiltyID);
    }

    public void ClickInventory(GameObject _go, int id) {
        inventory.pickedItem = id;
        Debug.Log("Item - " + id + " is picked");
        inventory.items.RemoveAt(id);
        _go.SetActive(false);
        InventoryHandler();//hide panels
        phrasesQueue.Enqueue(items.Find(item => item.ID.Equals(id)).phrase);
        AddAnswer(id);
        phrasesQueue.Enqueue(questions[currQuestion].text);
        Step();
    }

    void AddAnswer(int pickedID) {
        var _q = questions[currQuestion];
        if(pickedID == _q.keyID) {
            phrasesQueue.Enqueue(_q.rightAnswerReactionID);
        }
        else {
            phrasesQueue.Enqueue(_q.wrongAnswerReactionID);
        }
        currQuestion++;
    }

    // public void PickItem(int itemID) {
    //     inventory.pickedItem = itemID;
    //     Debug.Log("Item - " + itemID + " is picked");
    // }

    // public void SwitchDialog() {
    //     dialogManager.ShowNext();
    // }
}

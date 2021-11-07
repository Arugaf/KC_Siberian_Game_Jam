using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct Inventory_t {
    public bool isOpen;
    public List<int> items;
    public List<bool> itemStatus;
    public List<string> itemsSprites;
    public int pickedItem;
}

public class Court : MonoBehaviour {
    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject textBoxUI;
    [SerializeField] GameObject actor1;
    [SerializeField] GameObject actor2;
    [SerializeField] DialogManager dialogManager;
    [SerializeField] InventoryManager inventoryManager;
    G _g;
    const int MIN_SCORE = 1; // TODO: move to G
    Inventory_t inventory = new Inventory_t();
    Queue<int> phrasesQueue = new Queue<int>();
    List<Question_t> questions = new List<Question_t>();
    List<Item_t> items = new List<Item_t>();
    int score = 0; // TODO: move to G
    int currQuestion = 0;

    bool isOver = false;

    public void Start() {
        _g = FindObjectOfType<G>();

        JsonLoader.LoadInfoFromFile(dialogManager.questionsFile.name, ref questions);
        Debug.Log("Load - " + questions.Count + " questions");

        JsonLoader.LoadInfoFromFile(dialogManager.itemsFile.name, ref items);
        Debug.Log("Load - " + items.Count + " items");

        LoadInventory();
        InitDialog();
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

    Item_t FindItem(int id) {
        return items.Find(item => item.ID.Equals(id));
    }
    void LoadInventory() {
        // TODO: load data from G
        inventory.items = new List<int>(){1,2,3,4,5};
        inventory.itemStatus = new List<bool>(){true,true,true,true,true};
        inventory.itemsSprites = new List<string>() {
            FindItem(inventory.items[0]).icon,
            FindItem(inventory.items[1]).icon,
            FindItem(inventory.items[2]).icon,
            FindItem(inventory.items[3]).icon,
            FindItem(inventory.items[4]).icon    
        };
        Debug.Log("Sprite - " + FindItem(inventory.items[0]).icon);
        inventoryManager.InitItems(inventory.items, inventory.itemsSprites);
    }

    bool HasAvailableItems() {
        foreach(var i in inventory.itemStatus) {
            if(i == true)
                return true; 
        }
        return false;
    }

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
            Debug.Log("pQ - " + phrasesQueue.Peek());
            dialogManager.ShowPhrase(phrasesQueue.Dequeue());
        }
        else{
            if(HasAvailableItems()) {
                InventoryHandler(); //show panels
            }
            else {
                if(!isOver) {
                    GetVerdict();
                    Debug.Log("Verdict");
                    dialogManager.ShowPhrase(phrasesQueue.Dequeue());
                }
                else {
                    Debug.Log("It's over");
                    ChangeState();
                } 
            } 
        }
    }

    void GetVerdict() {
        if(score < MIN_SCORE)
            phrasesQueue.Enqueue(dialogManager.guiltyID);
        else
            phrasesQueue.Enqueue(dialogManager.notGuiltyID);
        isOver = true;
    }

    int GetItemID(int index) {
        Debug.Log("Get item id - " + inventory.items[index] + " from index - " + index);
        return inventory.items[index];
    }

    public void ClickInventory(int index) { //GameObject _go
        inventory.pickedItem = index;
        Debug.Log("Item - " + index + " is picked");
        inventory.itemStatus[index] = false;//inventory.items.RemoveAt(index);
        inventoryManager.DeleteItem(index);
        InventoryHandler();//hide panels
        phrasesQueue.Enqueue(items.Find(item => item.ID.Equals(GetItemID(index))).phrase);
        AddAnswer(GetItemID(index));
        Debug.Log("New Quesion index - " + currQuestion);
        phrasesQueue.Enqueue(questions[currQuestion].text);
        Step();
    }

    void AddAnswer(int pickedID) {
        var _q = questions[currQuestion];
        if(pickedID == _q.keyID) {
            phrasesQueue.Enqueue(_q.rightAnswerReactionID);
            Debug.Log("Right answer - " + phrasesQueue.Peek());
        }
        else {
            phrasesQueue.Enqueue(_q.wrongAnswerReactionID);
            Debug.Log("Wrong answer - " + phrasesQueue.Peek());
        }
        if(currQuestion < questions.Count -1)
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

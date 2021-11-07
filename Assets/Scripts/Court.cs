using UnityEngine;


struct Inventory_t {
    public bool isOpen;
    public int pickedItem;
}

public class Court : MonoBehaviour {

    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject textBoxUI;
    [SerializeField] GameObject actor1;
    [SerializeField] GameObject actor2;
    [SerializeField] DialogManager dialogManager;
    private G _g;
    private Inventory_t inventory = new Inventory_t();

    public void Start() {
        _g = FindObjectOfType<G>();
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

    public void PickItem(int itemID) {
        inventory.pickedItem = itemID;
        Debug.Log("Item - " + itemID + " is picked");
    }

    public void SwitchDialog() {
        dialogManager.ShowNextDialog();
    }
}

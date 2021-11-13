using Items;
using UnityEngine;
using Player;

public class Crime : MonoBehaviour {
    private G _g;

    public PlayerInventory inventory;

    public void Start() {
        _g = FindObjectOfType<G>();
        inventory.Reset();
    }

    public void ChangeState() {
        if(_g != null) {
            _g.inventory = inventory.GetItemsID();
            _g.CurrentState = GameState.Court;
            _g.sceneController.SwitchScene(_g.CurrentState);
        }
    }
}

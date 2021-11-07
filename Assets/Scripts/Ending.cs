using Player;
using UnityEngine;

public class Ending : MonoBehaviour {
    private G _g;

    private PlayerInventory _inventory;

    public void Start() {
        _g = FindObjectOfType<G>();
        _inventory = FindObjectOfType<PlayerInventory>();
    }

    public void ChangeState() {
        _g.CurrentState = GameState.Menu;
        _inventory.Reset();
        _g.sceneController.SwitchScene(_g.CurrentState);
    }
}

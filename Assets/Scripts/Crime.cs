using Items;
using UnityEngine;

public class Crime : MonoBehaviour {
    private G _g;

    public InventoryUI inventory;

    public void Start() {
        _g = FindObjectOfType<G>();
    }

    public void ChangeState() {
        _g.CurrentState = GameState.Court;
        _g.sceneController.SwitchScene(_g.CurrentState);
    }
}

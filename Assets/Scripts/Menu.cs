using UnityEngine;

public class Menu : MonoBehaviour {
    private G _g;

    public void Start() {
        _g = FindObjectOfType<G>();
    }

    public void ChangeState() {
        _g.CurrentState = GameState.Crime;
        _g.sceneController.SwitchScene(_g.CurrentState);
    }
}

using UnityEngine;

public class Ending : MonoBehaviour {
    private G _g;

    public void Start() {
        _g = FindObjectOfType<G>();
    }

    public void ChangeState() {
        _g.CurrentState = GameState.Menu;
        _g.sceneController.SwitchScene(_g.CurrentState);
    }
}

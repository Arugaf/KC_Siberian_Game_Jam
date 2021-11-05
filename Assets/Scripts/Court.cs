using UnityEngine;

public class Court : MonoBehaviour {
    private G _g;

    public void Start() {
        _g = FindObjectOfType<G>();
    }

    public void ChangeState() {
        _g.CurrentState = GameState.Ending;
        _g.sceneController.SwitchScene(_g.CurrentState);
    }
}

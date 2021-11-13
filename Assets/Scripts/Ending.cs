using Player;
using UnityEngine;

public class Ending : MonoBehaviour {
    G _g;

    [SerializeField] GameObject happyEnd;
    [SerializeField] GameObject badEnd;

    public void Start() {
        _g = FindObjectOfType<G>();
        if(_g != null)
            ShowEnding(_g.isHappyEnd);
    }

    public void ShowEnding(bool _b) {
        happyEnd.SetActive(_b);
        badEnd.SetActive(!_b);
    }

    public void ChangeState() {
        if(_g != null) {
            _g.CurrentState = GameState.Menu;
            _g.sceneController.SwitchScene(_g.CurrentState);
        }
    }
}

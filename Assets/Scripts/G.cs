using UnityEngine;

public enum GameState {
    Empty,
    Menu,
    Crime,
    Court,
    Ending
}

public class G : MonoBehaviour {
    public SceneController sceneController;

    public GameState CurrentState { set; get; }

    public void Start() {
        DontDestroyOnLoad(this);

        sceneController = GetComponent<SceneController>();

        //looks silly
        CurrentState = GameState.Menu;
        sceneController.SwitchScene(CurrentState);
    }
}

using Player;
using UnityEngine;

public enum GameState {
    Empty,
    Menu,
    Intro,
    Crime,
    Court,
    Ending
}

public class G : MonoBehaviour {
    public SceneController sceneController;

    public GameState CurrentState { set; get; }

    public PlayerInventory inventory;

    public void Start() {
        DontDestroyOnLoad(this);

        sceneController = GetComponent<SceneController>();
        // inventory = GetComponent<PlayerInventory>();

        //looks silly
        CurrentState = GameState.Menu;
        sceneController.SwitchScene(CurrentState);
    }
}

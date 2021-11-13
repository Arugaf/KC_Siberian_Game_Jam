using Player;
using System.Collections.Generic;
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

    public bool isHappyEnd;

    public List<int> inventory;

    public void Start() {
        DontDestroyOnLoad(this);

        sceneController = GetComponent<SceneController>();
        // inventory = GetComponent<PlayerInventory>();

        //looks silly
        CurrentState = GameState.Menu;
        sceneController.SwitchScene(CurrentState);
    }
}

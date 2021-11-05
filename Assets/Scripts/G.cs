using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
    {
        Empty,
        Menu,
        Crime,
        Court,
        Ending
    }

public class G : MonoBehaviour
{
    public SceneController sceneController;

    public GameState currState { set; get; }
    
    void Start()
    {
        DontDestroyOnLoad(this);

        sceneController = GetComponent<SceneController>();

        //looks silly
        currState = GameState.Menu;
        sceneController.SwitchScene(currState);
    }

    void Update()
    {
        
    }
}

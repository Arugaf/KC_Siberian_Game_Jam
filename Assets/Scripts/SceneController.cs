using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] List<Object> gameScenes;

    public void SwitchScene(GameState state)
    {
        //Switch scenes
        switch(state)
        {
            case GameState.Empty:
            break;
            case GameState.Menu:
                StartScene(gameScenes[0].name);
            break;
            case GameState.Crime:
                StartScene("CrimeScene");
            break;
            case GameState.Court:
                StartScene("CourtScene");
            break;
            case GameState.Ending:
                StartScene("Ending");
            break;
        }
    }
    public void StartScene(string scene_name)
    {
        Debug.Log("Starting scene - " + scene_name);
        SceneManager.LoadScene(scene_name, LoadSceneMode.Single);
        Debug.Log(scene_name + " - scene is loaded");
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class SceneController : MonoBehaviour {
    [SerializeField] private List<Object> gameScenes;

    public void SwitchScene(GameState state) {
        //Switch scenes
        switch (state) {
            case GameState.Empty:
                break;
            case GameState.Menu:
                StartScene("Menu");
                break;
            case GameState.Intro:
                StartScene("Intro");
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
            default:
                throw new Exception("Incorrect game state! " + state);
        }
    }

    private static void StartScene(string sceneName) {
        Debug.Log("Starting scene - " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        Debug.Log(sceneName + " - scene is loaded");
    }
}

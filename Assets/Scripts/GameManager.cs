using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameState { GAMEPLAY, PAUSED, MAINMENU, OVER }

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private string _startScene;

    private GameState _currentGameState = GameState.MAINMENU;

    public GameState GameState { get => _currentGameState; }
    
    public void TransitToState(GameState newGameState)
    {
        _currentGameState = newGameState;

        switch (newGameState)
        {
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
            default:
                Time.timeScale = 1f;
                break;
        }
    }

    private void Start()
    {
        SceneManager.LoadScene(_startScene, LoadSceneMode.Additive);
    }

    private void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

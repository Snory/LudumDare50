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

    [SerializeField]
    private GlobalEvent _pauseGameGlobalEvent;
    
    [SerializeField]
    private GlobalEvent _restartGameGlobalEvent;

    public void TransitToState(GameState newGameState)
    {
        _currentGameState = newGameState;

        switch (newGameState)
        {
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
            case GameState.OVER:
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pressed P");
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void PauseGame()
    {
        _pauseGameGlobalEvent.Raise();
        if(_currentGameState == GameState.PAUSED)
        {
            TransitToState(GameState.GAMEPLAY);
        } else if(_currentGameState == GameState.GAMEPLAY)
        {
            TransitToState(GameState.PAUSED);
        }

    }

    public void GameOver()
    {
        TransitToState(GameState.OVER);
    }

    public void RestartGame()
    {
        if (_currentGameState != GameState.OVER) return;

        _restartGameGlobalEvent.Raise();
        TransitToState(GameState.GAMEPLAY);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}

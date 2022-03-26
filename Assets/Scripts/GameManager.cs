using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameState { GAMEPLAY, PAUSED, MAINMENU, OVER }

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private string _startLevel;

    private GameState _currentGameState = GameState.MAINMENU;

    public GameState GameState { get => _currentGameState; }

    [SerializeField]
    private UIManager _uiManager;
    
    [SerializeField]
    private SceneTransitionBase _sceneTransition;

    public void TransitToState(GameState newGameState)
    {
        _currentGameState = newGameState;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            MainMenu();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void StartGame()
    {
        //transit to startlevel
        _sceneTransition.TransitToScene(_startLevel, LoadSceneMode.Additive);
        _uiManager.ShowMainMenu(false);
        TransitToState(GameState.GAMEPLAY);
    }

    public void LoadLevel(string name)
    {
        _sceneTransition.TransitToScene(name, LoadSceneMode.Additive);
        TransitToState(GameState.GAMEPLAY);
    }

    public void PauseGame()
    {
        if (_currentGameState == GameState.MAINMENU) return;

        if(_currentGameState == GameState.PAUSED)
        {
            //show pausemenu
            _uiManager.ShowPauseMenu(false);
            //pause game
            TransitToState(GameState.GAMEPLAY);
        }
        else
        {
            //show pausemenu
            _uiManager.ShowPauseMenu(true);
            //pause game
            TransitToState(GameState.PAUSED);
        }
    }


    public void MainMenu()
    {
        //transit to root scene
        _sceneTransition.UnloadCurrentScene();
        //show mainmenu
        _uiManager.ShowMainMenu(true);
        //pause game
    }

    public void GameOver()
    {
        if (_currentGameState != GameState.GAMEPLAY) return;

        _uiManager.ShowGameOver(true);
        TransitToState(GameState.OVER);
    }

    public void Restart()
    {
        if (_currentGameState != GameState.OVER) return;
        
        _sceneTransition.ReloadCurrentScene();
        _uiManager.ShowGameOver(false);
        TransitToState(GameState.GAMEPLAY);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}

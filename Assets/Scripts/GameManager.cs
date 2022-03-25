using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameState { GAMEPLAY, PAUSED, MAINMENU }

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private string _startLevel;

    private GameState _gamestate;

    public GameState GameState { get => _gamestate; }

    [SerializeField]
    private UIManager _uiManager;
    
    [SerializeField]
    private SceneTransitionBase _sceneTransition;

    public void TransitToState(GameState newGameState)
    {
        _gamestate = newGameState;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            MainMenu();
        }
    }

    public void StartGame()
    {
        //transit to startlevel
        _sceneTransition.TransitToScene(_startLevel, LoadSceneMode.Additive);
    }

    public void LoadLevel(string name)
    {

    }

    public void PauseGame()
    {
        //show pausemenu
        
        //pause game
    }


    public void MainMenu()
    {
        //transit to root scene
        _sceneTransition.UnloadCurrentScene();
        //show mainmenu
        //pause game
    }

    public void GameOver()
    {


    }


    public void QuitGame()
    {
        Application.Quit();
    }

}

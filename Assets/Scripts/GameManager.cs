using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameState { GAMEPLAY, PAUSED, MAINMENU }

public class GameManager : Singleton<GameManager>
{

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


    public void StartGame()
    {
        //transit to startlevel
    }

    public void PauseGame()
    {
        //show pausemenu
        //pause game
    }


    public void MainMenu()
    {
        //transit to root scene
        //show mainmenu
        //pause game
    }


}

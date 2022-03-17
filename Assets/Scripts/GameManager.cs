using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { GAMEPLAY, PAUSED, MAINMENU }

public class GameManager : Singleton<GameManager>
{

    private GameState _gamestate;

    public GameState GameState { get => _gamestate; }

    /*
     Musí handlovat stavy bìhu hry:
        - pause
        - running

     Asi by mìl vìdìt, kde se nacházím?
        - main menu
        - paused game
        - game

     Musí reagovat na základní vlastnosti hry:
        - zapauzovat hru
        - zobrazit takové to in game menu
        - pøejít do hlavního menu
        - pøepnout scénu by teda asi mìl umìt


     Main menu - paused state - new scene
     Paused menu - paused state
    
     Chtìl bych zavolat pøi naètení levelu level manažera, který se postará o naètení všech propriet pro daný level
        - vyresetovat hodnoty
        - naspawnovat objekty 
        - naspawnovat pøípadné manažery pro daný level
     */


    public void TransitToState(GameState newGameState)
    {
        _gamestate = newGameState;
    }

    public IEnumerator TransitToScene(string newSceneName, LoadSceneMode loadMode)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetSceneByName(newSceneName).buildIndex, loadMode);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
   
}

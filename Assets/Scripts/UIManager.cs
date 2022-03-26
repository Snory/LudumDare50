using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject PauseObject;
    public GameObject MainmenuObject;
    public GameObject GameOverObject;


    public void ShowPauseMenu(bool show)
    {
        PauseObject.SetActive(show);
    }

    public void ShowMainMenu(bool show)
    {
        MainmenuObject.SetActive(show);
    }

    public void ShowGameOver(bool show)
    {
        GameOverObject.SetActive(show);
    }

}

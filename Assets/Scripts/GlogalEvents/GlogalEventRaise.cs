using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlogalEventRaise : MonoBehaviour
{
    public GlobalEvent GlobalEventToRaise;


    public void Raise()
    {
        GlobalEventToRaise.Raise();
    }
}

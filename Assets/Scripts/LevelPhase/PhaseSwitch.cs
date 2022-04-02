using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PhaseSwitch : MonoBehaviour
{
    public List<LevelPhaseEvent> Phases;

    private int _lastPhaseIndex;

    private void Awake()
    {
        _lastPhaseIndex = 0;
    }

    //raise event with nextphase

    public void NextPhase()
    {
        if(_lastPhaseIndex + 1 > Phases.Count - 1)
        {
            _lastPhaseIndex = 0;
        } else
        {
            _lastPhaseIndex++;
        }

        //raise level phase
        Phases[_lastPhaseIndex].Raise();
    }
}

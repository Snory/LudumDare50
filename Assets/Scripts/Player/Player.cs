using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    [SerializeField]
    private MonsterNeeds _lastSelectedMonster;
   

    private void Update()
    {
        CheckWhatIsUnderMouse();
    }

    private void CheckWhatIsUnderMouse()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(camRay.origin, camRay.direction, Mathf.Infinity, LayerMask.GetMask("Monsters"));

            if (hit)
            {
                if(_lastSelectedMonster != null)
                {
                    _lastSelectedMonster.Selected = false;
                }

                _lastSelectedMonster = hit.transform.GetComponentInChildren<MonsterNeeds>();
                _lastSelectedMonster.Selected = true;
            }
        }

    }

}

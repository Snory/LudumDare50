using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    [SerializeField]
    private MonsterNeeds _lastSelectedMonster;

    //raise to monsterspawner at least
    public UnityEvent<GameObject> MonsterSelected;


    private void Update()
    {
        CheckWhatIsUnderMouse();
    }

    private void CheckWhatIsUnderMouse()
    {



        if (Input.GetMouseButtonDown(0))
        {

            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitInWorldUI = Physics2D.Raycast(camRay.origin, camRay.direction, Mathf.Infinity, LayerMask.GetMask("InWorldUI"));
            RaycastHit2D hitMonster = Physics2D.Raycast(camRay.origin, camRay.direction, Mathf.Infinity, LayerMask.GetMask("Monsters"));


            if (hitMonster)
            {
                if(_lastSelectedMonster != null)
                {
                    _lastSelectedMonster.SetSelected(false);
                }

                _lastSelectedMonster = hitMonster.transform.GetComponentInChildren<MonsterNeeds>();
                _lastSelectedMonster.SetSelected(true);

                RaiseMonsterSelected(hitMonster.transform.gameObject);

            }

            if (hitInWorldUI)
            {
                if(hitInWorldUI.transform.tag == "MonsterSpawner")
                {
                    MonsterSpawnSpot spawnSpot = hitInWorldUI.transform.GetComponentInParent<MonsterSpawnSpot>();
                    spawnSpot.OnSelected();
                }
            }

        }


        if (Input.GetMouseButtonDown(1))
        {
            _lastSelectedMonster.SetSelected(false);
        }

    }


    private void RaiseMonsterSelected(GameObject monster)
    {
        if (MonsterSelected != null)
        {
            MonsterSelected.Invoke(monster);
        }
    }

}

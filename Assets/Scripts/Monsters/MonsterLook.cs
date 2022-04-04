using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLook : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _monsterLookRendered;
    


    public void SetMonsterLook(Sprite sprite)
    {
        _monsterLookRendered.sprite = sprite;
    }
    

}

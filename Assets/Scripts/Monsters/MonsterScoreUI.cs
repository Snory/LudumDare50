using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterScoreUI : MonoBehaviour
{
    private Animator _anim;
    public TextMeshProUGUI Text;

    private void Awake()
    {
        _anim = this.GetComponent<Animator>();
    }


    public void OnScore(float value)
    {
        if (value == 0) return;

        if(value > 0)
        {
            Text.color = Color.green;
        } else if (value < 0)
        {
            Text.color = Color.red;
        }

        _anim.SetTrigger("ShowScore");

        Text.text = value.ToString();
    }


}

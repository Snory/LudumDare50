using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelector : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Sprite NotSelected, Selected;

    private void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();

    }

    public void OnSelected(GameObject monster)
    {
        if(this.transform.parent == monster.transform)
        {
            _spriteRenderer.sprite = Selected;

        } else
        {
            _spriteRenderer.sprite = NotSelected;

        }

    }



}

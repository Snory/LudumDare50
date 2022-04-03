using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Sprite NotSelected, Selected;

    private void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        OnSelected(false);
    }


    public void OnSelected(bool selected)
    {

        if (selected)
        {
            _spriteRenderer.sprite = Selected;
        } else
        {
            _spriteRenderer.sprite = NotSelected;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;
    private SpriteRenderer sr;
    private bool isFlipped = false;
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = backSprite;
    }
    private void OnMouseDown()
    {
        FlipCard();
    }
    public void FlipCard() 
    {
        if (isFlipped)
        {
            sr.sprite = backSprite;
            isFlipped = false;
            
        }
        else
        {
            sr.sprite = frontSprite;
            isFlipped = true;
            
        }
    }


}
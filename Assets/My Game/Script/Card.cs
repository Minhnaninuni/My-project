using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;
    private SpriteRenderer sr;
    private bool isFlipped = false;
    public AudioClip audio1;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
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
            audio.PlayOneShot(audio1);
        }
        else
        {
            sr.sprite = frontSprite;
            isFlipped = true;
            audio.PlayOneShot(audio1);
        }
    }


}
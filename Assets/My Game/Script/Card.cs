using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;
    private SpriteRenderer sr;
    private bool isFlipped = false;
    public AudioClip audio1;
    private new AudioSource audio;
    public bool isMatched = false;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = backSprite;
    }
    private void OnMouseDown()
    {
        if (isMatched || isFlipped) return;
        FlipUp();
        FindObjectOfType<Board>().CardRevealed(this);
    }

    public void FlipUp()
    {
        sr.sprite = frontSprite;
        isFlipped = true;
        audio.PlayOneShot(audio1);
    }

    public void FlipDown()
    {
        sr.sprite = backSprite;
        isFlipped = false;
        audio.PlayOneShot(audio1);
    }

}
using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.ParticleSystem;
using System.Collections;

public class Board : MonoBehaviour
{
    [Header("Card Setup")]
    public GameObject cardPrefab;
    public Transform cardsParent;
    public List<Sprite> cardSymbols;
    public Sprite cardBackSprite;

    [Header("Grid Setup")]
    public int rows = 4;
    public int cols = 4;
    public float spacingX = 2f;
    public float spacingY = 2f;
    public Vector2 startPosition = new Vector2(-6f, 3f);
    private Card firstCard;
    private Card secondCard;
    public AudioSource AudioSource;
    private int score = 0;
    void Start()
    {
        CreateGrid();
        AudioSource = GetComponent<AudioSource>();
    }


    void CreateGrid()
    {

        List<Sprite> randomizedSymbols = new List<Sprite>();
        int pairCount = (rows * cols) / 2;//16 pt => 8 cặp

        for (int i = 0; i < pairCount; i++)
        {
            Sprite symbol = cardSymbols[i];
            randomizedSymbols.Add(symbol);
            randomizedSymbols.Add(symbol);
        }


        ShuffleList(randomizedSymbols);
        
        int index = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Vector2 position = new Vector2(
                    startPosition.x + col * spacingX,
                    startPosition.y - row * spacingY
                );
                GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity, cardsParent);
                Card cardScript = newCard.GetComponent<Card>();
                if (cardScript != null)
                {
                    cardScript.backSprite = cardBackSprite;
                    cardScript.frontSprite = randomizedSymbols[index];
                }
                index++;
            }
        }
    }
    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
    public void CardRevealed(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else if (secondCard == null)
        {
            secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }
    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstCard.frontSprite == secondCard.frontSprite)
        {
            firstCard.isMatched = true;
            secondCard.isMatched = true;
            score += 2;
            Debug.Log(score);
            
        }
        else
        {
            firstCard.FlipDown();
            secondCard.FlipDown();
        }
        firstCard = null;
        secondCard = null;
    }
}
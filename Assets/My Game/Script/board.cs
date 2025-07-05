using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Board : MonoBehaviour
{
    [Header("Card Setup")]
    public GameObject cardPrefab;
    public Transform cardsParent;
    public List<Sprite> listCards;
    public Sprite cardBackSprite;

    [Header("Grid Setup")]
    public int rows = 4;
    public int cols = 4;
    public float spacingX = 2f;
    public float spacingY = 2f;
    public Vector2 startPosition = new Vector2(-6f, 3f);

    private Card firstCard;
    private Card secondCard;

    void Start()
    {
        CreateGrid();
    }



    void CreateGrid()
    {
        List<Sprite> listRandom = new List<Sprite>();
        int pairCount = (rows * cols) / 2;

        for (int i = 0; i < pairCount; i++)
        {
            Sprite Symbol = listCards[i];
            listRandom.Add(Symbol);
            listRandom.Add(Symbol);
        }
        ShuffleList(listRandom);
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector2 position = new Vector2(
                    startPosition.x + j * spacingX,// -4 // -2 // 0
                    startPosition.y - i * spacingY// 3 //5
                    );
                GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity, cardsParent);
                Card sr = newCard.GetComponent<Card>();
                if (sr != null)
                {   
                    sr.backSprite = cardBackSprite;
                    sr.frontSprite = listRandom[index];
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
            T Temp = list[i];
            list[i] = list[rand];
            list[rand] = Temp;
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
        yield return new WaitForSecond(1f);
        if (firstCard.frontSpirte == secondCard.frontSpirte)
        {
            firstCard.isMatched = true;
            secondCard.isMatched = true;
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
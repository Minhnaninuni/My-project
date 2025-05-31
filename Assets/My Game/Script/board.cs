
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Card Setup")]
    public GameObject card;
    public Transform cardParent;
    public Sprite cardBackSprite;
    public List<Sprite> listCard;

    [Header("Grid Setup")]
    public int rows = 4;
    public int cols = 4;
    public float spacingX = 2f;
    public float spacingY = 2f;
    public Vector2 pos = new Vector2(-6f, 3f);


    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void CreateGrid()
    {
        List<Sprite> ListRandom = new List<Sprite>();
        int pairCount = (rows * cols) / 2;

        for(int i  = 0; i < pairCount; i++)
        {
            Sprite Symbol = listCard[i];
            ListRandom.Add(Symbol);
            ListRandom.Add(Symbol);
        }
        ShuffleList(ListRandom);
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector2 position = new Vector2(
                    pos.x + j * spacingX,// -4 // -2 // 0
                    pos.y + i * spacingY// 3 //5
                    );
                GameObject newCard = Instantiate(card, position, Quaternion.identity, cardParent);
                Cards sr = newCard.GetComponent<Cards>();
                if (sr != null)
                {
                    sr.backSprite = cardBackSprite;
                    sr.frontSprite = ListRandom[index];
                }
                index++;
            }
        }

        
    }

    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i<list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            T Temp = list[i];
            list[i] = list[rand];
            list[rand] = Temp;
        }
    }


}
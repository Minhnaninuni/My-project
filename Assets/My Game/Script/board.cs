using UnityEngine;

public class board : MonoBehaviour
{
    [Header("Card Setup")]
    public GameObject card;
    public Transform cardParent;
    public Sprite cardBackSprite;

    [Header("Grid Setup")]
    public int rows = 4;
    public int cols = 4;
    public float spacingX = 2f;
    public float spacingY = 3f;
    public Vector2 pos = new Vector2(-6f, 3f);
    
    {
        
    }
    void Start()
    {
        CreateGrid()
    }

    void CreateGrid()
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Vector2 position = new Vector2(
                position.x + j * spacingX,
                position.y + i * spacingY
                );
        }
        GameObject newCard = Instantiate(newCard, position, Quaternion.indentity, cardParent);
        SpriteRenderer sr = newCard.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = cardBackSprite;
        }
    }
    }
}

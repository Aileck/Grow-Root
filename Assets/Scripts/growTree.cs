using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growTree : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite[] spriteArray;
    public int actualSprite = 0;
    // Start is called before the first frame update
   void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("HIIIIIIIIIII");
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        actualSprite++;
        spriteRenderer.sprite = spriteArray[actualSprite]; 
    }
}

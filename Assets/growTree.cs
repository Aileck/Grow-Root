using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growTree : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }
}

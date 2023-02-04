using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRoot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Down;
    public Sprite Shock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Down) {
            this.transform.Translate(new Vector2(0,-0.01f));
            this.GetComponent<SpriteRenderer>().sprite = Shock;
        }
    }
}

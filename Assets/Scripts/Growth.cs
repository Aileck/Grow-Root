using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    // Start is called before the first frame update
    bool Dead;
    bool Win;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
        {
            Color newColor = new Color(74f/255f, 54f/255f, 2f/255f);
            this.GetComponent<SpriteRenderer>().color = newColor;
        }
        else if (Win) {
            Color newColor = new Color(97f/255f, 70f/255f, 1f/255f);
            this.GetComponent<SpriteRenderer>().color = newColor;
        }
    }

    public void IsWin(bool iswin) {
        if (iswin)
        {
            Win = true;
        }
        else {
            Dead = true;
        }
    }
}

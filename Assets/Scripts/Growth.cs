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
            Color newColor = new Color(0.138f, 0.100f, 0.3f);
            this.GetComponent<SpriteRenderer>().color = newColor;
        }
        else if (Win) {
            Color newColor = new Color(0.97f, 0.70f, 0.1f);
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

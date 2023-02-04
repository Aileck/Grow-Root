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
            this.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else if (Win) {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
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

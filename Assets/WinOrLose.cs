using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLose : MonoBehaviour
{
    // Start is called before the first frame update
    bool win;
    bool lose;

    public GameObject panel;
    public Text bigText;
    public Text smallText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(win || lose) { 
            if (lose) {
                bigText.text = "Game Over";
                smallText.text = "The sapling can no longer grow.";
            }

            panel.SetActive(true);

       }
    }

    public void WonGame(bool win) {
        if (win)
        {
            this.win = true;
        }
        else {
            this.lose = true;
        }
    }
}

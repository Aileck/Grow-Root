using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLose : MonoBehaviour
{
    // Start is called before the first frame update
    bool win;
    bool lose;
    bool stack;

    public GameObject panel;
    public Text bigText;
    public Text smallText;

    public Image[] stars;

    LevelManager.Stars levelStar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(win || lose || stack) {
            if (lose)
            {
                bigText.text = "Game Over";
                smallText.text = "The sapling cannot grow.";
            }
            else if (stack)
            {
                bigText.text = "Game Over";
                smallText.text = "The road is completely blocked and the sapling cannot grow.";
            }
            else if (win) {
                Color op = stars[0].color;
                op.a = 1;

                if (levelStar == LevelManager.Stars.star1) {
                    stars[0].color = op;
                }
                else if (levelStar == LevelManager.Stars.star2)
                {
                    stars[0].color = op;
                    stars[1].color = op;
                }
                else if (levelStar == LevelManager.Stars.star3)
                {
                    stars[0].color = op;
                    stars[1].color = op;
                    stars[2].color = op;
                }
            }

            panel.SetActive(true);

       }
    }

    public void WonGame(bool win, LevelManager.Stars star, bool GameStacked = false) {
        if (win)
        {
            this.win = true;
            this.levelStar = star;
        }
        else if (stack)
        {
            this.stack = true;
        }
        else {
            this.lose = true;
        }
    }

    public void Stack() {
        this.stack = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public enum Stars {
        star1,
        star2,
        star3
    }
    // Start is called before the first frame update
    public AudioSource phase1;
    public AudioSource phase2;
    public AudioSource Vic;
    public AudioSource Lose;

    public GameObject root;
    public GameObject tree;

    GameObject score_label;
    GameObject length_label;
    public GameObject topTreshold;

    public WinOrLose GameOverCanvas;

    GameObject thisTree;

    Vector3 treePosition;

    public int waterToCollect = 5;
    int waterCollected;

    public float lengthRemain;

    public float star3;
    public float star2;
    public float star1;

    bool CheckStack;
    int StackCounter = 10;
    int CurentstackCounter = 0;

    float TotalStackTimer = 1;
    float CurrentStackTimer = 0;

    //sbool GameStacked = false;


    bool GameOver;
    void Start()
    {
        score_label = GameObject.FindGameObjectWithTag("Score");
        length_label = GameObject.FindGameObjectWithTag("Length");
        //phase1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckStack) {
            CurrentStackTimer += Time.deltaTime;

            if (CurrentStackTimer >= TotalStackTimer) {
                CurrentStackTimer = 0;
                CurentstackCounter = 0;
                CheckStack = false;
            }
            if (CurentstackCounter >= StackCounter) {
                //GameStacked = true;
                GameEnd();
                GameOverCanvas.Stack();
                Lose.Play();
            }
        }

        if (!GameOver) {
            UpdateLabel();
            Stars s = RateStar();
            if (lengthRemain <= 0)
            {
                GameEnd();
                GameOverCanvas.WonGame(false, s);
                Lose.Play();

            }
            else if ((waterToCollect - waterCollected) == 0)
            {
                GameEnd();
                GameOverCanvas.WonGame(true,s);
                Vic.Play();


            }


        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

    }

    void GameEnd() {
        GameOver = true;
        phase2.Stop();
        //length_label.GetComponent<Text>().text = "";
        //score_label.GetComponent<Text>().text = "";
    }

    public void Initiate(Vector3 treePosition)
    {
        phase1.Stop();
        Instantiate(topTreshold, new Vector3(0,3.95f,0), Quaternion.identity);
        this.treePosition = treePosition;
        Instantiate(root, treePosition, Quaternion.identity);
        thisTree = Instantiate(tree, treePosition + new Vector3(0,3f,0), Quaternion.identity) as GameObject;
        phase2.Play();
    }

    public void Initiate()
    {
        if (!GameOver)
        {
            Instantiate(root, treePosition, Quaternion.identity);
            if (CheckStack == false)
            {
                CheckStack = true;
            }
            else
            {
                CurentstackCounter++;
            }
        }
    }

    public void _NotiWaterCollected() {

        if (!GameOver) {
            waterCollected++;
            thisTree.GetComponent<growTree>().Grow();
        }
    }

    public void UpdateLabel() {
        score_label.GetComponent<Text>().text =  "Water needed: " + (waterToCollect - waterCollected).ToString();
        length_label.GetComponent<Text>().text = "Length: " +  lengthRemain.ToString("F2") + "m";

        if (GameObject.FindGameObjectWithTag("ScoreSmall")) {
            GameObject.FindGameObjectWithTag("ScoreSmall").GetComponent<Text>().text = lengthRemain.ToString("F1");
        }

    }

    Stars RateStar() {
        Stars res = Stars.star1;
        if (lengthRemain > star2) {
            res = Stars.star2;
        }
        if (lengthRemain >= star3) {
            res = Stars.star3;
        }
        return res;
    }
}

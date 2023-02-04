using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject root;
    public GameObject tree;

    public GameObject score_label;
    public GameObject length_label;
    public GameObject topTreshold;

    GameObject thisTree;

    public Vector3 treePosition;

    


    public int waterToCollect = 5;
    int waterCollected;

    public float lengthRemain;

    bool GameOver;
    void Start()
    {
        score_label = GameObject.FindGameObjectWithTag("Score");
        length_label = GameObject.FindGameObjectWithTag("Length");
    }

    // Update is called once per frame
    void Update()
    {


        if (!GameOver) {
            UpdateLabel();

            if (lengthRemain <= 0)
            {
                GameEnd();

            }
            else if ((waterToCollect - waterCollected) == 0)
            {
                GameEnd();
            }


        }


    }

    void GameEnd() {
        GameOver = true;
        length_label.GetComponent<Text>().text = "";
        score_label.GetComponent<Text>().text = "";
    }

    public void Initiate(Vector3 treePosition)
    {
        Instantiate(topTreshold, new Vector3(0,3.95f,0), Quaternion.identity);
        this.treePosition = treePosition;
        Instantiate(root, treePosition, Quaternion.identity);
        thisTree = Instantiate(tree, treePosition + new Vector3(0,3f,0), Quaternion.identity) as GameObject;
    }

    public void Initiate()
    {
        Instantiate(root, treePosition, Quaternion.identity);
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

    }
}

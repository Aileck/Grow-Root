using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject root;
    public GameObject tree;

    public GameObject score_label;
    public GameObject length_label;

    GameObject thisTree;

    public Vector3 treePosition;


    public int waterToCollect = 5;
    public int waterCollected;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Initiate(Vector3 treePosition)
    {
        this.treePosition = treePosition;
        Instantiate(root, treePosition, Quaternion.identity);
        thisTree = Instantiate(tree, treePosition + new Vector3(0,3f,0), Quaternion.identity) as GameObject;
    }

    public void Initiate()
    {
        Instantiate(root, treePosition, Quaternion.identity);
    }

    public void _NotiWaterCollected() {
        waterCollected++;
        thisTree.GetComponent<growTree>().Grow();
    }
}

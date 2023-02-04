using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject root;
    public Vector3 treePosition;
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
    }

    public void Initiate()
    {
        Instantiate(root, treePosition, Quaternion.identity);
    }
}

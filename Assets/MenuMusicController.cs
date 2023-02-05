using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            if (GameObject.FindGameObjectsWithTag("MenuMusic").Length > 1)
            {
                Destroy(GameObject.FindGameObjectsWithTag("MenuMusic")[1]);
            };
        
    }
}

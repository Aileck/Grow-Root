using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftBehaviour : MonoBehaviour
{

    float rightBoundary = 10.0f;
    float leftBoundary = -10.0f;
    bool rightDirection = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rightDirection)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
            if (transform.position.x > rightBoundary)
            {
                rightDirection = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime);
            if (transform.position.x < leftBoundary)
            {
                rightDirection = true;
            }
        }



        //transform.Translate(Vector2.left * Time.deltaTime);
    }
}

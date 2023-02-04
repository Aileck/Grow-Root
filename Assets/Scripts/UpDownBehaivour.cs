using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBehaivour : MonoBehaviour
{
    float topBoundary = 2.0f;
    float lowBoundary = -4.0f;
    bool upDirection = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (upDirection)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
            if (transform.position.y > topBoundary)
            {
                this.GetComponent<SpriteRenderer>().flipY = true;
                upDirection = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * Time.deltaTime);
            if (transform.position.y < lowBoundary)
            {
                this.GetComponent<SpriteRenderer>().flipY = false;
                upDirection = true;
            }
        }
    }
}

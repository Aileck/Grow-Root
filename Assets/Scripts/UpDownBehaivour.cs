using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpDownBehaivour : MonoBehaviour
{
    float topBoundary = 2.0f;
    float lowBoundary = -4.0f;
    bool upDirection = true;

    public bool hard;
    public bool following;

    public float followSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        if (hard) {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (following) {
            var step = Random.Range(1,followSpeed) * Time.deltaTime; // calculate distance to move

            try
            {
                if (GameObject.FindGameObjectWithTag("GrowRoot")) {
                    Transform destination = GameObject.FindGameObjectWithTag("GrowRoot").gameObject.transform;
                    if (destination != null)
                    {
                        float distance = Vector3.Distance(transform.position, destination.position);
                        transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
                    }
                }

            }
            catch (MissingReferenceException ex)
            {
       
            }


        }

        else if (upDirection)
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("UAA");
        if (this.hard && collision.tag == "Root")
        {
            following = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("UAA");
        if (this.hard && collision.tag == "Root")
        {
            following = true;
        }
    }
}

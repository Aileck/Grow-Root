using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handMovement : MonoBehaviour
{
    Animator animator;
    public float speed = 1;
    public GameObject preRoot;
    public AudioSource audioData;

    float rightBoundary = 13.0f;
    float leftBoundary = -13.0f;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float handSpeed = Input.GetAxis("Horizontal") * speed;
        
        
            if(this.transform.position.x > leftBoundary && this.transform.position.x < rightBoundary) {
                if (handSpeed != 0)
                {
                    this.transform.Translate(new Vector2(handSpeed, 0));
                 }
            }

            if (this.transform.position.x <= leftBoundary) {
                if (handSpeed > 0)
                    {
                        this.transform.Translate(new Vector2(handSpeed, 0));
                    }
            }
            if (this.transform.position.x >= rightBoundary)
            {
                if (handSpeed < 0)
                {
                    this.transform.Translate(new Vector2(handSpeed, 0));
                }
            }
    

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            audioData.Play();
            preRoot.GetComponent<PreRoot>().Down = true;
            animator.Play("Throwingseed");
            //animator.SetBool("throw", true);
            Destroy(this.gameObject,1.5f);
            Destroy(this);
        }
        //if (transform.position.x < 0)
        //    transform.Translate(Vector2.right * Time.deltaTime * 2);
        //else{
        //    animator.SetBool("throw", true);
        //}
    }
}

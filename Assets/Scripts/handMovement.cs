using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handMovement : MonoBehaviour
{
    Animator animator;
    public float speed = 1;
    public GameObject preRoot;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float handSpeed = Input.GetAxis("Horizontal") * speed;
        
        if (handSpeed != 0) {
            this.transform.Translate(new Vector2(handSpeed,0));
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            preRoot.GetComponent<PreRoot>().Down = true;
        }
        //if (transform.position.x < 0)
        //    transform.Translate(Vector2.right * Time.deltaTime * 2);
        //else{
        //    animator.SetBool("throw", true);
        //}
    }
}

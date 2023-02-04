using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handMovement : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0)
            transform.Translate(Vector2.right * Time.deltaTime * 2);
        else{
            animator.SetBool("throw", true);
        }
    }
}

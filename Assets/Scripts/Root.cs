using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    bool isNew = false;
    public GameObject rootSprite;
    public GameObject rootHolder;

    public float tiltAngle = 180.0f;

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 5.0f;

    public bool isDead = false;
    Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false) { 
                this.transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
                GameObject newRoot = Instantiate(rootSprite) ;
                newRoot.transform.position = this.transform.position;
                newRoot.transform.parent = rootHolder.transform;

        
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        transform.RotateAround(transform.position, transform.up, -rotationSpeed * Time.deltaTime);
                    }

                    transform.Rotate(0,0, Input.GetAxis("Horizontal") * tiltAngle * Time.deltaTime * rotationSpeed);
                    //transform.RotateAround(this);
                    //float translation = Input.GetAxis("Horizontal") * tiltAngle;
                    //Quaternion target = Quaternion.Euler(0, 0, translation);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
                }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter to compare object");
        if (other.gameObject.tag == "Mole")
        {

            Debug.Log("DESTROYED");
            anim.Play("Fall");
            //Destroy(this.gameObject);
            isDead = true;
        }
    }
}

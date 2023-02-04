using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    bool isNew = false;
    public GameObject rootSprite;

    public float tiltAngle = 180.0f;

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        GameObject newRoot = Instantiate(rootSprite) ;
        newRoot.transform.position = this.transform.position;

        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            float translation = Input.GetAxis("Horizontal") * tiltAngle;
            Quaternion target = Quaternion.Euler(0, 0, translation);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
        }
    }

    void Initialize() {
        this.isNew = true;
    }
}

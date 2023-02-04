using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootCollider : MonoBehaviour
{
    public Transform Root;
    // Start is called before the first frame update
    void Start()
    {
        Transform root = Instantiate(Root) as Transform;
        Physics.IgnoreCollision(root.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter to compare object");
        if (other.gameObject.tag == "Mole")
        {
            Debug.Log("DESTROYED");
            Destroy(this.gameObject);
        }
    }
}

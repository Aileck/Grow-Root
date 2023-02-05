using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRoot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Down;
    public Sprite Shock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Down) {
            this.transform.Translate(new Vector2(0,-0.01f));
            this.GetComponent<SpriteRenderer>().sprite = Shock;
            this.transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("Initiate");
            FindObjectOfType<LevelManager>().Initiate(this.transform.position);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}

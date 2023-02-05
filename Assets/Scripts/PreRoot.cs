using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRoot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Down;
    public AudioSource audioData;
    public Sprite Shock;
    public bool played = false;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Down) {
            played = true;
            this.transform.Translate(new Vector2(0,-0.01f));
            this.GetComponent<SpriteRenderer>().sprite = Shock;
            this.transform.parent = null;
        }
        if(played){
            audioData.Play();
            played = false;
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

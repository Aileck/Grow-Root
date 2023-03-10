using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    bool isNew = false;
    public GameObject rootSprite;
    public GameObject rootHolder;
    GameObject thisRootHolder;

    public float tiltAngle = 180.0f;

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 5.0f;

    public bool isDead = false;
    public bool isWin = false;
    Animator anim;
    float currCountdownValue;
    int boostTime = 2;

    List<GameObject> roots = new List<GameObject>();
    void Start()
    {
        anim = this.GetComponent<Animator>();
        thisRootHolder = Instantiate(rootHolder) as GameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead || isWin)
        {
            FindObjectOfType<LevelManager>().Initiate();
            Destroy(this);

        }
        else
        {
            this.transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
            GameObject newRoot = Instantiate(rootSprite);
            roots.Add(newRoot);
            FindObjectOfType<LevelManager>().lengthRemain -= 0.001f;

            newRoot.transform.position = this.transform.position;
            newRoot.transform.parent = thisRootHolder.transform;


            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.RotateAround(transform.position, transform.up, -rotationSpeed * Time.deltaTime);
                }

                transform.Rotate(0, 0, Input.GetAxis("Horizontal") * tiltAngle * Time.deltaTime * rotationSpeed);
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
        if (other.gameObject.tag == "Mole" || other.gameObject.tag == "outsideWorld")
        {

            Debug.Log("Mi assesino es: " + other.gameObject.tag);
            anim.Play("Fall");
            //Destroy(this.gameObject);
            isDead = true;
            this.gameObject.tag = "Untagged";
            RootChangeColor();
            FindObjectOfType<LevelManager>().lengthRemain -= 0.1f;

            GetComponentInChildren<Canvas>().gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Water")
        {
            Debug.Log("Sleeping");
            anim.Play("Sleep");
            this.gameObject.tag = "Untagged";
            Destroy(other.gameObject);
            isWin = true;
            RootChangeColor();
            //isDead = true;

            FindObjectOfType<LevelManager>()._NotiWaterCollected();
            FindObjectOfType<LevelManager>().lengthRemain += 0.15f;

            GetComponentInChildren<Canvas>().gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Thunder")
        {
            Destroy(other.gameObject);
            StartCoroutine(StartCountdown());
            FindObjectOfType<LevelManager>().lengthRemain += 0.15f;
        }
    }

    void RootChangeColor()
    {
        if (isDead)
        {
            foreach (GameObject root in roots)
            {
                root.GetComponent<Growth>().IsWin(false);
            }
        }
        else if (isWin)
        {
            foreach (GameObject root in roots)
            {
                root.GetComponent<Growth>().IsWin(true);
            }
        }
    }

    public IEnumerator StartCountdown(float countdownValue = 4)
    {
        moveSpeed = 4.0f;
        yield return new WaitForSeconds(2.0f);
        moveSpeed = 1.0f;
    }
}

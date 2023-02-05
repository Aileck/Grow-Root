using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel1() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Test4");
    }

    public void LoadLevel(string level)
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }

    public void LoadMenu(bool dontchangemusic = false)
    {
        if (dontchangemusic)
        {
            if (GameObject.FindGameObjectWithTag("MenuMusic")) {
                DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MenuMusic"));
            };
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public void LoadCredit()
    {

            if (GameObject.FindGameObjectWithTag("MenuMusic"))
            {
                DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MenuMusic"));
            };

        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }
    public void LoadInstr()
    {

            if (GameObject.FindGameObjectWithTag("MenuMusic"))
            {
                DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MenuMusic"));
            };

        UnityEngine.SceneManagement.SceneManager.LoadScene("Instr");
    }
    public void Exit()
    {
        Application.Quit();

    }
}

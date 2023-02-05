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

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();

    }
}

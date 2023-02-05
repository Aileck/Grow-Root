using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] paneles;
    public int currentPage;
    void Start()
    {
        currentPage = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DownPage()
    {
        if (currentPage != paneles.Length - 1)
        {
            paneles[currentPage].SetActive(false);
            paneles[currentPage + 1].SetActive(true);
            currentPage += 1;
        }

    }

    public void UpPage()
    {

            paneles[currentPage].SetActive(false);
            paneles[currentPage - 1].SetActive(true);
            currentPage -= 1;


    }
}

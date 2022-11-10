using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject castle1;
    public GameObject castle2;
    public GameObject castle3;
    public GameObject castle4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (castle1.transform.tag == "Good" && castle2.transform.tag == "Good" && castle3.transform.tag == "Good" && castle4.transform.tag == "Good")
        {
            SceneManager.LoadScene("YouWon");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int LoseHearts;

    public Text TextHearts;

    public GameObject RestartGameText;
    public GameObject WinScreenText;
  

    void Start()
    {
        RestartGameText.SetActive(false);
        LoseHearts = 3;
        //TextHearts.text = "3";
    }

    void Update()
    {
        PlayerHearts();
        TextHearts.text = "Player Hearts: " + LoseHearts.ToString();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    } 

    public void PlayerHearts()
    {
        if (LoseHearts == 0)
        {
            RestartGameText.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Door3")
        {
            WinScreenText.SetActive(true);
            SceneManager.LoadScene (0);
        }
    }

    
}

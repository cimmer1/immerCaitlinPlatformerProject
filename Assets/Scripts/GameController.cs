
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int LoseHearts;

    public Text TextHearts;

    public GameObject RestartGameText;
    public GameObject Rock;

    void Start()
    {
        //InvokeRepeating("SpawnRock", );
        LoseHearts = 3;
        TextHearts.text = "3";
    }

    void Update()
    {
        PlayerHearts();
        TextHearts.text = LoseHearts.ToString();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }


    public void SpawnMeteor()
    {
        //Vector2 randomSpawnPosition = new Vector2(Random.Range(0, 0), Random.Range(0, 0));
        //Instantiate(Rock, randomSpawnPosition, Quaternion.identity);
    }

    public void PlayerHearts()
    {
        if (LoseHearts == 0)
        {
            RestartGameText.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }

    
}

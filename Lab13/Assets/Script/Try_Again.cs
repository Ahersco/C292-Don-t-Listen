using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class Try_Again : MonoBehaviour
{
    private Game_Manager gm;
    public static bool beat6 = false;

    void Awake()
    {
        gm = FindObjectOfType<Game_Manager>();

        // Safety check
        if (gm == null)
        {
            Debug.LogError("Game_Manager not found in scene!");
        }
    }

    void Start()
    {
            gm.StopTimer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (beat6 == true)
            {
                SceneManager.LoadScene("Level1 w Skip");
            }
            else
            {
                SceneManager.LoadScene("Level1");
            }
        }

        if (beat6 == true)
        {
            Debug.Log("can go to skip");
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;


public class Try_Again : MonoBehaviour
{

    private Game_Manager gm;   
    public static bool beat6 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindObjectOfType<Game_Manager>();
        gm.StopTimer(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (beat6 == true)
            {
                SceneManager.LoadScene("Level1 w Skip");
                gm.AddDeath();
                gm.StartTimer();
            }
            else
            {
                SceneManager.LoadScene("Level1");
                gm.AddDeath();
                gm.StartTimer();
            }
        }

        if (beat6 == true)
        {
            Debug.Log("can go to skip");
        }

    }
}

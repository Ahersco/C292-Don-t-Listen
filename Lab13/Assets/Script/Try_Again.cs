using UnityEngine;
using UnityEngine.SceneManagement;


public class Try_Again : MonoBehaviour
{

    public static bool beat6 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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

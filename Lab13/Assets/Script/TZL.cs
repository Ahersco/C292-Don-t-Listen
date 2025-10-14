using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_Zone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int x = 1;
        SceneManager.LoadScene("Level" + (x + 1));
    }
}

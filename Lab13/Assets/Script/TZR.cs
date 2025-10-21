using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TZR : MonoBehaviour
{
    [SerializeField] String nextScene;
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
        SceneManager.LoadScene(nextScene);
    }

}

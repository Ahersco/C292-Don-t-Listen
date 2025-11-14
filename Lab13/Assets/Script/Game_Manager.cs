using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private TextMeshProUGUI deathCounterText;
    private float timer = 0f;
    private int deaths = 0;
    private bool isGameRunning = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        FindUIElements();
        StartTimer();
    }

    void Update()
    {
        if (isGameRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    // Find UI elements in the current scene
    private void FindUIElements()
    {
        GameObject timerObject = GameObject.Find("Timer");
        GameObject deathObject = GameObject.Find("Death Counter");

        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<TextMeshProUGUI>();
        }

        if (deathObject != null)
        {
            deathCounterText = deathObject.GetComponent<TextMeshProUGUI>();
        }

        if (timerText != null && deathCounterText != null)
        {
            UpdateTimerUI();
            deathCounterText.text = $"Deaths: {deaths}";
        }
    }

    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        FindUIElements();
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time: {Math.Floor(timer * 100) / 100}";
        }
    }

    public void AddDeath()
    {
        deaths++;
        if (deathCounterText != null)
        {
            deathCounterText.text = $"Deaths: {deaths}";
        }
    }

    public void StopTimer()
    {
        isGameRunning = false;
    }

    public void StartTimer()
    {
        isGameRunning = true;
    }

    public void ResetGame()
    {
        timer = 0f;
        deaths = 0;
        isGameRunning = false;
        UpdateTimerUI();
        if (deathCounterText != null)
        {
            deathCounterText.text = $"Deaths: {deaths}";
        }
    }
}

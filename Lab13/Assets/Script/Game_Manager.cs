using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI deathCounterText;
    private float timer = 0f;
    private int deaths = 0;
    private bool isGameRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerUI();
        }
    }
    private void UpdateTimerUI()
    {
        timerText.text = $"Time: {timer: F2}";
    }

    public void AddDeath()
    {
        deaths++;
        deathCounterText.text = $"Deaths: {deaths}";
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
        isGameRunning = true;
        UpdateTimerUI();
        deathCounterText.text = $"Deaths: {deaths}";
    }
}

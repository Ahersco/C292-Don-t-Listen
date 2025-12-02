using UnityEngine;
using UnityEngine.SceneManagement;

public class platform_script : MonoBehaviour
{
    [SerializeField] float speedy;
    [SerializeField] float speedx;
    [SerializeField] float x;
    public bool isMoving;
    [SerializeField] bool Xaxis;
    [SerializeField] bool Yaxis;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level8")
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                speedy = speedy * 4;
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                speedy = speedy / 4;
            }
        }
        if (isMoving == true)
        {
            if (Xaxis == true)
            {
                transform.Translate(Vector2.left * speedx * Time.deltaTime);
            }
            if (Yaxis == true)
            {
                transform.Translate(Vector2.down * speedy * Time.deltaTime);
            }
        }
        if (transform.position.x <= x && Xaxis == true)
        {
            isMoving = false;
        }
    }
    
    
}

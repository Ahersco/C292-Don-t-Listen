using UnityEngine;
using UnityEngine.SceneManagement;

public class platform_script : MonoBehaviour
{
    [SerializeField] float speed2;
    [SerializeField] float speed;
    [SerializeField] float x;
    [SerializeField] float y;
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
                speed2 = speed2 * 4;
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                speed2 = speed2 / 4;
            }
        }
        if (isMoving == true)
        {
            Debug.Log("moving");

            if (Xaxis == true)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (Yaxis == true)
            {
                transform.Translate(Vector2.down * speed2 * Time.deltaTime);
            }
        }
        if (transform.position.x <= x && Xaxis == true)
        {
            isMoving = false;
        }

        if (transform.position.y <= y && Yaxis == true)
        {
            isMoving = false;
        }
    }
    
    
}

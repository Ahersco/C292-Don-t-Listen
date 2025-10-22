using UnityEngine;

public class platform_script : MonoBehaviour
{
    [SerializeField] float speed2;
    [SerializeField] float x;
    public bool isMoving;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            transform.Translate(Vector2.left * speed2 * Time.deltaTime);
        }
        if (transform.position.x <= x)
            isMoving = false;
    }
    
    
}

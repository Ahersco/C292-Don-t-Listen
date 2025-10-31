using UnityEngine;

public class Bob : MonoBehaviour
{
    [SerializeField] float speed2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(-x, 0);
        transform.Translate(moveVector * speed2 * Time.deltaTime);
    }
}

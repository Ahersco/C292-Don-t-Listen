using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    [SerializeField] float JumpForce;
    [SerializeField] float speed2;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject Button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Button.activeSelf == false)
        {
            float x = Input.GetAxis("Horizontal");
            Vector2 moveVector = new Vector2(x, 0);
            transform.Translate(moveVector * speed2 * Time.deltaTime);

            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            }
        }
        
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Button.SetActive(true);
        }
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(collision.gameObject);
            Button.SetActive(true);
        }
        if (collision.gameObject.tag == "Trigger_Zone_Left")
        {
            Debug.Log("move camera");
        }
    }
}

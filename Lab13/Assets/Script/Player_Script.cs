using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    [SerializeField] float JumpForce;
    [SerializeField] float speed2;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject Platform;
    [SerializeField] AudioSource Jump;
    [SerializeField] AudioSource Death;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(x, 0);
        transform.Translate(moveVector * speed2 * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            Jump.Play();
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Game Over");
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Game Over");
        }
        if (collision.gameObject.tag == "Trigger_Zone_Left")
        {
            Debug.Log("move camera");
        }
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("works");
            Platform.GetComponent<platform_script>().isMoving = true;
        }
    }
}

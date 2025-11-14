using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    [SerializeField] float JumpForce;
    [SerializeField] float speed2;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] AudioSource Jump;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] GameObject Platform;
    private bool isGrounded;
    public static bool beat6 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();

        if (SceneManager.GetActiveScene().name == "Level6")
        {
            float y = Input.GetAxis("Horizontal");
            Vector2 movevector = new Vector2(-y, 0);
            transform.Translate(movevector * speed2 * Time.deltaTime);
        }
        else
        {
            float x = Input.GetAxis("Horizontal");
            Vector2 moveVector = new Vector2(x, 0);
            transform.Translate(moveVector * speed2 * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump.Play();
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            
        }
        
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Game_Manager gm = FindObjectOfType<Game_Manager>();
            if (gm != null)
            {
                gm.AddDeath();
            }
            if (beat6 == true)
            {
                SceneManager.LoadScene("Level1 w Skip");
            }
            else
            {
                SceneManager.LoadScene("Level1");
            }
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

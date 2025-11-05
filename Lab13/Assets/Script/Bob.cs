using UnityEngine;
using UnityEngine.SceneManagement;

public class Bob : MonoBehaviour
{
    [SerializeField] float JumpForce;
    [SerializeField] float speed2;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float groundCheckDistance = 0.2f;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        float x = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(-x, 0);
        transform.Translate(moveVector * speed2 * Time.deltaTime);

        if (SceneManager.GetActiveScene().name == "Level5")
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            }
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}

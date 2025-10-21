using UnityEngine;

public class PlayerMovementPlat : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;       // velocidade normal
    public float runSpeed = 8f;        // velocidade correndo
    private float currentSpeed;

    [Header("Pulo")]
    public float jumpForce = 10f;
    private bool isGrounded;

    [Header("Checagem de ch�o")]
    public Transform groundCheck;      // empty object embaixo do player
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // --- MOVIMENTO HORIZONTAL ---
        float moveInput = Input.GetAxisRaw("Horizontal");

        // checa se est� correndo (Shift Esquerdo pressionado)
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = runSpeed;
        else
            currentSpeed = moveSpeed;

        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);

        // --- PULO ---
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // --- FLIPAR SPRITE (virar personagem) ---
        if (moveInput > 0)
            transform.localScale = new Vector3(2, 2, 2);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-2, 2, 2);
    }

    // visualizar raio do groundCheck
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}

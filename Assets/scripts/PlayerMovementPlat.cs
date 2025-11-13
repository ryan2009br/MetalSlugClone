using UnityEngine;

public class PlayerMovementPlat : MonoBehaviour
{
    //==============================================================
    // CONFIGURAÇÕES PÚBLICAS
    //==============================================================
    [Header("Configurações de Movimento")]
    public float speed = 8f;            // Velocidade de movimento horizontal
    public float jumpForce = 14f;       // Força do pulo

    [Header("Detecção de Chão")]
    public Transform groundCheck;       // Ponto que detecta o chão
    public float groundRadius = 0.1f;   // Raio da detecção
    public LayerMask groundLayer;       // Camada considerada como chão

    //==============================================================
    // VARIÁVEIS PRIVADAS
    //==============================================================
    Rigidbody2D rb;                     // Referência ao Rigidbody2D do player
    bool isGrounded;                    // Indica se o player está tocando o chão

    //==============================================================
    // INICIALIZAÇÃO
    //==============================================================
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o Rigidbody2D automaticamente
    }

    //==============================================================
    // ATUALIZAÇÃO PRINCIPAL
    //==============================================================
    void Update()
    {
        //----------------------------------------------------------
        // 1 - DETECTAR SE ESTÁ NO CHÃO
        //----------------------------------------------------------
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        //----------------------------------------------------------
        // 2 - MOVIMENTO HORIZONTAL
        //----------------------------------------------------------
        float moveInput = Input.GetAxisRaw("Horizontal"); // A/D ou setas

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        //----------------------------------------------------------
        // 3 - PULO
        //----------------------------------------------------------
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    //==============================================================
    // VISUALIZAÇÃO NO EDITOR (DEBUG)
    //==============================================================
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}
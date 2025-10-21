using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;

    [Header("Rota��o")]
    public float rotationSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura das entradas de movimento (WASD / Setas)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Normaliza para evitar velocidade maior na diagonal
        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Movimento do player
        rb.linearVelocity = movement * moveSpeed;

        // Se estiver se movendo, rotaciona suavemente
        if (movement != Vector2.zero)
        {
            // Calcula o �ngulo da dire��o do movimento
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

            // Rota��o suave at� o �ngulo alvo
            float angle = Mathf.LerpAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);

            rb.MoveRotation(angle);
        }
    }
}

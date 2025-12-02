using UnityEngine;

public class PlayerMovementPlat8D : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float speed = 8f;
    public float jumpForce = 14f;

    Rigidbody2D rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Entradas
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical"); // usado só no ar

        Vector3 movement = new Vector3(moveX, moveY).normalized;
        rb.linearVelocity = movement * speed;

    }
}

using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Configurações do projétil")]
    public float speed = 10f;      // velocidade do projétil
    public float lifeTime = 3f;    // tempo até ser destruído automaticamente
    public bool usePhysics = false; // usar Rigidbody ou não

    private Rigidbody2D rb;

    void Start()
    {
        // destrói o projétil depois de um tempo (pra não ficar acumulando na cena)
        Destroy(gameObject, lifeTime);

        if (usePhysics)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = transform.right * speed; // move no eixo "frente" (direita local)
        }
    }

    void Update()
    {
        // se não estiver usando Rigidbody, move manualmente
        if (!usePhysics)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    // exemplo de colisão (opcional)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destrói ao colidir (ou troque por seu próprio comportamento)
        Destroy(gameObject);
    }
}

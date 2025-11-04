using UnityEngine;

public class GunFollow : MonoBehaviour
{
    [Header("Referências")]
    public Transform player; // corpo do jogador
    public Transform firePoint; // ponto onde o projétil nasce
    public GameObject projectilePrefab; // prefab da bala

    [Header("Configurações")]
    public float projectileSpeed = 10f;
    public float verticalLimit = 60f; // limite da rotação vertical

    private bool facingRight = true;

    void Update()
    {
        AimAtMouse();

        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void AimAtMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Se o mouse atravessar para o outro lado → vira o player e a arma
        if ((facingRight && direction.x < 0) || (!facingRight && direction.x > 0))
        {
            Flip();
        }

        // Rotação da arma limitada verticalmente
        if (facingRight)
        {
            angle = Mathf.Clamp(angle, -verticalLimit, verticalLimit);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            angle = Mathf.Clamp(angle, -verticalLimit, verticalLimit);
            transform.rotation = Quaternion.Euler(0, 0, 180 - angle);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Espelha o jogador
        Vector3 playerScale = player.localScale;
        playerScale.x *= -1;
        player.localScale = playerScale;

        // Espelha a arma no eixo Y para corrigir a orientação
        Vector3 gunScale = transform.localScale;
        gunScale.y *= -1;
        transform.localScale = gunScale;
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
            return;

        // Cria o projétil
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Faz a bala ir na direção certa (dependendo do lado que o jogador olha)
            rb.velocity = firePoint.right * projectileSpeed;
        }
    }
}

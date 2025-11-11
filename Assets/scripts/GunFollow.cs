using UnityEngine;

public class GunFollow : MonoBehaviour
{
    [Header("Referências")]
    public Transform player;           // corpo do jogador
    public Transform gunSprite;        // sprite da arma
    public Transform firePoint;        // ponto onde o projétil nasce
    public GameObject projectilePrefab;

    [Header("Configurações")]
    public float projectileSpeed = 10f;
    public float verticalLimit = 60f;

    private PlayerMovementPlat playerMovement;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovementPlat>();
    }

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

        bool facingRight = playerMovement.facingRight;

        // --- FLIP AUTOMÁTICO QUANDO O MOUSE MUDA DE LADO ---
        if ((facingRight && direction.x < 0) || (!facingRight && direction.x > 0))
        {
            playerMovement.Flip();
            facingRight = playerMovement.facingRight;
        }

        // --- ROTACIONA O PIVOT (arma segue o mouse) ---
        if (facingRight)
        {
            angle = Mathf.Clamp(angle, -verticalLimit, verticalLimit);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            gunSprite.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            // espelha corretamente
            angle = Mathf.Clamp(angle, -verticalLimit, verticalLimit);
            transform.rotation = Quaternion.Euler(0, 0, 180 - angle);
            gunSprite.localScale = new Vector3(1, -1, 1);
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
            return;

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.velocity = firePoint.right * projectileSpeed;
    }
}

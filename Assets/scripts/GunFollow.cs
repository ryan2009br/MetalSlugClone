using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    public Transform characterTransform; // referência ao corpo do personagem
    public float minAngle = -60f; // ângulo mínimo de rotação
    public float maxAngle = 60f;  // ângulo máximo de rotação

    private bool facingRight = true;

    void Update()
    {
        UpdateFacing();
        AimAtMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void UpdateFacing()
    {
        // Detecta se o personagem virou com base na escala X (ajuste se usa flipX ou rotação)
        if (characterTransform.localScale.x > 0)
            facingRight = true;
        else
            facingRight = false;
    }

    void AimAtMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (!facingRight)
        {
            // Inverte o ângulo se estiver virado para a esquerda
            angle = 180 - angle;
        }

        // Limita o ângulo
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        // Aplica rotação
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * projectileSpeed;
    }
}

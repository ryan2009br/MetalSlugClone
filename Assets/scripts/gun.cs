using UnityEngine;

public class gun : MonoBehaviour
{
    //==============================================================
    // CONFIGURAÇÕES PÚBLICAS
    //==============================================================
    [Header("Configurações da Arma")]
    public GameObject bulletPrefab;     // Prefab da bala
    public Transform firePoint;         // Ponto de disparo
    public float bulletSpeed = 10f;     // Velocidade da bala
    public Transform player;            // Referência ao player (para futuros usos)
    public Rigidbody2D playerRb;        // Referência ao Rigidbody2D do player
    public float rotationSpeed = 10f;   // Velocidade de rotação da arma

    //==============================================================
    // ATUALIZAÇÃO PRINCIPAL
    //==============================================================
    void Update()
    {
        //----------------------------------------------------------
        // 1 - ROTACIONAR A ARMA EM DIREÇÃO AO MOUSE
        //----------------------------------------------------------
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotação suave da arma
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);

        //----------------------------------------------------------
        // 2 - DISPARO
        //----------------------------------------------------------
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    //==============================================================
    // MÉTODO DE DISPARO
    //==============================================================
    void Shoot()
    {
        // Instancia a bala
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Aplica velocidade à bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed;
    }
}
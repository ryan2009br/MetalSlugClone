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
    public float orbitDistance = 2f;    // Distância da arma ao redor do jogador
    public float rotationSpeed = 10f;   // Velocidade de rotação da arma

    private Camera cam;                 // Referência à câmera principal

    //==============================================================
    // INICIALIZAÇÃO
    //==============================================================
    void Start()
    {
        cam = Camera.main;  // Pega a câmera principal
    }

    //==============================================================
    // ATUALIZAÇÃO PRINCIPAL
    //==============================================================
    void Update()
    {
        //----------------------------------------------------------
        // 1 - CALCULAR A POSIÇÃO DO MOUSE NO MUNDO
        //----------------------------------------------------------
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;  // Z deve ser 0 para manter no plano 2D

        // Direção do mouse em relação ao jogador
        Vector3 dirToMouse = mousePos - player.position;
        dirToMouse.Normalize();

        // Posição da arma ao redor do jogador
        Vector3 targetPosition = player.position + dirToMouse * orbitDistance;

        // Movimento suave da arma em torno do jogador
        transform.position = Vector3.Lerp(transform.position, targetPosition, rotationSpeed * Time.deltaTime);

        //----------------------------------------------------------
        // 2 - ROTACIONAR A ARMA EM DIREÇÃO AO MOUSE
        //----------------------------------------------------------
        float angle = Mathf.Atan2(dirToMouse.y, dirToMouse.x) * Mathf.Rad2Deg;

        // Rotação suave da arma
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);

        //----------------------------------------------------------
        // 3 - DISPARO
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
        rb.velocity = firePoint.right * bulletSpeed; // Correção: use velocity em vez de linearVelocity
    }
}

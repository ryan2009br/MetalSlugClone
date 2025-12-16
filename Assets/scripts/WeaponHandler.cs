using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform player;    // Referência ao jogador
    public Camera cam;          // Referência à câmera principal

    void Update()
    {
        // Pega a posição do mouse no mundo
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;  // Z deve ser 0 para manter no plano 2D

        // Calcula a direção do mouse em relação ao jogador
        Vector3 dirToMouse = mousePos - player.position;

        // Calcula o ângulo entre o jogador e o mouse
        float angle = Mathf.Atan2(dirToMouse.y, dirToMouse.x) * Mathf.Rad2Deg;

        // Opcional: quantiza para 8 direções (caso você queira limitar a rotação do personagem)
        float snappedAngle = Mathf.Round(angle / 45f) * 45f;

        // Aplica a rotação no jogador
        player.rotation = Quaternion.Euler(0, 0, snappedAngle);
    }
}

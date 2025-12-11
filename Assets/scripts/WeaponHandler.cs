using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform player;
    public Camera cam;

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 dirToMouse = mousePos - player.position;

        // ângulo em graus
        float angle = Mathf.Atan2(dirToMouse.y, dirToMouse.x) * Mathf.Rad2Deg;

        // ---- Quantizar para 8 direções (cada 45°) ----
        float snappedAngle = Mathf.Round(angle / 45f) * 45f;

        // ---- Aplicar rotação ----
        // IMPORTANTE: se seu player é 2D, provavelmente usa eixo Z
        player.rotation = Quaternion.Euler(0, 0, snappedAngle);
    }
}

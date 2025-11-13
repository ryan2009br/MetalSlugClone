using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform player;
    public Camera cam;

    float facingDir = 1f; // 1 = direita, -1 = esquerda

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 dirToMouse = mousePos - player.position;

        float moveInput = Input.GetAxisRaw("Horizontal");

        // --- Prioridade da direção ---
        if (Mathf.Abs(moveInput) > 0.1f)  // andando
            facingDir = moveInput;
        else if (Mathf.Abs(dirToMouse.x) > 0.1f) // parado mas mirando
            facingDir = Mathf.Sign(dirToMouse.x);

        // --- Aplica rotação ---
        if (facingDir > 0)
            player.rotation = Quaternion.Euler(0, 0, 0);   // direita
        else
            player.rotation = Quaternion.Euler(0, 180, 0); // esquerda
    }
}
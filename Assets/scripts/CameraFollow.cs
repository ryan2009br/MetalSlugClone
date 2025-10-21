using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Configurações")]
    public Transform target;   // Player
    public float smoothSpeed = 5f; // Suavidade do movimento
    public Vector3 offset;     // Distância da câmera para o player

    void LateUpdate()
    {
        if (target == null) return;

        // Posição desejada (alvo + offset)
        Vector3 desiredPosition = target.position + offset;

        // Movimento suave (Lerp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Atualiza posição da câmera
        transform.position = smoothedPosition;
    }
}

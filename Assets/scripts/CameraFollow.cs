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

        // Posição desejada (alvo + offset), mantendo Y e Z fixos
        Vector3 desiredPosition = target.position + offset;

        // Mantém a altura fixa (Y)
        desiredPosition.y = transform.position.y;

        // Se você quiser que a câmera se mova apenas no eixo X ou Z, basta ajustar o valor da coordenada respectiva
        // Exemplo: Para mover apenas no eixo X:
        // desiredPosition.z = transform.position.z;  // Para manter a profundidade fixada

        // Exemplo: Para mover apenas no eixo Z:
        // desiredPosition.x = transform.position.x;  // Para manter a posição horizontal fixada

        // Movimento suave (Lerp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Atualiza posição da câmera
        transform.position = smoothedPosition;
    }
}

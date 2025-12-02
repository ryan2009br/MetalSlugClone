using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    public Transform player;     // Alvo
    public float smoothSpeed = 0.1f;
    public Vector3 offset;       // Ajuste de posição (ex: z = -10)

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = player.position + offset;

        // Movimento suave
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed);

        transform.position = smoothPos;
    }
}

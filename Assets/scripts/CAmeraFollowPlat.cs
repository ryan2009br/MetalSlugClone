using UnityEngine;

public class CAmeraFollowPlat : MonoBehaviour
{
    [Header("Alvo a seguir")]
    public Transform player;

    [Header("Configuração de movimento da câmera")]
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [Header("Dead Zone (zona morta)")]
    public Vector2 deadZoneSize = new Vector2(2f, 1f); // largura e altura da zona morta

    [Header("Limites da câmera (opcional)")]
    public bool limitarCamera = true;
    public Vector2 minLimit;
    public Vector2 maxLimit;

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 camPos = transform.position;
        Vector3 targetPos = player.position + offset;

        // calcula a distância entre player e câmera
        Vector2 delta = new Vector2(targetPos.x - camPos.x, targetPos.y - camPos.y);

        // verifica se o player saiu da zona morta no eixo X
        if (Mathf.Abs(delta.x) > deadZoneSize.x / 2f)
        {
            camPos.x = Mathf.Lerp(camPos.x, targetPos.x, smoothSpeed);
        }

        // verifica se o player saiu da zona morta no eixo Y
        if (Mathf.Abs(delta.y) > deadZoneSize.y / 2f)
        {
            camPos.y = Mathf.Lerp(camPos.y, targetPos.y, smoothSpeed);
        }

        // aplica limites se necessário
        if (limitarCamera)
        {
            camPos.x = Mathf.Clamp(camPos.x, minLimit.x, maxLimit.x);
            camPos.y = Mathf.Clamp(camPos.y, minLimit.y, maxLimit.y);
        }

        // atualiza posição final da câmera
        transform.position = new Vector3(camPos.x, camPos.y, transform.position.z);
    }

    private void OnDrawGizmosSelected()
    {
        // desenha a dead zone na cena para visualização
        if (player != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(deadZoneSize.x, deadZoneSize.y, 0));
        }
    }
}

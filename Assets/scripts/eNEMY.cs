using UnityEngine;

public class eNEMY : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    [SerializeField]
    private float velocidademovimento;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Update()
    {
        Vector2 posicaoalvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        

        this.rigidbody.velocity = (this.velocidademovimento *  direcao);

        if (this.rigidbody.velocity.x > 0)
        {
            this.spriteRenderer.flipX = false;
        }
        else if (this.rigidbody.velocity.x < 0)
        {
            this.spriteRenderer.flipX = true;
        }
}

using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para trocar de cena

public class SceneTransition : MonoBehaviour
{
    [Header("Configuração")]
    public string sceneToLoad; // Nome da cena de destino

    private bool isPlayerOverlapping = false;

    void Update()
    {
        // Se o player está sobre o objeto e pressionar espaço
        if (isPlayerOverlapping && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Detecta quando o player entra no trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Tá");
            isPlayerOverlapping = true;
        }  
    }

    // Detecta quando o player sai do trigger
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOverlapping = false;
        }
    }
}

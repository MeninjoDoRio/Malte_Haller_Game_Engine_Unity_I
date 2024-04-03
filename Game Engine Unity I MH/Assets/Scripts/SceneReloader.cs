using UnityEngine;

public class SceneReloader : MonoBehaviour
{
    // Name des Tags des Spielers
    public string playerTag = "Player";

    // Name der Szene, die geladen werden soll
    public string sceneToLoad = "GAME OVER";

    // Wird aufgerufen, wenn ein Trigger-Kollision stattfindet
    private void OnTriggerEnter(Collider other)
    {
        // Überprüfen, ob das kollidierende Objekt das Spielerobjekt ist
        if (other.CompareTag(playerTag))
        {
            // Szene laden
            LoadNewScene();
        }
    }

    // Funktion zum Laden einer neuen Szene
    private void LoadNewScene()
    {
        // Lade die neue Szene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}

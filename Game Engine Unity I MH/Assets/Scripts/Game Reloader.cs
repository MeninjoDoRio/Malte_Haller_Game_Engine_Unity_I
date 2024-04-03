using UnityEngine;

public class GameReloader : MonoBehaviour
{
    // Name der Szene, die geladen werden soll
    public string sceneToLoad = "LEVEL";

    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        // Überprüfe, ob die Leertaste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Lade die Ziel-Szene
            ReloadGame();
        }
    }

    // Funktion zum Laden der Zielszene
    private void ReloadGame()
    {
        // Lade die neue Szene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}

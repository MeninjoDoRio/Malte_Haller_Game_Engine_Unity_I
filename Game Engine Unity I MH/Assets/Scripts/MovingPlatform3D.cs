using UnityEngine;

public class MovingPlatform3D : MonoBehaviour
{
    public float speed = 2f; // Geschwindigkeit der Plattform
    public float distance = 10f; // Die Gesamtdistanz, über die sich die Plattform bewegt

    private Vector3 startPos; // Startposition der Plattform
    private Vector3 endPos; // Endposition der Plattform
    private bool playerOnPlatform = false; // Gibt an, ob der Spieler auf der Plattform steht

    private void Start()
    {
        startPos = transform.position; // Speichere die Startposition der Plattform
        endPos = startPos + transform.right * distance; // Berechne die Endposition basierend auf der Startposition und der Distanz
    }

    private void Update()
    {
        // Bewege die Plattform zwischen Start- und Endposition
        float pingPongValue = Mathf.PingPong(Time.time * speed / distance, 1f);
        transform.position = Vector3.Lerp(startPos, endPos, pingPongValue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player entered platform");
            playerOnPlatform = true; // Setze den Spieler als auf der Plattform
            collision.transform.parent = transform; // Setze den Spieler als Kindobjekt der Plattform
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player exited Platform");
            playerOnPlatform = false; // Entferne den Spieler von der Plattform
            collision.transform.parent = null; // Entferne den Spieler als Kindobjekt der Plattform
        }
    }
}

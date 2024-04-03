using System.Diagnostics;
using UnityEngine;

public class TeleportationHelper : MonoBehaviour
{
    public Transform teleportLocation;
    public Transform controller;
    public GameObject player;

    private bool isTeleporting = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isTeleporting)
        {
            Teleport();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isTeleporting)
        {
            TeleportLocationToPlayer();
        }
    }

    void Teleport()
    {
        if (teleportLocation != null)
        {
            isTeleporting = true;
            player.SetActive(false);
            controller.transform.position = teleportLocation.position;
            controller.transform.rotation = teleportLocation.rotation;
            player.SetActive(true);
            isTeleporting = false;
        }
        else
        {
            UnityEngine.Debug.LogWarning("Please assign teleport location");
        }
    }

    void TeleportLocationToPlayer()
    {
        if (player != null)
        {
            teleportLocation.position = controller.transform.position;
            teleportLocation.rotation = controller.transform.rotation;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TeleportTrigger"))
        {
            Teleport();
        }

        // Falls der Spieler ein Hindernis berührt, teleportiere ihn
        if (collision.gameObject.CompareTag("Hindernis"))
        {
            Teleport();
        }
    }
}

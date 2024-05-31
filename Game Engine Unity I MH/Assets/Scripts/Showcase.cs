using UnityEngine;

public class Showcase : MonoBehaviour
{
    // Rotation speed around the y-axis
    public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its own y-axis
        RotateAroundSelf();
    }

    void RotateAroundSelf()
    {
        // Rotate the GameObject around its own y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}


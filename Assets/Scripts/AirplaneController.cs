
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float speed = 0.5f;
    public float width = 10f;
    public float length = 5f;
    public float height = 5f;

    public float rotationOffset = 0f;

    private Vector3 startPosition;
    private float t = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        t += Time.deltaTime * speed;

        // Flugbahn in Form einer Acht
        float x = Mathf.Sin(t) * width;
        float z = Mathf.Sin(2f * t) * length;

        Vector3 newPosition =
            startPosition + new Vector3(x, height, z);

        transform.position = newPosition;

        // Flugrichtung berechnen
        Vector3 direction = new Vector3(
            Mathf.Cos(t) * width,
            0f,
            Mathf.Cos(2f * t) * 2f * length
        );

        // Flugzeug in Flugrichtung drehen
        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation =
                Quaternion.LookRotation(direction) *
                Quaternion.Euler(0f, rotationOffset, 0f);
        }
    }
}

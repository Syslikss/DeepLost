using UnityEngine;

public class StarShipController : MonoBehaviour
{
    private float speed = 4;
    private Vector3 direction;
    private readonly float timeToMove = .5f;
    private float timeDump = 0.0f;
    private Vector2 defaultPosition;

    private void Start()
    {
        direction = Vector3.zero;
        defaultPosition = transform.position;
    }

    private void Update()
    {
        if (direction != Vector3.zero)
        {
            float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        }

        timeDump -= Time.deltaTime;
        if (timeDump > 0)
            transform.position += direction * (Time.deltaTime * (1.01f / timeToMove));
        else
            direction = Vector3.zero;
    }

    public void Move(Vector3 newDirection)
    {
        if (direction == Vector3.zero)
        {
            timeDump = timeToMove;
            direction = newDirection;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("EndPortal"))
        {
            transform.position = defaultPosition;
            direction = Vector2.zero;
        }
    }
}

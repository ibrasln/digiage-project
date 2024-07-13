using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float Speed = 25f;
    [SerializeField] private float acceleration = 0.02f;
    [SerializeField] private float degreeAcceleration = 0.1f; // Daha yüksek bir deðer titremeyi azaltabilir

    private void Awake()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.velocity = Move(_rb.velocity, joystick.Direction * Speed);

        if (joystick.Direction != Vector2.zero)
        {
            Vector2 moveDirection = joystick.Direction;
            float radians = Mathf.Atan2(moveDirection.y, moveDirection.x);
            float degrees = radians * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, degrees - 90f), degreeAcceleration);
        }
    }

    private Vector2 Move(Vector2 velocity, Vector2 target)
    {
        if (velocity.magnitude < target.magnitude)
        {
            Vector2 newVelocity = Vector2.Lerp(velocity, target, acceleration);
            return Vector2.ClampMagnitude(newVelocity, Speed);
        }
        else return target;
    }
}

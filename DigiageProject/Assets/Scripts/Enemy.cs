using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 4f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 targetPos = (target.position - this.transform.position).normalized;
        transform.Translate(speed * Time.deltaTime * targetPos);
    }
}

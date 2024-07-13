using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float speed = 4f;

    private void Update()
    {
        Move();
    }

    public void Initialize(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
    }

    private void Move()
    {
        Vector2 targetPos = (_target.position - this.transform.position).normalized;
        transform.Translate(speed * Time.deltaTime * targetPos);
    }

    public void SetTarget(Transform target) { _target = target; }
}

using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private Transform _target;
    private float _speed;
    [SerializeField] private float degreeAcceleration = 0.1f;

    private void OnEnable()
    {
        _speed = Random.Range(3f, 6f);
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void Initialize(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
    }

    private void Move()
    {
        Vector2 moveDirection = (_target.position - this.transform.position).normalized;
        transform.Translate(_speed * Time.deltaTime * moveDirection);
    }

    private void Rotate()
    {
        Vector2 moveDirection = (_target.position - transform.position).normalized;
        float radians = Mathf.Atan2(moveDirection.y, moveDirection.x);
        float degrees = radians * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, degrees - 90f), degreeAcceleration);
    }

    public void SetTarget(Transform target) { _target = target; }

    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (collision.gameObject.CompareTag("Player")) StartCoroutine(Hurt(damageable));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        StopCoroutine(Hurt(damageable));
    }

    private IEnumerator Hurt(IDamageable damageable)
    {
        damageable.TakeDamage(1);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Hurt(damageable));
    }
}

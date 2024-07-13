using UnityEngine;

public class GuidedTorpedoBullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float Damage = 30;
    [SerializeField] Rigidbody2D rb;
    public Transform target;
    private void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            RunTOTarget();
        }
    }
    public void RunTOTarget()
    {
        if (target != null) rb.velocity = ((Vector2)target.position - (Vector2)this.transform.position).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable Ienemy = collision.gameObject.GetComponent<IDamageable>();
        if (Ienemy != null)
        {
            Ienemy.TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }

}

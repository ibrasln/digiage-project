using UnityEngine;



public class BulletBase : MonoBehaviour
{

    [SerializeField] float damage = 1f;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable bulletTriger = collision.gameObject.GetComponent<IDamageable>();
        if (bulletTriger != null)
        {
            bulletTriger.TakeDamage(damage);
            this.gameObject.SetActive(false);

        }
    }

}

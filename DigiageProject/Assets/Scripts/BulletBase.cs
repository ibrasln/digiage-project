using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletBase : MonoBehaviour
{

    [SerializeField] float damage = 1f;

   
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IBulletTriger bulletTriger = collision.gameObject.GetComponent<IBulletTriger>();
      if(bulletTriger != null)
        {
             bulletTriger.TakeDamage(damage);
             this.gameObject.SetActive(false);
          
        }
    }

}

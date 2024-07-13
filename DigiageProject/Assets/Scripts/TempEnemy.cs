using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] float health = 2f;
    public void TakeDamage(float damage)
    {
        //float result = damage - health;
        //health -= damage;
        //if(health <= 0)
        //{
        //    Destroy(gameObject,0.1f);
        //}
       
    }

    private void Update()
    {
        transform.Translate(Vector3.left * 5f * Time.deltaTime);
    }
}

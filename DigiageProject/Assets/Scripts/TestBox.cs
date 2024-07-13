using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBox : MonoBehaviour, IBulletTriger
{
    [SerializeField] float health = 2f;
    public void TakeDamage(float damage)
    {
        float result = damage - health;
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject,0.1f);
        }
       
    }
}

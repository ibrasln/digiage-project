using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedTorpedoBullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float Damage = 30;
    [SerializeField] Rigidbody2D rb;
    public Transform target;
    public void RunTOTarget()
    {
        if(target != null) rb.velocity =  ((Vector2) this.transform.position - (Vector2)target.position).normalized*speed;
    }
}

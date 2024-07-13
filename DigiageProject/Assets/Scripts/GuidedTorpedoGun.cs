using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedTorpedoGun : MonoBehaviour
{
    [SerializeField] float rateOfFre = 0.5f;
    [SerializeField] GameObject TorpedoPrefab;
    [SerializeField] Transform bareel;
    [SerializeField] float range = 30f;

    float time;
    RaycastHit2D hit;

    private void Awake()
    {
        time = Time.time;
    }


    private void Update()
    {
        if(Time.time -time > rateOfFre)
        {
            hit = Physics2D.Raycast(bareel.position, bareel.up, range);
            if(hit.collider != null )
            {

            }
 
        }
    }
}

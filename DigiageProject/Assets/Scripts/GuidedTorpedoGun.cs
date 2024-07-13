using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedTorpedoGun : MonoBehaviour
{
    [SerializeField] float rateOfFre = 0.5f;
    [SerializeField] GuidedTorpedoBullet BulletPrefab;
    [SerializeField] Transform bareel;
    [SerializeField] float range = 30f;
    [SerializeField] LayerMask _layerMask;

    float time;
    RaycastHit2D hit;

    private void Awake()
    {
        time = Time.time;
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(rateOfFre);

            hit = Physics2D.Raycast(bareel.position, bareel.up, range, _layerMask);

            if (hit.collider != null && hit.collider.TryGetComponent<IEnemy>(out var enemy))
            {
                Debug.Log("torbido run");
                GuidedTorpedoBullet obj = Instantiate(BulletPrefab, bareel.position,
                    Quaternion.identity);

                obj.target = hit.collider.transform;
            }
            else
                yield return null;
        }
    }

}

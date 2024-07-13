using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] int bulletPCS = 20;
    [SerializeField] float rateOfFre = 0.5f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bareel;


    private Queue<GameObject> bulletQue;

    private void Awake()
    {
        
        bulletQue = new Queue<GameObject>();
      
        for (int i = 0; i < bulletPCS; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab,bareel.position,Quaternion.identity);
            bulletQue.Enqueue(bullet);
            bullet.SetActive(false);

        }

        StartCoroutine(Fre());

    }

    IEnumerator Fre()
    {
       while (true)
        {
            
            yield return new WaitForSeconds(rateOfFre);
            GameObject bullet = bulletQue.Dequeue();
            bulletQue.Enqueue(bullet);
            
            bullet.transform.position = bareel.position;
            bullet.SetActive(true);
            Rigidbody2D rb = bullet.gameObject.GetComponent<Rigidbody2D>();
            if(rb!= null)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(bareel.up * bulletSpeed, ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogWarning("bullet in not rgidbody2D");
            }
            
        }

    }
}

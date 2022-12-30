using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
        
}

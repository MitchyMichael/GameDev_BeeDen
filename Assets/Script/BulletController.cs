using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{ 
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        float damage = PlayerController.instance.bulletDamage;

        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
        
}

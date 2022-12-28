using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -=  amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

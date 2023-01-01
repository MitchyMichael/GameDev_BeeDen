using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * Time.deltaTime * speed, 0, 0);

        if (gameObject.transform.position.x <= -10)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -=  amount;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Victory");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
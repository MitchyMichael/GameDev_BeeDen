using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float speed;
    public static EnemyController instance;


    private void Awake()
    {
        instance = this;
    }

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

    public void TakeDamage(float amount)
    {
        AudioClip enemyHit = PlayerController.instance.EnemyHit;
        PlayerController.instance.audioSourceSFX.PlayOneShot(enemyHit);
        currentHealth -=  amount;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            CoinController.instance.AddCoin(10);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}

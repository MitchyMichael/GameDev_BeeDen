using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float move = 0.03f;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public int bulletDamage;
    
    public AudioClip PlayerShoot;
    public AudioClip PlayerHit;
    public AudioClip EnemyHit;
    public AudioSource audioSourceSFX;

    public float cooldown;
    float lastShot;

    public GameObject[] hearts;
    public int life;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        life = hearts.Length;
    }

    void Update()
    {
        GetInputMovePlayer();
        GetInputShooting();
    }

    private void GetInputShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShot < cooldown)
            {
                return;
            }
            lastShot = Time.time;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            audioSourceSFX.PlayOneShot(PlayerShoot);
        }
    }

    private void GetInputMovePlayer()
    {
        Vector3 pos = transform.localPosition;
        Vector3 scale = transform.localScale;

        if (Input.GetKey(KeyCode.W)){
            pos.y += move;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= move;
        }

        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= move;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += move;
        }

        transform.localPosition = pos;
        transform.localScale = scale;
    }

    public void TakeDamage(int amount)
    {
        if (life >= 1)
        {
            life -= amount;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
            audioSourceSFX.PlayOneShot(PlayerHit);
        }
    }

    public void upgradeCooldown()
    {
        cooldown -= 0.1f;
    }

    public void upgradeBulletSpeed()
    {
        bulletSpeed += 1.5f;
    }

    public void upgradeBulletDamage()
    {
        bulletDamage += 1;
    }

}

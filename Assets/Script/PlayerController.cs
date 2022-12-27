using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float move = 0.03f;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;

    void Start()
    {
        
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
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
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

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;

    public TMP_Text textCoin;

    int coin = 0;

    public bool isUpgraded = false;

    public GameObject coins;
    public Transform target;
    public float speed;
    public AudioClip Score;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        textCoin.text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].transform.position = Vector3.MoveTowards(coins[i].transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        textCoin.text = coin.ToString();
    }

    public void SubtractCoin(int amount)
    {
        if (coin >= amount)
        {
            coin -= amount;
            textCoin.text = coin.ToString();
            isUpgraded = true;
        }
        else
        {
            isUpgraded = false;
        }
    }

    public void AppearCoin(Vector3 vector)
    {
        Instantiate(coins, vector, Quaternion.identity);
        PlayerController.instance.audioSourceSFX.PlayOneShot(Score);
    }
}

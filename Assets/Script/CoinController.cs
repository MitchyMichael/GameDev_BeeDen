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
}

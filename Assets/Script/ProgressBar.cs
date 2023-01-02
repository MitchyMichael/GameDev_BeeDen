using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    public float FillSpeed = 0.5f;
    private float targetProgress = 0;

    public KeyCode key;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(key))
        {
            if (key == KeyCode.Alpha1)
            {
                upgradeCooldownButton();
            }
            if (key == KeyCode.Alpha2)
            {
                upgradeBulletSpeedButton();
            }
            if (key == KeyCode.Alpha3)
            {
                upgradeBulletDamageButton();
            }
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void upgradeCooldownButton()
    {
        CoinController.instance.SubtractCoin(30);
        if (CoinController.instance.isUpgraded == true)
        {
            if (slider.value == 1)
            {
                Debug.Log("Progress Bar Full");
            }
            else
            {
                PlayerController.instance.upgradeCooldown();
                IncrementProgress(0.25f);
            }
        }
    }

    public void upgradeBulletSpeedButton()
    {
        CoinController.instance.SubtractCoin(30);
        if (CoinController.instance.isUpgraded == true)
        {
            if (slider.value == 1)
            {
                Debug.Log("Progress Bar Full");
            }
            else
            {
                PlayerController.instance.upgradeBulletSpeed();
                IncrementProgress(0.25f);
            }
        }
    }

    public void upgradeBulletDamageButton()
    {
        CoinController.instance.SubtractCoin(100);
        if (CoinController.instance.isUpgraded == true)
        {
            if (slider.value == 1)
            {
                Debug.Log("Progress Bar Full");
            }
            else
            {
                PlayerController.instance.upgradeBulletDamage();
                IncrementProgress(0.5f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float move = 0.03f;

    void Start()
    {
        
    }

    
    void Update()
    {
        GetInputMovePlayer();
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

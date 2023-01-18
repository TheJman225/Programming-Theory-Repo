using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] float speed;
    [SerializeField] int range;
    Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * horizontalInput * speed * Time.deltaTime, ForceMode.Impulse);
        KeepInBounds();
    }

    void KeepInBounds()
    {
        if (transform.position.x > range)
        {
            transform.position = new Vector3(range, 0, 0);
        }
        else if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, 0, 0);
        }
    }
}
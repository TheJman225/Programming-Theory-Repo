using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 50;
    private int range = 4;
    private Rigidbody playerRb;

    [SerializeField] private GameManager manager;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        MovePlayer(); // ABSTRACTION
    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * horizontalInput * speed * Time.deltaTime, ForceMode.Impulse);
        KeepInBounds(); // ABSTRACTION
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            manager.AddScore(other.gameObject.GetComponent<Coin>().coinValue);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            manager.GameOver();
        }
    }
}

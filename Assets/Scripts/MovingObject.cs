using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        if (transform.position.z < -5)
        {
            Destroy(gameObject);
        }
    }
}

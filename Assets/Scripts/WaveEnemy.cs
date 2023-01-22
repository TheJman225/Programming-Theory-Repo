using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemy : Enemy // INHERITANCE
{
    private float startPos;
    private float waveTime;
    private float waveLength { get; } = 5;

    void Start()
    {
        startPos = transform.position.x;
        waveTime = Random.Range(0, 10);
    }

    protected override void Move() // POLYMORPHISM
    {
        base.Move();
        transform.position = new Vector3(startPos + Mathf.Sin(waveTime * waveLength), 0, transform.position.z);
        waveTime += Time.deltaTime;
    }
}

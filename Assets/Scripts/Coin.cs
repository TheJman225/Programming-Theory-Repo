using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MovingObject
{
    private int spinSpeed { get; } = 5;
    [SerializeField] public int value;

    protected override void Move()
    {
        transform.Rotate(0, spinSpeed, 0, Space.World);
        base.Move();
    }
}

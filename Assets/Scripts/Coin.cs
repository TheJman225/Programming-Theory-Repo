using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MovingObject // INHERITANCE
{
    private int spinSpeed { get; } = 5;
    public int coinValue;

    protected override void Move() // POLYMORPHISM
    {
        transform.Rotate(0, spinSpeed, 0, Space.World);
        base.Move();
    }
}

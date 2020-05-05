using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspEnemy : IEnemy
{
    public int moveSpeed { get; set; }
    public int attackPower { get; set; }
    public int health { get; set; }
    public string name { get; set; }

    IEnemy IEnemy.CreateEnemy()
    {
        name = "Green Wasp";
        return this;
    }
}

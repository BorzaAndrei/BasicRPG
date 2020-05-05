using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastWeakWaspEnemy : EnemyDecorator
{

    public FastWeakWaspEnemy(IEnemy enemy) : base(enemy)
    {

    }

    public override IEnemy CreateEnemy()
    {
        enemy.CreateEnemy();
        AddPower(enemy);
        AddSpeed(enemy);
        return enemy;
    }

    private void AddPower(IEnemy enemy)
    {
        if (enemy is WaspEnemy)
        {
            WaspEnemy waspEnemy = (WaspEnemy)enemy;
            waspEnemy.attackPower = 5;
        }
    }

    private void AddSpeed(IEnemy enemy)
    {
        if (enemy is WaspEnemy)
        {
            WaspEnemy waspEnemy = (WaspEnemy)enemy;
            waspEnemy.moveSpeed = 10;
        }
    }
}

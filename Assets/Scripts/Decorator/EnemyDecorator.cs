using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDecorator : IEnemy
{
    protected IEnemy enemy;

    public EnemyDecorator(IEnemy enemy)
    {
        this.enemy = enemy;
    }

    public virtual IEnemy CreateEnemy()
    {
        return enemy.CreateEnemy();
    }
}

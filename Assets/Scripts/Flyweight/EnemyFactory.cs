using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    private static Dictionary<string, IEnemy> enemyMap = new Dictionary<string, IEnemy>();

    public static IEnemy GetEnemy(string enemyType)
    {
        IEnemy enemy = null;

        if (enemyType.Equals("SlowStrongWasp"))
        {
            if (enemyMap.TryGetValue("SlowStrongWasp", out enemy))
            {
                Debug.Log("Returned the SlowStrongWasp!");
            }
            else
            {
                Debug.Log("Created first SlowStrongWasp!");
                enemy = new WaspEnemy();
                enemy = enemy.CreateEnemy();
                enemy = new SlowStrongWaspEnemy(enemy);
                enemy = enemy.CreateEnemy();
                enemyMap.Add("SlowStrongWasp", enemy);
            }
        }
        else if (enemyType.Equals("FastWeakWasp"))
        {
            if (enemyMap.TryGetValue("FastWeakWasp", out enemy))
            {
                Debug.Log("Returned another FastWeakWasp!");
            }
            else
            {
                Debug.Log("Created first FastWeakWasp!");
                enemy = new WaspEnemy();
                enemy = enemy.CreateEnemy();
                enemy = new FastWeakWaspEnemy(enemy);
                enemy = enemy.CreateEnemy();
                enemyMap.Add("FastWeakWasp", enemy);
            }
        }

        return enemy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspGenerator : MonoBehaviour
{

    public GameObject waspGameObject;

    public float timeBetweenSpawns;
    private float lastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawn > timeBetweenSpawns)
        {
            lastSpawn = Time.time;
            SpawnWasps(Random.Range(1, 10));
        }
    }

    private void SpawnWasps(int type)
    {
        
        IEnemy wasp = new WaspEnemy();
        wasp = wasp.CreateEnemy();
        

        if (type % 2 == 0)
        {
            SlowStrongWaspEnemy slowStrongWasp = new SlowStrongWaspEnemy(wasp);
            wasp = slowStrongWasp.CreateEnemy();
            
        }
        else
        {
            FastWeakWaspEnemy fastWeakWasp = new FastWeakWaspEnemy(wasp);
            wasp = fastWeakWasp.CreateEnemy();
        }

        if (wasp is WaspEnemy)
        {
            WaspEnemy completeWasp = (WaspEnemy)wasp;
            waspGameObject.GetComponent<EnemyScript>().damagePower = completeWasp.attackPower;
            waspGameObject.GetComponent<SimpleMovementC>().moveSpeed = completeWasp.moveSpeed;
            Instantiate(waspGameObject);
        }
    }
}

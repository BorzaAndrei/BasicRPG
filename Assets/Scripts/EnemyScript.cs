using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int damagePower;
    private bool canDamage, startTimer;
    private float minWaitTime = 2.0f, currentWaitTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canDamage && currentWaitTime <= 0f)
        {
            GameManager.instance.DamagePlayer(damagePower);
            startTimer = true;
        }

        if (startTimer)
        {
            currentWaitTime = minWaitTime;
            startTimer = false;
        }
        currentWaitTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canDamage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canDamage = false;
        }
    }
}

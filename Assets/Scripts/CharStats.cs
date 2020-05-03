﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{

    public string charName;
    public int playerLevel = 1;
    public int currentExp;

    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseExp = 1000;

    public int currentHp;
    public int maxHp = 100;
    public int currentMp;
    public int maxMp = 30;
    public int[] mpLvlBonus;

    public int strenght;
    public int defense;
    public int weaponPower;
    public int armourPower;
    public string equippedWeapon;
    public string equippedArmour;
    public Sprite charImg;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;

        for (int i = 2; i < maxLevel; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
;        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;

        if (playerLevel < maxLevel)
        {
            if (currentExp > expToNextLevel[playerLevel])
            {
                currentExp -= expToNextLevel[playerLevel];
                playerLevel++;

                if (playerLevel % 2 == 0)
                {
                    strenght++;
                }
                else
                {
                    defense++;
                }

                maxHp = Mathf.FloorToInt(maxHp * 1.05f);
                currentHp = maxHp;

                maxMp = maxMp + mpLvlBonus[playerLevel];
                currentMp = maxMp;
            }
        }
        if(playerLevel == maxLevel)
        {
            currentExp = 0;
        }
    }
}

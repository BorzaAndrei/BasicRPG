using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmour;

    [Header("Basic Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")]
    public int amountToChange;
    public bool affectHp, affectMp, affectStr;

    [Header("Weapon Details")]
    public int wpnStr;

    [Header("Armour Details")]
    public int armourStr;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];
        if (isItem)
        {
            if (affectHp)
            {
                selectedChar.currentHp += amountToChange;

                if (selectedChar.currentHp > selectedChar.maxHp)
                {
                    selectedChar.currentHp = selectedChar.maxHp;
                }
            }
            if (affectMp)
            {
                selectedChar.currentMp += amountToChange;

                if (selectedChar.currentMp > selectedChar.maxMp)
                {
                    selectedChar.currentMp = selectedChar.maxMp;
                }
            }
            if (affectStr)
            {
                selectedChar.strenght += amountToChange;
            }
        }

        if (isWeapon)
        {
            if (selectedChar.equippedWeapon != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWeapon);
            }
            selectedChar.equippedWeapon = itemName;
            selectedChar.weaponPower = wpnStr;
        }

        if (isArmour)
        {
            if (selectedChar.equippedArmour != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmour);
            }
            selectedChar.equippedArmour = itemName;
            selectedChar.armourPower = armourStr;
        }

        GameManager.instance.RemoveItem(itemName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public GameObject menu;

    private CharStats[] playerStats;

    public Text[] nameText;
    public Text[] hpText, mpText, lvlTxt, expText;

    public Slider[] expSliders;
    public Image[] charImgs;

    public GameObject[] charStatHolder;

    public GameObject[] windows;

    public GameObject[] statusButtons;

    public Text statusName, statusHp, statusMp, statusStr, statusDef, statusWpnEqi, statusWpnPwr, statusArmrEqi, statusArmrPwr, statusExp;
    public Image statusImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (menu.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                menu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;
            }
        }
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);

                nameText[i].text = playerStats[i].charName;
                hpText[i].text = "HP: " + playerStats[i].currentHp + "/" + playerStats[i].maxHp;
                mpText[i].text = "MP: " + playerStats[i].currentMp + "/" + playerStats[i].maxMp;
                lvlTxt[i].text = "Level: " + playerStats[i].playerLevel;
                expText[i].text = "" + playerStats[i].currentExp + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSliders[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSliders[i].value = playerStats[i].currentExp;
                charImgs[i].sprite = playerStats[i].charImg;
            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }
    }

    public void ToggleWindow(int windowNo)
    {
        UpdateMainStats();

        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNo)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        menu.SetActive(false);
        GameManager.instance.gameMenuOpen = false;
    }

    public void OpenStatus()
    {
        UpdateMainStats();

        StatusChar(0);

        for (int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = playerStats[i].charName;
        }
    }

    public void StatusChar(int selected)
    {
        statusName.text = playerStats[selected].charName;
        statusHp.text = "" + playerStats[selected].currentHp + "/" + playerStats[selected].maxHp;
        statusMp.text = "" + playerStats[selected].currentMp + "/" + playerStats[selected].maxMp;
        statusStr.text = playerStats[selected].strenght.ToString();
        statusDef.text = playerStats[selected].defense.ToString();
        if (playerStats[selected].equippedWeapon != "")
        {
            statusWpnEqi.text = playerStats[selected].equippedWeapon;
        }
        statusWpnPwr.text = playerStats[selected].weaponPower.ToString();
        if (playerStats[selected].equippedArmour != "")
        {
            statusArmrEqi.text = playerStats[selected].equippedArmour;
        }
        statusArmrPwr.text = playerStats[selected].armourPower.ToString();
        statusExp.text = (playerStats[selected].expToNextLevel[playerStats[selected].playerLevel] - playerStats[selected].currentExp).ToString();
        statusImg.sprite = playerStats[selected].charImg;
    }
}

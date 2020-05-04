using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool gameMenuOpen;
    public bool dialogActive;
    public bool fadingBetweenAreas;

    public string[] itemsHeld;
    public int[] noOfItems;
    public Item[] referenceItems;

    public CharStats[] playerStats;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

        SortItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenuOpen || dialogActive || fadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem("Iron Armour");
            AddItem("nu");

            RemoveItem("Health Potion");
        }
    }

    public Item GetItemDetails(string itemName)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if (referenceItems[i].itemName == itemName)
            {
                return referenceItems[i];
            }
        }

        return null;
    }

    public void SortItems()
    {
        bool moreItems = true;
        for (int i = 0; i < itemsHeld.Length - 1; i++)
        {
            int j = i + 1;
            while (itemsHeld[i] == "" && moreItems)
            {
                itemsHeld[i] = itemsHeld[j];
                itemsHeld[j] = "";

                noOfItems[i] = noOfItems[j];
                noOfItems[j] = 0;
                j++;

                if (j >= itemsHeld.Length)
                {
                    moreItems = false;
                }
            }
        }
    }

    public void AddItem(string itemToAdd)
    {
        int position = 0;
        bool foundSpace = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == "" || itemsHeld[i] == itemToAdd)
            {
                position = i;
                foundSpace = true;
                break;
            }
        }

        if (foundSpace)
        {
            bool itemExists = false;
            for (int i = 0; i < referenceItems.Length; i++)
            {
                if (referenceItems[i].itemName == itemToAdd)
                {
                    itemExists = true;
                    break;
                }
            }
            if (itemExists)
            {
                itemsHeld[position] = itemToAdd;
                noOfItems[position]++;
            }
            else
            {
                Debug.LogError(itemToAdd + " does NOT exist!");
            }
        }

        GameMenu.instance.ShowItems();
    }

    public void RemoveItem(string itemToRemove)
    {
        bool foundItem = false;
        int position = 0;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == itemToRemove)
            {
                foundItem = true;
                position = i;
                break;
            }
        }

        if (foundItem)
        {
            noOfItems[position]--;
            if (noOfItems[position] <= 0)
            {
                itemsHeld[position] = "";
            }
            GameMenu.instance.ShowItems();
        }
        else
        {
            Debug.LogError("Couldn't find " + itemToRemove);
        }
    }
}

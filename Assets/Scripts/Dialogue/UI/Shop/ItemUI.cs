using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Item item;

    private bool itemIsUnlocked;

    private PlayerInventory playerInventory;
    private Shopkeeper shopkeeper;

    [SerializeField] private GameObject lockedItemUI;
    [SerializeField] private GameObject unlockedItemUI;

    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemCostText;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        shopkeeper = FindObjectOfType<Shopkeeper>();
        CheckItem();
    }

    void CheckItem()
    {
        itemIsUnlocked = playerInventory.CheckIfItemIsUnlocked(item);
        itemNameText.text = item.name;
        itemCostText.text = item.Cost + "c";
        if (itemIsUnlocked)
        {
            lockedItemUI.SetActive(false);
            unlockedItemUI.SetActive(true);
        }
        else
        {
            lockedItemUI.SetActive(true);
            unlockedItemUI.SetActive(false);
        }
    }

    public void EquipItem()
    {
        playerInventory.EquipItem(item);
    }
    
    public void BuyItem()
    {
        shopkeeper.SellItem(item, this);
    }
    
    public void UnlockedItem()
    {
        CheckItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemUI : MonoBehaviour
{
    [SerializeField] protected Item item;

    [SerializeField] protected RawImage itemIcon;

    protected bool itemIsUnlocked;

    protected PlayerInventory playerInventory;
    protected Shopkeeper shopkeeper;
    
    [SerializeField] protected TextMeshProUGUI itemNameText;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetUp(Item item)
    {
        this.item = item;
        CheckItem();
    }

    protected void OnEnable()
    {
        CheckItem();
    }

    protected abstract void CheckItem();

    public void EquipItem()
    {
        CheckForPlayerAndShopkeeper();
        playerInventory.EquipItem(item);
    }
    
    protected void CheckForPlayerAndShopkeeper()
    {
        if (playerInventory == null)
            playerInventory = FindObjectOfType<PlayerInventory>();
        if (shopkeeper == null)
            shopkeeper = FindObjectOfType<Shopkeeper>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
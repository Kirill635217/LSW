using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemContainerBuy : ItemUI
{
    [SerializeField] private TextMeshProUGUI itemCostText;
    
    [SerializeField] private GameObject lockedItemUI;
    [SerializeField] private GameObject unlockedItemUI;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private new void OnEnable()
    {
        base.OnEnable();   
    }

    protected override void CheckItem()
    {
        CheckForPlayerAndShopkeeper();
        if (item == null)
            return;
        itemIsUnlocked = playerInventory.CheckIfItemIsUnlocked(item);
        itemNameText.text = item.name;
        itemCostText.text = item.Cost + "c";
        itemIcon.texture = item.Icon;
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
    
    public void BuyItem()
    {
        CheckForPlayerAndShopkeeper();
        shopkeeper.SellItem(item, this);
    }

    public void ItemBought()
    {
        CheckItem();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
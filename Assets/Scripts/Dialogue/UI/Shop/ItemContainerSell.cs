using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemContainerSell : ItemUI
{
    [SerializeField] private TextMeshProUGUI itemCostText;

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
        itemCostText.text = $"+{item.Cost}c";
    }

    public void SellItem()
    {
        CheckForPlayerAndShopkeeper();
        shopkeeper.BuyItem(item, this);
        CheckItem();
    }

    public void ItemSold()
    {
        item = null;
        gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    private void Update()
    {
    }
}

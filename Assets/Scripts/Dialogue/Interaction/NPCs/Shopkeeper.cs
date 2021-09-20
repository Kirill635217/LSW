using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : Interactable
{
    [SerializeField] private DialogueChannel m_DialogueChannel;
    [SerializeField] private FlowChannel flowChannel;
    [SerializeField] private FlowState dialogueState;
    [SerializeField] private FlowState gameState;

    [SerializeField] private GameObject shopMenu;

    private PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        m_DialogueChannel.OnDialogueEnd += OnDialogueNodeEnd;
        playerInventory = FindObjectOfType<PlayerInventory>();
        shopMenu.transform.localScale = Vector3.zero;
        // hide ShopScrollViewBuy and hide ShopScrollViewSell
        shopMenu.transform.GetChild(0).gameObject.SetActive(false);
        shopMenu.transform.GetChild(1).gameObject.SetActive(false);
    }

    void OnDialogueNodeEnd(Dialogue dialogue)
    {
        flowChannel.RaiseFlowStateRequest(dialogueState);
        ShowBuyMenu();
    }

    public void ShowBuyMenu()
    {
        // Show ShopScrollViewBuy and hide ShopScrollViewSell
        shopMenu.transform.GetChild(0).gameObject.SetActive(true);
        shopMenu.transform.GetChild(1).gameObject.SetActive(false);
        LeanTween.scale(shopMenu, Vector3.one, .3f);
    }
    
    public void ShowSellMenu()
    {
        // Hide ShopScrollViewBuy and show ShopScrollViewSell
        shopMenu.transform.GetChild(0).gameObject.SetActive(false);
        shopMenu.transform.GetChild(1).gameObject.SetActive(true);
        LeanTween.scale(shopMenu, Vector3.one, .3f);
    }
    
    /// <summary>
    /// Sells item to the buyer(player)
    /// </summary>
    /// <param name="item">item to sell</param>
    /// <param name="itemUI">itemUI which called SellItem() from buy button</param>
    public void SellItem(Item item, ItemContainerBuy itemUI)
    {
        bool isBought = playerInventory.BuyItem(item, item.Cost);
        if (isBought)
        {
            itemUI.ItemBought();
        }
    }

    /// <summary>
    /// Buys an item from the seller(player)
    /// </summary>
    /// <param name="item">item to buy</param>
    public void BuyItem(Item item, ItemContainerSell itemUI)
    {
        bool isSold = playerInventory.SellItem(item, item.Cost);
        if (isSold)
        {
            itemUI.ItemSold();
        }
    }

    public void CloseShop()
    {
        LeanTween.scale(shopMenu, Vector3.zero, .3f);
        // shopMenu.SetActive(false);
        flowChannel.RaiseFlowStateRequest(gameState);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
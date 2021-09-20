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
    }

    void OnDialogueNodeEnd(Dialogue dialogue)
    {
        Debug.Log("Shopkeeper node end");
        LeanTween.scale(shopMenu, Vector3.one, .3f);
        flowChannel.RaiseFlowStateRequest(dialogueState);
    }
    /// <summary>
    /// Sells item to the buyer(player)
    /// </summary>
    /// <param name="item">item to sell</param>
    /// <param name="itemUI">itemUI which called SellItem() from buy button</param>
    public void SellItem(Item item, ItemUI itemUI)
    {
        bool isBought = playerInventory.UnlockItem(item, item.Cost);
        if (isBought)
        {
            itemUI.UnlockedItem();
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
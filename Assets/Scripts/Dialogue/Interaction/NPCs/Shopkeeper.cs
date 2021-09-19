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

    // Start is called before the first frame update
    void Start()
    {
        m_DialogueChannel.OnDialogueEnd += OnDialogueNodeEnd;
    }

    void OnDialogueNodeEnd(Dialogue dialogue)
    {
        Debug.Log("Shopkeeper node end");
        shopMenu.SetActive(true);
        flowChannel.RaiseFlowStateRequest(dialogueState);
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
        flowChannel.RaiseFlowStateRequest(gameState);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
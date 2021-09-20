using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ShopMenuUI : MonoBehaviour
{
    protected PlayerInventory playerInventory;

    protected List<ItemUI> itemContainers = new List<ItemUI>();
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if (playerInventory == null)
            playerInventory = FindObjectOfType<PlayerInventory>();
        GenerateContainers();
    }

    /// <summary>
    /// Generates itemContainers for each item, if no available container, else just changes item for available one
    /// </summary>
    protected abstract void GenerateContainers();

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMenu : ShopMenuUI
{
    [SerializeField] private ItemContainerSell itemContainerSellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void GenerateContainers()
    {
        List<Item> itemsToSpawn = playerInventory.GetAllItems();
        if(itemsToSpawn.Count <= 0)
            return;
        for (int i = 0; i < itemsToSpawn.Count; i++)
        {
            if (itemContainers.Count > i)
            {
                itemContainers[i].gameObject.SetActive(true);
                itemContainers[i].SetUp(itemsToSpawn[i]);
            }
            else
            {
                ItemContainerSell generatedItemContainer =
                    Instantiate(itemContainerSellPrefab, transform.position, Quaternion.identity);
                generatedItemContainer.transform.parent = transform;
                generatedItemContainer.SetUp(itemsToSpawn[i]);
                itemContainers.Add(generatedItemContainer);
            }
        }

        int diff = itemContainers.Count - itemsToSpawn.Count;
        if (diff > 0)
        {
            for (int i = 0; i < diff; i++)
            {
                itemContainers[itemContainers.Count + i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

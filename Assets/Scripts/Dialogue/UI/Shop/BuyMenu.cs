using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BuyMenu : ShopMenuUI
{
    [SerializeField] private ItemContainerBuy itemContainerBuyPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    protected override void GenerateContainers()
    {
        if(itemContainers.Count > 0)
            return;
        Item[] itemsToSpawn = Resources.LoadAll<Item>("Items");
        if(itemsToSpawn.Length <= 0)
            return;
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            Debug.Log(itemsToSpawn[i]);
            if (itemContainers.Count > i)
            {
                itemContainers[i].gameObject.SetActive(true);
                itemContainers[i].SetUp(itemsToSpawn[i]);
            }
            else
            {
                ItemContainerBuy generatedItemContainer =
                    Instantiate(itemContainerBuyPrefab, transform.position, Quaternion.identity);
                generatedItemContainer.transform.parent = transform;
                generatedItemContainer.SetUp(itemsToSpawn[i]);
                itemContainers.Add(generatedItemContainer);
            }
        }

        int diff = itemContainers.Count - itemsToSpawn.Length;
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

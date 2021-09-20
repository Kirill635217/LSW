using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // all items the player has unlocked rn
    private List<Item> items = new List<Item>();
    // current item equipped
    private Item currentItem;

    private int money = 50;
    public int Money => money;

    [SerializeField] private Item hat;

    [SerializeField] private GameObject itemSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void EquipItem(Item itemToEquip)
    {
        if (items.Contains(itemToEquip))
        {
            ChangeCurrentItem(itemToEquip);
        }
    }

    public bool CheckIfItemIsUnlocked(Item itemToCheck)
    {
        if (items.Contains(itemToCheck))
            return true;
        return false;
    }

    public bool UnlockItem(Item itemToUnlock, int cost)
    {
        if (!items.Contains(itemToUnlock) && cost <= money)
        {
            items.Add(itemToUnlock);
            money -= cost;
            return true;
        }

        return false;
    }

    void ChangeCurrentItem(Item itemToChangeTo)
    {
        if(itemSpawn.transform.childCount > 0)
            Destroy(itemSpawn.transform.GetChild(0));
        currentItem = itemToChangeTo;
        GameObject spawnedItem = Instantiate(itemToChangeTo.ItemPrefab, itemSpawn.transform.position,
            itemSpawn.transform.rotation);
        spawnedItem.transform.parent = itemSpawn.transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

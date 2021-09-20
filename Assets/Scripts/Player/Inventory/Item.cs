using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private Texture icon;
    [SerializeField] private GameObject itemPrefab;

    public Texture Icon => icon;
    public GameObject ItemPrefab => itemPrefab;
}

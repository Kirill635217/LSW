using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private Texture icon;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private int cost;
    [SerializeField] private string name;

    public Texture Icon => icon;
    public GameObject ItemPrefab => itemPrefab;
    public int Cost => cost;
    public string Name => name;
}

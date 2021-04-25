using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item1", menuName = "AddItem/Item")]

public class Item : ScriptableObject
{
    public float price;
    public string nameItem;
    public string description;
    public GameObject itemPrefab;
    public Sprite itemImage;
}

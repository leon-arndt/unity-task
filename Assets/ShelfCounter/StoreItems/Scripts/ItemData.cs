using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject for the items in the store
/// </summary>
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemData : ScriptableObject {
    public string itemName = null;
    public float cost = 0;
}

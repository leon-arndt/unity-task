using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attached to each individual store item in the store
/// </summary>
public class StoreItem : Interactable {
    [SerializeField]
    private ItemData data;

    public override void Interact()
    {
        FillSlot(); 
    }

    public ItemData GetData()
    {
        return data;
    }

    public void FillSlot()
    {
        Counter counter = FindObjectOfType<Counter>();
        CounterSlot free = counter.GetFirstEmptySlot();

        //fill previous free CounterSlot
        free.SetFilled(true);

        //move to position
        transform.position = free.transform.position;
    }
}

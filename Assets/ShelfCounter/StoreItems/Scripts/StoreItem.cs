﻿using System.Collections;
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
        free.Set(this);

        //create a copy at position
        GameObject copy = Instantiate(gameObject);
        copy.AddComponent<ItemCopy>();
        copy.GetComponent<ItemCopy>().SetCounterSlot(free);

        //destroy the store item component
        Destroy(copy.GetComponent<StoreItem>());

        //move the copy
        copy.transform.position = free.transform.position;

        //set parent as counter to keep hierarchy clean
        copy.transform.parent = counter.transform;
    }
}

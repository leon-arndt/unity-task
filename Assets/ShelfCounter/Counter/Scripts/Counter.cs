using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for the counter
/// Hold the positions for the items
/// </summary>
public class Counter : Interactable {
    [SerializeField]
    private List<CounterSlot> counterSlots = new List<CounterSlot>();

    private const int maxItems = 5;

    public override void Interact()
    {
        base.Interact();
    }

    /// <summary>
    /// Get the total cost value of all items on the counter
    /// </summary>
    /// <returns></returns>
    public float GetTotalCost()
    {
        float totalCost = 0f;

        foreach (var item in counterSlots)
        {
            totalCost += item.GetCost();
        }

        return totalCost;
    }

    public CounterSlot GetFirstEmptySlot()
    {
        for (int i = 0; i < counterSlots.Count; i++)
        {
            //return the first free slot
            if (!counterSlots[i].GetFilled())
            {
                return counterSlots[i];
            }
        }

        //return last slot as fallback
        return counterSlots[counterSlots.Count - 1];
    }

    public ItemData[] GetAllCurrentItems()
    {
        List<ItemData> allItems = new List<ItemData>();

        foreach (var item in counterSlots)
        {
            if (item.GetFilled())
            {
                ItemData itemData = item.GetStoreItem().GetData();
                allItems.Add(itemData);
            }
        }

        //convert to array again
        return allItems.ToArray();
    }

    /// <summary>
    /// Getter function to avoid public field
    /// </summary>
    /// <returns></returns>
    public int GetMaxItems()
    {
        return maxItems;
    }
}

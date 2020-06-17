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
}

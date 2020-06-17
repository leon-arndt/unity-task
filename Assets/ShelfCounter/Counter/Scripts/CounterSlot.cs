using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to carry data for each position on the counter
/// </summary>
public class CounterSlot : MonoBehaviour {
    [SerializeField]
    private bool filled = false;

    [SerializeField]
    private StoreItem current = null;

    /// <summary>
    /// Set the store item
    /// </summary>
    /// <param name="item"></param>
    public void Set(StoreItem item)
    {
        current = item;

        if (item == null)
        {
            filled = false;
        }
        else
        {
            filled = true;
        }
    }

    /// <summary>
    /// Get the value of the item inside this slot
    /// </summary>
    /// <returns></returns>
    public float GetCost()
    {
        float cost = 0;

        //avoid null exception
        if (current != null)
        {
            if (current.GetData() != null)
            {
                cost = current.GetData().cost;
            }
        }

        return cost;
    }

    /// <summary>
    /// Is this counter slot filled with an item?
    /// </summary>
    /// <returns></returns>
    public bool GetFilled()
    {
        return filled;
    }

    /// <summary>
    /// Get the current store item if one exists in the slot
    /// </summary>
    /// <returns></returns>
    public StoreItem GetStoreItem()
    {
        //could be upgraded to avoid null exception
        return current;
    }
}

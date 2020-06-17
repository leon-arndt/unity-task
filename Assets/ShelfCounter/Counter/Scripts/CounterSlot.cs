using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for each position on the counter
/// </summary>
public class CounterSlot : MonoBehaviour {
    [SerializeField]
    private bool filled = false;

    [SerializeField]
    private StoreItem current = null;

	// Use this for initialization
	void Start () {
		
	}

    /// <summary>
    /// Set the store item
    /// </summary>
    /// <param name="item"></param>
    public void Set(StoreItem item)
    {
        current = item;
    }

    /// <summary>
    /// Get the value of the item inside this slot
    /// </summary>
    /// <returns></returns>
    public float GetCost()
    {
        return current.GetData().cost;
    }

    /// <summary>
    /// Is this counter slot filled with an item?
    /// </summary>
    /// <returns></returns>
    public bool GetFilled()
    {
        return filled;
    }

    public void SetFilled(bool filled)
    {
        this.filled = filled;
    }
}

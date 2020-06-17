using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCopy : Interactable {
    private CounterSlot slot;

    public override void Interact()
    {
        //set counter as free
        slot.Set(null);

        //destroy gameobject
        Destroy(gameObject);
    }

    public void SetCounterSlot(CounterSlot slot)
    {
        this.slot = slot;
    }
}

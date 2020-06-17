using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this class to add behavior to the person in the world
/// </summary>
public class Person : Interactable {
    [SerializeField]
    private Animator anim;

	// Use this for initialization
	void Start () {
		
	}

    public override void Interact()
    {
        Wave();
    }

    private void Wave()
    {
        anim.SetTrigger("Wave");
    }
}

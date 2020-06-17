using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Written by Leon Arndt
/// Allows the player to click on interactables in the world in order to interact with them
/// </summary>
public class InteractableClicker : MonoBehaviour
{
    private void Update()
    {
        HandleInput();
    }

    /// <summary>
    /// Returns true when an interactable was clicked
    /// </summary>
    public static void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TestPositionForInteractable(true);
        }
    }

    public static bool TestPositionForInteractable(bool click)
    {
        //Raycast test
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //~0 refers to all layers
        if (Physics.Raycast(ray, out hit, 30f, ~0, QueryTriggerInteraction.Ignore))
        {
            //Test if interactable
            var interactable = hit.transform.GetComponent<Interactable>();
            if (interactable != null)
            {
                if (click)
                {
                    //handle clicked function on interactable
                    interactable.Interact();

                    { print("Clicked on: " + hit.transform.name); }
                }

                return true;
            }
        }

        return false;
    }
}


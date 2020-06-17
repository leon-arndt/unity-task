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
    /// <returns>A character was clicked</returns>
    public static bool HandleInput()
    {
        //No character can be clicked if the mouse is not pressed down
        if (!Input.GetMouseButton(0))
        {
            return false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            return TestPositionForInteractable(true);
        }

        if (Input.GetMouseButton(0))
        {
            if (!TestPositionForInteractable(false))
            {
                //Debug.Log("mouse down but not on character");
                return false;
            }
        }

        return true;
    }

    public static bool TestPositionForInteractable(bool click)
    {
        //Raycast test
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //~0 refers to all layers
        if (Physics.Raycast(ray, out hit, 30f, ~0, QueryTriggerInteraction.Ignore))
        //if (Physics.Raycast(ray, out hit))
        {
            //Test if interactable
            var character = hit.transform.GetComponent<Interactable>();
            if (character != null)
            {
                if (click)
                {
                    //handle clicked function on character
                    character.Interact();

                    { print("Clicked on: " + hit.transform.name); }
                }

                return true;
            }
        }

        return false;
    }
}


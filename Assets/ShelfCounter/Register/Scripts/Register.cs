using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The register can be clicked to display purchase information
/// </summary>
public class Register : Interactable {

    public override void Interact()
    {
        NotifyOfBasketAndCosts();
    }

    /// <summary>
    /// Tell the user what they are going to purchase and how much it will cost
    /// </summary>
    private void NotifyOfBasketAndCosts()
    {
        string notifyString = string.Empty;

        Counter counter = FindObjectOfType<Counter>();
        int itemCount = counter.GetAllCurrentItems().Length;

        if (itemCount == 0)
        {
            InformToAddItems();
        }
        else
        {
            BuildPurchaseString();
        }
    }

    private void InformToAddItems()
    {
        //create dialogue scene by building it from dialogue segments
        DialogueManager dialogue = FindObjectOfType<DialogueManager>();
        DialogueSegment segment1 = new DialogueSegment("You need to add something to the counter first.");
        DialogueSegment segment2 = new DialogueSegment("Click the items in the shelf on the left to add them.");

        //combine the scene
        DialogueScene scene = new DialogueScene(new DialogueSegment[] { segment1, segment2 });

        //display the dialogue
        dialogue.LoadDialogueScene(scene);
        dialogue.EnterDialogue();
    }

    /// <summary>
    /// Tally up all the different items
    /// </summary>
    private void BuildPurchaseString()
    {
        //get total cost
        Counter counter = FindObjectOfType<Counter>();
        float totalPrice = counter.GetTotalCost();

        //get items list
        string purchases = "You are going to purchase ";

        ItemData[] items = counter.GetAllCurrentItems();
        foreach (ItemData item in items)
        {
            purchases += item.itemName + ", ";
        }

        //format the price float ###,###.##
        string formattedPrice = totalPrice.ToString("N");
        string costString = "Which will cost you " + formattedPrice + "€ alltogether.";
        

        //create dialogue scene by building it from dialogue segments
        DialogueManager dialogue = FindObjectOfType<DialogueManager>();
        DialogueSegment segment1 = new DialogueSegment(purchases);
        DialogueSegment segment2 = new DialogueSegment(costString);

        //combine the scene
        DialogueScene scene = new DialogueScene(new DialogueSegment[] { segment1, segment2 });

        //display the dialogue
        dialogue.LoadDialogueScene(scene);
        dialogue.EnterDialogue();
    }
}

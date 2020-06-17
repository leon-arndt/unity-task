using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        List<string> itemNames = new List<string>();
        foreach (var item in items)
        {
            itemNames.Add(item.itemName);
        }

        //add commas to the items string and a period
        string itemsString = Commaize(itemNames);
        purchases += itemsString + ".";

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
    /// <summary>
    /// Notify the player that they have placed too many items on the counter
    /// </summary>
    public void NotifyTooManyItems()
    {
        //create dialogue scene by building it from dialogue segments
        DialogueManager dialogue = FindObjectOfType<DialogueManager>();
        DialogueSegment segment1 = new DialogueSegment("You can only have five items at once.");
        DialogueSegment segment2 = new DialogueSegment("Please remove an item on the counter by clicking on it.");

        //combine the scene
        DialogueScene scene = new DialogueScene(new DialogueSegment[] { segment1, segment2 });

        //display the dialogue
        dialogue.LoadDialogueScene(scene);
        dialogue.EnterDialogue();
    }

    //provided by Thomas Levesque (https://stackoverflow.com/questions/4239858/a-better-way-to-comma-and-and-ize-an-ienumerable-in-c-sharp)
    string Commaize(IEnumerable<string> sequence)
    {
        IList<string> list = sequence as IList<string>;
        if (list == null)
            list = sequence.ToList();
        if (list.Count == 0)
            return "";
        else if (list.Count == 1)
            return list.First();
        else
            return string.Join(", ", list.Take(list.Count - 1).ToArray()) + " and " + list.Last();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Dialogue Manager written by Leon Arndt.
/// Combines both Logic and UI. Uses data from the DialogueScene object.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    public UnityEvent dialogueFinished;

    [SerializeField]
    private DialogueScene dialogueScene;

    //private Translator translator;

    private DialogueSegment currentDialogueSegment;
    private string currentTranslatedDialogueText;

    [SerializeField]
    private Text dialogueText;

    [SerializeField]
    private GameObject dialogueBox;

    public bool inDialogue;
    private bool listeningForSkips = false;
    private int currentDialogueSegmentIndex = 0;
    private float startTime;
    private const float lettersPerSecond = 32f;

    private void Start()
    {
        HideTextBox();
        if (dialogueFinished == null)
            dialogueFinished = new UnityEvent();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (inDialogue)
        {
            int length = Mathf.Min(currentTranslatedDialogueText.Length, (int)(lettersPerSecond * (Time.time - startTime)));

            //display letter after letter
            if (dialogueText.text != currentTranslatedDialogueText)
            {
                dialogueText.text = currentTranslatedDialogueText.Substring(0, length);
            }

            //Skip dialogue text
            if (GetValidSkip())
            {
                //show all text
                if (dialogueText.text != currentTranslatedDialogueText)
                {
                    dialogueText.text = currentTranslatedDialogueText;
                }
                else
                //if there are more dialogue segments to display, display a new one
                if (currentDialogueSegmentIndex < dialogueScene.segments.Length - 1)
                {
                    currentDialogueSegmentIndex++;
                    currentDialogueSegment = dialogueScene.segments[currentDialogueSegmentIndex];
                    currentTranslatedDialogueText = currentDialogueSegment.dialogueString;
                    ClearTextBox();
                }
                else
                {
                    //dialogue is finished
                    if (dialogueFinished != null)
                    {
                        dialogueFinished.Invoke();
                        dialogueFinished = null;
                    }

                    HideTextBox();
                }
            }
        }
    }

    private bool GetValidSkip()
    {
        if (!listeningForSkips) return false;

        return Input.GetKeyDown(KeyCode.Space)
            || Input.GetMouseButtonDown(0);
    }

    private void ClearTextBox()
    {
        startTime = Time.time;
        dialogueText.text = "";
    }

    public void LoadDialogueScene(DialogueScene newDialogueScene)
    {
        dialogueScene = newDialogueScene;
    }

    public void EnterDialogue()
    {
        listeningForSkips = false;
        startTime = Time.time;
        ClearTextBox();
        currentDialogueSegmentIndex = 0;
        currentDialogueSegment = dialogueScene.segments[0];
        currentTranslatedDialogueText = currentDialogueSegment.dialogueString;
        dialogueBox.SetActive(true);
        inDialogue = true;

        //start listening after 0.1f seconds
        Invoke("StartListeningForSkips", 0.1f);
    }

    private void HideTextBox()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
    }

    private void StartListeningForSkips()
    {
        listeningForSkips = true;
    }

    /// <summary>
    /// Handy getter to avoid triggering dialogue multiple times
    /// </summary>
    /// <returns></returns>
    public bool InDialogue()
    {
        return inDialogue;
    }
}

#region Data

public struct DialogueSegment
{
    public string dialogueString;

    public DialogueSegment(string dialogueString)
    {
        this.dialogueString = dialogueString;
    }
}

public struct DialogueScene
{
    public DialogueSegment[] segments;

    public DialogueScene(DialogueSegment[] segments)
    {
        this.segments = segments;
    }
}
#endregion
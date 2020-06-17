using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle the UI for the permutation check
/// </summary>
public class PermutationUi : MonoBehaviour {
    //local fields to cache strings
    private string topString = string.Empty;
    private string bottomString = string.Empty;

    [SerializeField]
    Text resultText;

    //game view feedback for matches
    private readonly string ifMatch = "The strings are permutations";
    private readonly string ifNoMatch = "The strings are not permutations";

    /// <summary>
    /// Compare the strings when the input field text is changed by the user
    /// </summary>
    /// <param name="given"></param>
    public void CompareStrings(string top, string bottom)
    {
        bool match = PermutationCheck.IsPermutation(top, bottom);

        if (match)
        {
            resultText.text = ifMatch;
        }
        else
        {
            resultText.text = ifNoMatch;
        }
    }

    #region INSPECTOR_FUNCTIONS
    public void UpdateTop(string replacement)
    {
        topString = replacement;
        CompareStrings(topString, bottomString);
    }

    public void UpdateBottom(string replacement)
    {
        bottomString = replacement;
        CompareStrings(topString, bottomString);
    }
    #endregion
}

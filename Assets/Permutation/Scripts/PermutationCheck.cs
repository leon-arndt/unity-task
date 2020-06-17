using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Compare two strings to identify whether a permutation exists
/// </summary>
public class PermutationCheck
{

    /// <summary>
    /// Compare the string given in the UI against the string set in the GameObject
    /// </summary>
    /// <param name="given">string given in the UI</param>
    public static bool IsPermutation(string baseString, string given)
    {
        /*
         * for strings to be a permutation they must contain the same letters the same number of times.
         * A simple way to check this is to try to subtract letters 
         * from the given string and exit early (return false) if not possible.
         * But first off, the length of the strings needs to match
         */

        //exit early if the string lengths do not match
        if (given.Length != baseString.Length)
        {
            return false;
        }

        //change both strings to lowercase to avoid casing differences
        baseString = baseString.ToLower();
        given = given.ToLower();

        //make sure that the original string remains unaltered
        char[] charArray = given.ToCharArray();
        List<char> givenCopy = charArray.ToList<char>();

        foreach (char letter in baseString)
        {
            //does the given string contain the letter?
            if (givenCopy.Contains(letter))
            {
                //remove the letter from the given copy
                givenCopy.Remove(letter);
            }
            else
            {
                //since we are missing a character, a permutation can not exist
                return false;
            }
        }

        //we have a permutation since all required letters were removed and string length matches
        return true;
    }
}

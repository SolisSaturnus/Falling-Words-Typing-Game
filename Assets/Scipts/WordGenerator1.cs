using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{

    private static string[] wordList = { "fade", "after", "thought", "stove", "spot", "waves", "responsible", "maddening", "sassy", "shade", "history", "rabbit", "recess", "nose", "taste", "less", "volatile", "square", "texture", "skirt", 
        "truck", "houses", "hair", "slap", "gold", "hospitable", "secretive", "political", "naughty", "open", "sink", "secret", "curly", "orange", "melt", "average", "time", "bumpy", "credit", "industry", "creepy", "poison", 
        "search", "damage", "rob", "bottle", "distinct", "charming", "gullible", "capable", "cemetery", "gaudy"};
    public static string GetRandomWord ()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}

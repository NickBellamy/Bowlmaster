using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour 
{
    public Text[] rollTexts, frameTexts;

    public void FillRolls(List<int> rolls)
    {
        string scoresString = FormatRolls(rolls);
        for (int i = 0; i < scoresString.Length; i++)
        {
            rollTexts[i].text = scoresString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";

        for (int i = 0; i < rolls.Count; i++)
        {
            //spare
            if ((output.Length % 2 == 1 || output.Length == 20) && rolls[i] + rolls[i - 1] == 10)
            { 
                output += "/";
            }
            //strike
            else if (rolls[i] == 10)
            {
                output += output.Length < 18 ? "X " : "X";
            }
            //miss
            else if (rolls[i] == 0)
            {
                output += "-";
            }
            //normal
            else
            {
                output += rolls[i].ToString();
            }
        }

        return output;
    }
}

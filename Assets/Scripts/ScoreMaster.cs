using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster
{
    // Returns a list of cumulative scores, like a normal Scorecard.
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }
        return cumulativeScores;

    }

    // Return a list of individual frame scores.
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        for (int i = 2; i <= rolls.Count; i += 2)
        {

            int frameFirstBowl = rolls[i - 2];
            int frameSecondBowl = rolls[i - 1];

            // If strike or spare
            if (frameFirstBowl == 10 || frameFirstBowl + frameSecondBowl == 10)
            {

                // If next 2 bowls have been bowled
                if (i < rolls.Count)
                {
                    frameList.Add(rolls[i - 2] + rolls[i - 1] + rolls[i]);
                    i -= frameFirstBowl / 10;
                }
            }

            // If all frames not full
            else if (frameList.Count <= 9)
            {
                frameList.Add(frameFirstBowl + frameSecondBowl);
            }
        }
        return frameList;
    }
}

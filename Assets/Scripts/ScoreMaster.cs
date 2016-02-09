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
        #region Old Code
        ////The below code works, but the subsequent uncomment code in this method is more elegant!

        //List<int> frameList = new List<int>();

        //for (int i = 2; i <= rolls.Count; i += 2)
        //{

        //    int frameFirstBowl = rolls[i - 2];
        //    int frameSecondBowl = rolls[i - 1];

        //    // If strike or spare
        //    if (frameFirstBowl == 10 || frameFirstBowl + frameSecondBowl == 10)
        //    {

        //        // If next 2 bowls have been bowled
        //        if (i < rolls.Count)
        //        {
        //            frameList.Add(rolls[i - 2] + rolls[i - 1] + rolls[i]);
        //            i -= frameFirstBowl / 10;
        //        }
        //    }

        //    // If all frames not full
        //    else if (frameList.Count <= 9)
        //    {
        //        frameList.Add(frameFirstBowl + frameSecondBowl);
        //    }
        //}
        //return frameList;
        #endregion
        List<int> frames = new List<int>();

        for (int i = 1; i < rolls.Count && frames.Count < 10; i += 2)
        {
            // If normal open frame
            if (rolls[i - 1] + rolls[i] < 10)
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            // Else if there are at least 2 bowls ahead
            else if (rolls.Count - i >= 2)
            {
                frames.Add(rolls[i - 1] + rolls[i] + rolls[i + 1]);
                i -= rolls[i - 1] / 10;
            }
        }
        return frames;
    }
}

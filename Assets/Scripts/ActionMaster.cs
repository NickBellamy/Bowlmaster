using UnityEngine;
using System.Collections;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame};

    private int bowl = 1;
    private int lastBallScore;

	public Action Bowl(int pins)
    {
        // Handles the last 3 balls
        if (bowl >= 20 || (bowl == 19 && pins == 10))
        {
            if (lastBallScore + pins != 10 || bowl == 21)
            {
                return Action.EndGame;
            }

            if (bowl == 19)
            {
                lastBallScore = pins;
            }

            bowl++;
            return Action.Reset;
        }

        // If first bowl of frame and not a strike
        if (bowl % 2 != 0 && pins != 10)
        {
            lastBallScore = pins;
            bowl++;
            return Action.Tidy;
        }

        // Second bowl of frame or strike
        lastBallScore = 0;
        bowl += (bowl % 2) + 1;
        return Action.EndTurn;    
    }
}

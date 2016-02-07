using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame};

    private int bowl = 0;
    private int lastBallScore;

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster am = new ActionMaster();
        Action returnAction = new Action();

        foreach (int pinFall in pinFalls)
        {
             returnAction = am.Bowl(pinFall);
        }
        return returnAction;
    }

	private Action Bowl(int pins)
    {
       bowl++;

        // Handles bowl 20, 21, and 19 if 19 is a strike
        if (bowl >= 20 || (bowl == 19 && pins == 10))
        {
            if (lastBallScore + pins < 10 || bowl == 21)
            {
                return Action.EndGame;
            }

            if (lastBallScore == 10 && pins != 10)
            {
                return Action.Tidy;
            }

            lastBallScore = pins;
            return Action.Reset;
        }

        // If first bowl of frame and not a strike
        if (bowl % 2 != 0 && pins != 10)
        {
            lastBallScore = pins;
            return Action.Tidy;
        }

        // Second bowl of frame or strike
        lastBallScore = 0;
        bowl += (bowl % 2);
        return Action.EndTurn;    
    }
}

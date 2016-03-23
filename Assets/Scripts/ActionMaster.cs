﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster
{
    public enum Action { Tidy, Reset, EndTurn, EndGame, Undefined };

    public static Action NextAction(List<int> rolls)
    {
        Action nextAction = Action.Undefined;

        for (int i = 0; i < rolls.Count; i++)
        {
            if (i == 20)
            {
                nextAction = Action.EndGame;
            }
            // Handle last-frame special cases
            else if (i >= 18 && rolls[i] == 10)
            {
                nextAction = Action.Reset;
            }
            else if (i == 19)
            {
                if (rolls[18] == 10 && rolls[19] == 0)
                {
                    nextAction = Action.Tidy;
                }
                else if (rolls[18] + rolls[19] == 10)
                {
                    nextAction = Action.Reset;
                }
                // Roll 21 awarded
                else if (rolls[18] + rolls[19] >= 10)
                {
                    nextAction = Action.Tidy;
                }
                else {
                    nextAction = Action.EndGame;
                }
            }
            // First bowl of frame
            else if (i % 2 == 0)
            { 
                if (rolls[i] == 10)
                {
                    // Insert virtual 0 after strike
                    rolls.Insert(i, 0); 
                    nextAction = Action.EndTurn;
                }
                else {
                    nextAction = Action.Tidy;
                }
            }
            // Second bowl of frame
            else
            { 
                nextAction = Action.EndTurn;
            }
        }

        return nextAction;
    }
}
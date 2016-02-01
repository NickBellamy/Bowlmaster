﻿using UnityEngine;
using System.Collections;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame};

	public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid pin count");
        }
        if (pins == 10)
        {
            return Action.EndTurn;
        }

        throw new UnityException("Not sure which action to return!");
    }
}

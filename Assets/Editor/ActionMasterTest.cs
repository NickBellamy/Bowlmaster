using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster actionMaster;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]
    public void SetUp()
    {
        actionMaster = new ActionMaster();
    }

    [Test]
    public void T00_PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01_OneStrikeReturnsEndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T03_Bowl8ReturnsTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T04_Bowl28SpareReturnsEndTurn()
    {
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }

    [Test]
    public void T05_BowlStrikeLastFrameReturnsReset()
    {
        for (int i = 1; i <= 9; i++)
        {
            actionMaster.Bowl(10);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T06_BowlSpareLastFrameReturnsReset()
    {
        for (int i = 1; i <= 9; i++)
        {
            actionMaster.Bowl(10);
        }
        actionMaster.Bowl(7);
        Assert.AreEqual(reset, actionMaster.Bowl(3));
    }

    [Test]
    public void T07_Bowl34LastFrameReturnsEndGame()
    {
        for (int i = 1; i <= 9; i++)
        {
            actionMaster.Bowl(10);
        }
        actionMaster.Bowl(3);
        Assert.AreEqual(endGame, actionMaster.Bowl(4));
    }

    [Test]
    public void T08_BowlAllStrikesReturnsEndGameAfterFinalBall()
    {
        for (int i = 1; i <= 11; i++)
        {
            actionMaster.Bowl(10);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }

    [Test]
    public void T09_SpareInFrame9PlaysCorrectly()
    {
        for (int i = 1; i <= 8; i++)
        {
            actionMaster.Bowl(10);
        }
        actionMaster.Bowl(3);
        actionMaster.Bowl(7);
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T10_StrikeFrame10ThenGutterBallReturnsTidy()
    {
        for (int i = 1; i <= 18; i++)
        {
            actionMaster.Bowl(1);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }

    [Test]
    public void T11_TestGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(9));
    }

    [Test]
    public void T12_PerfectGame()
    {
        for (int i = 1; i <= 11; i++)
        {
            actionMaster.Bowl(10);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }
    [Test]
    public void T13_StrikeLastFrameThenKnockOver5PinsReturnTidy()
    {
        for (int i = 1; i <= 18; i++)
        {
            actionMaster.Bowl(1);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(5));
    }
    [Test]
    public void T14_ConsecutiveGutterballsInFrame10ReturnEndGame()
    {
        for (int i = 1; i <= 18; i++)
        {
            actionMaster.Bowl(1);
        }
        actionMaster.Bowl(0);
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }
    [Test]
    public void T15_DoubleStrikesInLastFrameReturnReset()
    {
        for (int i = 1; i <= 18; i++)
        {
            actionMaster.Bowl(1);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }
    [Test]
    public void T16_Frame10StrikeThen5Then2ReturnsEndGame()
    {
        for (int i = 1; i <= 18; i++)
        {
            actionMaster.Bowl(1);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(5);
        Assert.AreEqual(endGame, actionMaster.Bowl(2));
    }
}

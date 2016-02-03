using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class SystematicTest
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

    [Test, Category("Frame 1 to 9")]
    public void T01_BowlZeroReturnsTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 1 to 9")]
    public void T02_BowlScoreReturnsTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 1 to 9")]
    public void T03_BowlStrikeReturnsEndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }


    [Test, Category("Frame 1 to 9")]
    public void T04_BowlZeroZeroReturnsEndTurn()
    {
        int[] rolls = { 0 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endTurn, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 1 to 9")]
    public void T05_BowlZeroScoreReturnsEndTurn()
    {
        int[] rolls = { 0 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 1 to 9")]
    public void T06_BowlZeroSpareReturnsEndTurn()
    {
        int[] rolls = { 0 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test, Category("Frame 1 to 9")]
    public void T07_BowlScoreZeroReturnsEndTurn()
    {
        int[] rolls = { 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endTurn, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 1 to 9")]
    public void T08_BowlScoreScoreReturnsEndTurn()
    {
        int[] rolls = { 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 1 to 9")]
    public void T09_BowlScoreSpareReturnsEndTurn()
    {
        int[] rolls = { 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endTurn, actionMaster.Bowl(9));
    }

    [Test, Category("Frame 10")]
    public void T10_Frame10ScoreReturnsTidy()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(tidy, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T11_Frame10ZeroReturnsTidy()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T12_Frame10StrikeReturnsReset()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test, Category("Frame 10")]
    public void T13_Frame10ScoreSpareReturnsReset()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        Assert.AreEqual(reset, actionMaster.Bowl(9));
    }

    [Test, Category("Frame 10")]
    public void T14_Frame10ZeroSpareReturnsReset()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(0);
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test, Category("Frame 10")]
    public void T15_Frame10StrikeScoreReturnsTidy()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T16_Frame10StrikeZeroReturnsTidy()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T17_Frame10StrikeStrikeReturnsReset()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test, Category("Frame 10")]
    public void T18_Frame10ScoreScoreReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T19_Frame10ScoreZeroReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T20_Frame10ZeroScoreReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(0);
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T21_Frame10ZeroZeroReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(0);
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T22_Frame10ScoreSpareScoreReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        actionMaster.Bowl(9);
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T23_Frame10ScoreSpareZeroReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        actionMaster.Bowl(9);
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T24_Frame10ZeroSpareScoreReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(0);
        actionMaster.Bowl(10);
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T25_Frame10ZeroSpareZeroReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(0);
        actionMaster.Bowl(10);
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T26_Frame10ScoreSpareStrikeReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        actionMaster.Bowl(9);
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }

    [Test, Category("Frame 10")]
    public void T27_Frame10ZeroSpareStrikeReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(0);
        actionMaster.Bowl(10);
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }

    [Test, Category("Frame 10")]
    public void T28_Frame10StrikeScoreScoreReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(1);
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T29_Frame10StrikeScoreZeroReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(1);
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T30_Frame10StrikeZeroScoreReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(0);
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T31_Frame10StrikeZeroZeroReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(0);
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T32_Frame10StrikeScoreSpareReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(1);
        Assert.AreEqual(endGame, actionMaster.Bowl(9));
    }

    [Test, Category("Frame 10")]
    public void T33_Frame10StrikeZeroSpareReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(0);
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }

    [Test, Category("Frame 10")]
    public void T34_Frame10StrikeStrikeScoreReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(10);
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test, Category("Frame 10")]
    public void T35_Frame10StrikeStrikeZeroReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(10);
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }

    [Test, Category("Frame 10")]
    public void T36_Frame10StrikeStrikeStrikeReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(10);
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }

    [Test, Category("Example Game")]
    public void T37_PerfectGame()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }

    [Test, Category("Example Game")]
    public void T38_WorstGame()
    {
        int[] rolls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(0));
    }

    [Test, Category("Example Game")]
    // https://www.youtube.com/watch?v=aBe71sD8o8c
    public void T39_YouTubeGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2};
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(9));
    }
}
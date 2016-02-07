using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class SystematicTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;


    private void AreEqual(int[] bowls, ActionMaster.Action action)
    {
        Assert.AreEqual(action, ActionMaster.NextAction(bowls.ToList()));
    }


    [Test, Category("Frame 1 to 9")]
    public void T01_BowlZeroReturnsTidy()
    {
        int[] bowls = { 0 };
        AreEqual(bowls, tidy);
    }

    [Test, Category("Frame 1 to 9")]
    public void T02_BowlScoreReturnsTidy()
    {
        int[] bowls = { 1 };
        AreEqual(bowls, tidy);
    }

    [Test, Category("Frame 1 to 9")]
    public void T03_BowlStrikeReturnsEndTurn()
    {
        int[] bowls = { 10 };
        AreEqual(bowls, endTurn);
    }


    [Test, Category("Frame 1 to 9")]
    public void T04_BowlZeroZeroReturnsEndTurn()
    {
        int[] bowls = { 0, 0 };
        AreEqual(bowls, endTurn);
    }

    [Test, Category("Frame 1 to 9")]
    public void T05_BowlZeroScoreReturnsEndTurn()
    {
        int[] bowls = { 0, 1 };
        AreEqual(bowls, endTurn);
    }

    [Test, Category("Frame 1 to 9")]
    public void T06_BowlZeroSpareReturnsEndTurn()
    {
        int[] bowls = { 0, 10 };
        AreEqual(bowls, endTurn);
    }

    [Test, Category("Frame 1 to 9")]
    public void T07_BowlScoreZeroReturnsEndTurn()
    {
        int[] bowls = { 1, 0 };
        AreEqual(bowls, endTurn);
    }

    [Test, Category("Frame 1 to 9")]
    public void T08_BowlScoreScoreReturnsEndTurn()
    {
        int[] bowls = { 1, 1 };
        AreEqual(bowls, endTurn);
    }

    [Test, Category("Frame 1 to 9")]
    public void T09_BowlScoreSpareReturnsEndTurn()
    {
        int[] bowls = { 1, 9 };
        AreEqual(bowls, endTurn);
    }

    [Test, Category("Frame 10")]
    public void T10_Frame10ScoreReturnsTidy()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        AreEqual(bowls, tidy);
    }

    [Test, Category("Frame 10")]
    public void T11_Frame10ZeroReturnsTidy()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        AreEqual(bowls, tidy);
    }

    [Test, Category("Frame 10")]
    public void T12_Frame10StrikeReturnsReset()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        AreEqual(bowls, reset);
    }

    [Test, Category("Frame 10")]
    public void T13_Frame10ScoreSpareReturnsReset()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
        AreEqual(bowls, reset);
    }

    [Test, Category("Frame 10")]
    public void T14_Frame10ZeroSpareReturnsReset()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 10 };
        AreEqual(bowls, reset);
    }

    [Test, Category("Frame 10")]
    public void T15_Frame10StrikeScoreReturnsTidy()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1 };
        AreEqual(bowls, tidy);
    }

    [Test, Category("Frame 10")]
    public void T16_Frame10StrikeZeroReturnsTidy()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
        AreEqual(bowls, tidy);
    }

    [Test, Category("Frame 10")]
    public void T17_Frame10StrikeStrikeReturnsReset()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10 };
        AreEqual(bowls, reset);
    }

    [Test, Category("Frame 10")]
    public void T18_Frame10ScoreScoreReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T19_Frame10ScoreZeroReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T20_Frame10ZeroScoreReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T21_Frame10ZeroZeroReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T22_Frame10ScoreSpareScoreReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 1 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T23_Frame10ScoreSpareZeroReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 0 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T24_Frame10ZeroSpareScoreReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 10, 1 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T25_Frame10ZeroSpareZeroReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 10, 0 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T26_Frame10ScoreSpareStrikeReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 10 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T27_Frame10ZeroSpareStrikeReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 10, 10 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T28_Frame10StrikeScoreScoreReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T29_Frame10StrikeScoreZeroReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 0 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T30_Frame10StrikeZeroScoreReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0, 1 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T31_Frame10StrikeZeroZeroReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0, 0 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T32_Frame10StrikeScoreSpareReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 9 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T33_Frame10StrikeZeroSpareReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0, 10 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T34_Frame10StrikeStrikeScoreReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 1 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T35_Frame10StrikeStrikeZeroReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 0 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Frame 10")]
    public void T36_Frame10StrikeStrikeStrikeReturnsEndGame()
    {
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Example Game")]
    public void T37_PerfectGame()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Example Game")]
    public void T38_WorstGame()
    {
        int[] bowls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        AreEqual(bowls, endGame);
    }

    [Test, Category("Example Game")]
    // https://www.youtube.com/watch?v=aBe71sD8o8c
    public void T39_YouTubeGame()
    {
        int[] bowls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        AreEqual(bowls, endGame);
    }
}
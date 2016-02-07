using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;


    private void AreEqual(int[] bowls, ActionMaster.Action action)
    {
        Assert.AreEqual(action, ActionMaster.NextAction(bowls.ToList()));
    }


    [Test]
    public void T01_OneStrikeReturnsEndTurn()
    {
        int[] bowls = { 10 };
        AreEqual(bowls, endTurn);
    }

    [Test]
    public void T03_Bowl8ReturnsTidy()
    {
        int[] bowls = { 8 };
        AreEqual(bowls, tidy);
    }

    [Test]
    public void T04_Bowl28SpareReturnsEndTurn()
    {
        int[] bowls = { 8, 2 };
        AreEqual(bowls, endTurn);
    }

    [Test]
    public void T05_BowlStrikeLastFrameReturnsReset()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        AreEqual(bowls, reset);
    }

    [Test]
    public void T06_BowlSpareLastFrameReturnsReset()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 3, 7 };
        AreEqual(bowls, reset);
    }

    [Test]
    public void T07_Bowl34LastFrameReturnsEndGame()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 3, 4 };
        AreEqual(bowls, endGame);
    }

    [Test]
    public void T08_BowlAllStrikesReturnsEndGameAfterFinalBall()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        AreEqual(bowls, endGame);
    }

    [Test]
    public void T09_SpareInFrame9PlaysCorrectly()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 3, 7, 10 };
        AreEqual(bowls, reset);
    }

    [Test]
    public void T10_StrikeFrame10ThenGutterBallReturnsTidy()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0 };
        AreEqual(bowls, tidy);
    }

    [Test]
    public void T11_TestGame()
    {
        int[] bowls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        AreEqual(bowls, endGame);
    }

    [Test]
    public void T12_PerfectGame()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        AreEqual(bowls, endGame);
    }

    [Test]
    public void T13_StrikeLastFrameThenKnockOver5PinsReturnTidy()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5 };
        AreEqual(bowls, tidy);
    }

    [Test]
    public void T14_ConsecutiveGutterballsInFrame10ReturnEndGame()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 0, 0 };
        AreEqual(bowls, endGame);
    }

    [Test]
    public void T15_DoubleStrikesInLastFrameReturnReset()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        AreEqual(bowls, reset);
    }

    [Test]
    public void T16_Frame10StrikeThen5Then2ReturnsEndGame()
    {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5, 2 };
        AreEqual(bowls, endGame);
    }

    [Test]
    public void T17_NathansTest()
    {
        int[] bowls = { 0 , 10, 5 , 1 };
        AreEqual(bowls, endTurn);
    }
}

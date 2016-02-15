using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    private List<int> bowls = new List<int>();
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

	void Start () 
	{
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
	}
	
    public void Bowl (int pinFall)
    {
        try
        {
            bowls.Add(pinFall);
            ball.Reset();
            pinSetter.PerformAction(ActionMaster.NextAction(bowls));
        }
        catch
        {
            Debug.LogWarning("Something went wrong in Bowl()");
        }

        try
        {
            scoreDisplay.FillRollCard(bowls);
        }
        catch
        {
            Debug.Log("Something went wrong in FillRollCard()");
        }
    }
}

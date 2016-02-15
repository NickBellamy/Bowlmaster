using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour 
{
    public Text[] rollsTexts, frameTexts;

    void Start()
    {
        rollsTexts[0].text = "X";
        frameTexts[0].text = "0";
    }

    public void FillRollCard(List<int> rolls)
    {

    }
}

﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]

public class DragLaunch : MonoBehaviour
{
    private Ball ball;
    private Vector3 startPos, endPos;
    private float startTime, endTime;

	void Start()
    {
        ball = GetComponent<Ball>();
	}

    public void DragStart()
    {
        startPos = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {
        endPos = Input.mousePosition;
        endTime = Time.time;

        float dragTime = endTime - startTime;

        float launchSpeedX = (endPos.x - startPos.x) / dragTime;
        float launchSpeedZ = (endPos.y - startPos.y) / dragTime;
        Vector3 launchVector = new Vector3(launchSpeedX, 0, launchSpeedZ)/100;

        ball.Launch(launchVector);
    }
}

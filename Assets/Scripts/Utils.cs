using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    const int swHalf = 6;
    const float shHalf = 5.5f;
	public static bool IsOnScreen(GameObject g) {
        //Vector2 camPos = Camera.main.transform.position;
        return Mathf.Abs(g.transform.position.x) < swHalf 
        && Mathf.Abs(g.transform.position.y) < shHalf; 
		/*return g.transform.position.x < camPos.x + swHalf && g.transform.position.x > camPos.x - swHalf &&
		g.transform.localPosition.y < camPos.y + shHalf && g.transform.localPosition.y > camPos.y - shHalf; */
    }
}

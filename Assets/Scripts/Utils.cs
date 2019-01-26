using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    const int swHalf = 8;
    const int shHalf = 5;
	public static bool IsOnScreen(GameObject g) {
        Vector2 camPos = Camera.main.transform.position;
		return g.transform.position.x < camPos.x + swHalf && g.transform.position.x > camPos.x - swHalf &&
		g.transform.localPosition.y < camPos.y + shHalf && g.transform.localPosition.y > camPos.y - shHalf;
    }
}

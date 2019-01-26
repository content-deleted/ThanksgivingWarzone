using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector2 MoveVector;
	float Rotation;
	Action MoveFunc; 
	public bool hostile; //0=hurts enemys 1=hurts player
	public void Init(Vector2 dir, float rot, float spd, Action act, Sprite spr, Color color, bool enemy) {
		SpriteRenderer sp = GetComponent<SpriteRenderer>();
		MoveVector = dir.normalized * spd; 
		Rotation = rot; 
		MoveFunc = act; sp.sprite = spr;
		sp.color = color; hostile = enemy;
	}
	void Update () {
		if (!IsOnScreen()) BulletPool.recall(this.gameObject);//RETURN TO LIST OF BULLETS
		
		Vector2 m = MoveVector * Time.deltaTime;
		transform.localPosition = transform.localPosition+new Vector3(m.x,m.y,0);
        MoveFunc?.Invoke();
    }

	protected bool IsOnScreen() => 
		Math.Abs(transform.localPosition.x) < 10 &&
		Math.Abs(transform.localPosition.y) < 5;
    
    //Move functions 
    public float LeftSine () => -1 * RightSine();
    public float RightSine () => Mathf.Sin(transform.localPosition.y * 25F) * 0.85F;
}

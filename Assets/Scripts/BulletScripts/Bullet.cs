﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector2 MoveVector;
	float Rotation;
	Action MoveFunc; 
	public bool hostile; //0=hurts enemys 1=hurts player

    public bool letter = false;
	public void Init(Vector2 dir, float rot, float spd, MoveFunctions act, Sprite spr, Color color, bool enemy) {
		SpriteRenderer sp = GetComponent<SpriteRenderer>();
		MoveVector = dir.normalized * spd; 
		Rotation = rot; 
		MoveFunc = getMoveFunction(act); sp.sprite = spr;
		sp.color = color; hostile = enemy;
	}

    public void InitText(Vector2 dir, float rot, float spd, MoveFunctions act, bool enemy) {
		MoveVector = dir.normalized * spd; 
		Rotation = rot; 
		MoveFunc = getMoveFunction(act); 
        hostile = enemy;
        letter = true;
	}
	void Update () {
		if (!Utils.IsOnScreen(gameObject)) BulletDestroy ();
		
		Vector2 m = MoveVector * Time.deltaTime;
		transform.localPosition = transform.localPosition+new Vector3(m.x,m.y,0);
        MoveFunc?.Invoke();
    }

    public void BulletDestroy () {
        if(letter) LetterPool.recall(this.gameObject);//RETURN TO LIST OF BULLETS
        else BulletPool.recall(this.gameObject);
    }

    public enum MoveFunctions: int {
        None,
        LeftSine,
        RightSine,
        Spin
    }

    public Action getMoveFunction (MoveFunctions f){
        switch (f) {
            case MoveFunctions.LeftSine: return LeftSine;
            case MoveFunctions.RightSine: return RightSine;
            case MoveFunctions.Spin: return Spin;
            default: return null;
        }
    }

    //Move functions 
    public void LeftSine () => MoveVector = MoveVector * -Mathf.Sin(transform.localPosition.y * 25F) * 0.85F;
    public void RightSine () => MoveVector = MoveVector * Mathf.Sin(transform.localPosition.y * 25F) * 0.85F;
    public void Spin () => transform.Rotate(new Vector3(0,0,5f)); 
}

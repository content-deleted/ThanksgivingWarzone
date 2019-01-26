﻿using System.Collections;
using UnityEngine;
public class BulletSpawner : MonoBehaviour {
	const float tau = 2*Mathf.PI;
	private GameObject bulletTemplate;
	public float bulletSpeed;
	public int bulletAmount;
	public float bulletArc = tau;
	public float ArcOffset = 0;
	private float currentOffset;
	public float bulletfrequency;
	public float spin;
	public float wave;
	private float counter;
	public Sprite bulletSprite;
	public Color bulletTint;
	public Quaternion rotation = Quaternion.AngleAxis(0, Vector3.forward);
	public Vector3 scale = new Vector3(0.05F,0.05F,0.05F);

	void Awake () => bulletTemplate = Resources.Load("bullet") as GameObject;
	void Update () {
		counter += wave;
		currentOffset += spin*Mathf.Cos(counter);
		currentOffset %= bulletArc;
	}
	void Start() => StartCoroutine(SpawnLoop());

    // GameObject.Instantiate(Resources.Load(type)) as GameObject;

	IEnumerator SpawnLoop() { while(true) {
		for (int i = 0; i < bulletAmount; i++) {
			float angle = ArcOffset + (bulletArc/bulletAmount)*i - bulletArc/4 + currentOffset;
			Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            
			var sp = BulletPool.rent();
			sp.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0);
			sp.GetComponent<Bullet>().Init(direction, 0,bulletSpeed,null,bulletSprite, bulletTint, true);
		    
        	sp.transform.localScale = scale;
		}
		yield return new WaitForSeconds(bulletfrequency);
	}}
}

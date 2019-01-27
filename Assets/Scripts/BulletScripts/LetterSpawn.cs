using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
public class LetterSpawn : MonoBehaviour {
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
    public Bullet.MoveFunctions moveFunc;

    private System.Random rand = new System.Random();

	void Awake () => bulletTemplate = Resources.Load("bullet") as GameObject;
	void Update () {
		counter += wave;
		currentOffset += spin*Mathf.Cos(counter);
		currentOffset %= bulletArc;
	}
    public List<string> Topics;
    private List<List<char>> ourStrings; 
	void Start() {
        updateBulletAmount ();
        StartCoroutine(SpawnLoop());
    }

    void updateBulletAmount () {
        ourStrings = new List<List<char>>();
        for (int i = 0; i < bulletAmount; i++){ 
            ourStrings.Add(getNewTopic());
        }
    }

    List<char> getNewTopic () => Topics[rand.Next(Topics.Count()-1)].ToList();

	IEnumerator SpawnLoop() { while(true) {
		for (int i = 0; i < bulletAmount; i++) {
            if(ourStrings[i].Count < 1) 
                ourStrings[i] = getNewTopic();
            char c = ourStrings[i].First();
            ourStrings[i].RemoveAt(0);
            if(c == ' ') continue;

			float angle = ArcOffset + (bulletArc/bulletAmount)*i - bulletArc/4 + currentOffset;
			Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
			var sp = LetterPool.rent();
			sp.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
			sp.GetComponent<Bullet>().InitText(direction, 0,bulletSpeed, moveFunc, true);
		    
        	sp.transform.localScale = scale;

            // now set letter
            sp.GetComponent<TextMesh>().text = c.ToString();
		}
		yield return new WaitForSeconds(bulletfrequency);
	}}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfEsteemBar : MonoBehaviour
{
    public static SelfEsteemBar singleton;
    public GameObject[] parts=new GameObject[3];
    public float fadeOutSpeed;
    void Awake () => singleton = this;
    void Start() => Player.instance.selfEsteem = parts.Length;
    public void decrementSelfEsteemBar(int current)
    => StartCoroutine("Fade", parts[current].GetComponent<SpriteRenderer>());

    public IEnumerator Fade(SpriteRenderer r)
    {
        for (float f = 1; f > 0; f-=0.1f)
        {
            r.color = new Vector4(1,1,1,f);
            yield return new WaitForSeconds(fadeOutSpeed);
        }
    }
}

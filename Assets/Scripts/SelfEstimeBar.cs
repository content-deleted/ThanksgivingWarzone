using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfEsteemBar : MonoBehaviour
{
    public Stack<GameObject> parts=new Stack<GameObject>();
    public float fadeOutSpeed;
    void Start()
    {
        Player.instance.selfEsteem= parts.Count;
    }

    // Update is called once per frame
    void Update()
    {}
    public void decrementSelfEsteemBar()
    {
        StartCoroutine("Fade", parts.Pop().GetComponent<Color>());
    }

    public IEnumerator Fade(Color r)
    {
        for (int f = 255; f > 0; f--)
        {
            r.a = f;
            yield return new WaitForSeconds(fadeOutSpeed);
        }
    }
}

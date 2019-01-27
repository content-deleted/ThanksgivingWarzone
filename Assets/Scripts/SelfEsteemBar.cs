using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfEsteemBar : MonoBehaviour
{
    public GameObject[] parts=new GameObject[3];
    private int current=0;
    public float fadeOutSpeed;
    void Start()
    {
        Player.instance.selfEsteem= parts.Length;
    }

    // Update is called once per frame
    void Update()
    {}
    public void decrementSelfEsteemBar()
    {
        StartCoroutine("Fade", parts[current].GetComponent<Color>());
        current++;
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

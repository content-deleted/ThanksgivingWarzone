using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfEsteemBar : MonoBehaviour
{
    public GameObject[] parts;
    public int current=0;
    public float fadeOutSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {}
    public void decrementSelfEsteemBar()
    {
        try
        {
            parts[current].GetComponent<SpriteRenderer>().color = new Color(0.3962264f, 0.3943574f, 0.3943574f);
            //StartCoroutine("Fade", parts[current]);
            current++;
        }
        catch
        {
            print("underflow");
        }
    }

    public void incrementSelfEsteemBar()
    {
        try
        {
            current--;
            parts[current].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
        catch
        {
            current++;
            print("overflow");
        }
    }

    public IEnumerator Fade(GameObject r)
    {
        for (int f = 255; f > 0; f--)
        {
            r.GetComponent<SpriteRenderer>().color = new Color(r.GetComponent<SpriteRenderer>().color.r, r.GetComponent<SpriteRenderer>().color.g, r.GetComponent<SpriteRenderer>().color.b, f);
            yield return new WaitForSeconds(fadeOutSpeed);
        }
    }
}

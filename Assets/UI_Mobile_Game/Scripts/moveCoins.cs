using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCoins : MonoBehaviour
{
    public enum TypeMoney { Coin, Star, Energy };
    public TypeMoney typeMoney;

    public Vector3 randPos;
    public float speed = 200f;
    public float speedToFinal = 800f;
    public int id;
    public PopCoins pop;
    public AudioClip soundFx;
    float step;
    bool final;
    RectTransform rt;

    // Start is called before the first frame update
    //------------------------------------------------------------------------
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        randPos = new Vector3(rt.localPosition.x + Random.Range(-100f, 100f), rt.localPosition.y + Random.Range(-100f, 100f), 0f);
    }

    // Update is called once per frame
    //------------------------------------------------------------------------
    void Update()
    {
        if (!final)
        {
            step = speed * Time.deltaTime;
            rt.localPosition = Vector3.MoveTowards(rt.localPosition, randPos, step);
        }
        else
        {
            if (typeMoney == TypeMoney.Coin)
            {
                if (rt.position != pop.finalPosMoney.position)
                {
                    step = speedToFinal * Time.deltaTime;
                    rt.position = Vector3.MoveTowards(rt.position, pop.finalPosMoney.position, step);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    //------------------------------------------------------------------------
    public void GoFinal()
    {
        final = true;
    }
}
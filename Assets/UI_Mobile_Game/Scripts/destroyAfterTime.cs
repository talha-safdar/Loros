using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
    public float speed;
    public float Timer;

    //GameObject instantiate after purchase in shop, sound music is OFF
    //------------------------------------------------------------------------
    void Start()
    {
        StartCoroutine("destroyObject");
    }

    //Move with update text float to UP direction
    //------------------------------------------------------------------------
    void Update()
    {
        GetComponent<RectTransform>().Translate(new Vector4(0f, 1f, 0f) * speed * Time.deltaTime);
    }

    //destroy gameObject, disable window purchased, add coins animation and reset volum music
    //------------------------------------------------------------------------
    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(Timer);
        GlobalManager.instance.WindowsPop.SetActive(false);
        GlobalManager.instance.AddMoney();
        GlobalAudio.instance.resetAudioMusic();
        Destroy(this.gameObject);
    }
}

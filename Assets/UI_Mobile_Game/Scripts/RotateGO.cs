using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGO : MonoBehaviour
{
    public float speed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }
}

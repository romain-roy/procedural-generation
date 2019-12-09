using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float speed;
    private Transform t;

    void Start()
    {
        t = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        t.Rotate(speed * Time.deltaTime, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AracTeker : MonoBehaviour
{
    public float donmehizi = 100f;

    // Update is called once per frame
    void Update()
    {
        float donmeMiktari = Input.GetAxis("Vertical") * donmehizi * Time.deltaTime;
        transform.Rotate(Vector3.right * donmeMiktari);


    }
}

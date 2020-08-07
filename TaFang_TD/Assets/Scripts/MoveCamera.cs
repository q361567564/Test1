using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed=20;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouse = Input.GetAxis("Mouse ScrollWheel");  
        transform.Translate(new Vector3(h, mouse*-30, v) * Time.deltaTime * speed, Space.World);
        //if(Input.GetKey(KeyCode.Q))
        //{
        //    transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed,Space.World);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * -speed, Space.World);
        //}

    }
}

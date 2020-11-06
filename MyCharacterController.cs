using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{

    private Transform tf_;
    public float velocity_;

    // Start is called before the first frame update
    void Start()
    {
        tf_ = GetComponent<Transform>();
        velocity_ = 15F;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            tf_.Translate(velocity_ * Vector3.forward * Time.deltaTime);
        }else if (Input.GetKey("down"))
        {
            tf_.Translate(velocity_ * Vector3.back * Time.deltaTime);
        }else if (Input.GetKey("left"))
        {
            tf_.Rotate(0, -30*velocity_  * Time.deltaTime, 0);
        }else if (Input.GetKey("right"))
        {
            tf_.Rotate(0, 30*velocity_ *  Time.deltaTime, 0);
        }
    }
}

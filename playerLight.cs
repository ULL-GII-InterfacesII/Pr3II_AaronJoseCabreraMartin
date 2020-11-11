using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLight : MonoBehaviour
{
    private int cooldown_;
    // Start is called before the first frame update
    void Start()
    {
        cooldown_ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown_++;
        if (Input.GetKey("l") && cooldown_ > 5) {
            Light myLight = GetComponent<Light>();
            myLight.enabled = !myLight.enabled;
            cooldown_ = 0;
        }
    }
}

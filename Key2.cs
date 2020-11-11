using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2 : MonoBehaviour
{
    public delegate void playerEvent();
    public static event playerEvent openDoor2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player" && openDoor2 != null){
            openDoor2();
            Destroy(gameObject);
        }
    }
}

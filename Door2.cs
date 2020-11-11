using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Key2.openDoor2 += Open;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){
        Key2.openDoor2 -= Open;
    }

    void Open(){
        Vector3 position = GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(position.x,position.y+5,position.z);
        Key2.openDoor2 -= Open;
    }
}

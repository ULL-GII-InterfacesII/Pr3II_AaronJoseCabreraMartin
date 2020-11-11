using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1 : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Key1.openDoor1 += Open;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){
        Key1.openDoor1 -= Open;
    }

    void Open(){
        Vector3 position = GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(position.x,position.y+5,position.z);
        Key1.openDoor1 -= Open;
    }
}

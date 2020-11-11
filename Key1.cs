using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    public delegate void playerEvent();
    public static event playerEvent openDoor1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player" && openDoor1 != null){
            openDoor1();
            Destroy(gameObject);
        }
    }
}

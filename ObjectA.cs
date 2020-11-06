using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectA : MonoBehaviour
{
    public delegate void contactWithPlayer();
    public static event contactWithPlayer touchPlayer;


    // Start is called before the first frame update
    void Start()
    {
        ObjectB.contactPlayer += imprimir;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && touchPlayer != null)
        {
            touchPlayer();
        }
    }

    void imprimir()
    {
        Debug.Log("Has tocado a B!!!");
    }

    void OnDisable()
    {
        ObjectB.contactPlayer -= imprimir;
    }
}

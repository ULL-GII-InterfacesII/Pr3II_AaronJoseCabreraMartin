using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectB : MonoBehaviour
{
    public delegate void contactWithPlayer();
    public static event contactWithPlayer touchPlayer;

    public int contador_;

    // Start is called before the first frame update
    void Start()
    {
        contador_ = 0;
        ObjectA.contactPlayer += incrementarContador;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && touchPlayer != null)
        {
            touchPlayer();
        }
    }

    void incrementarContador()
    {
        contador_++;
    }

    void OnDisable()
    {
        ObjectA.contactPlayer -= incrementarContador;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectA : MonoBehaviour
{
    public delegate void contactWithPlayer();
    public static event contactWithPlayer touchPlayer;

    private GameObject player_;


    // Start is called before the first frame update
    void Start()
    {
        ObjectB.contactPlayer += imprimir;
        player_ = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if( Vector3.Distance(GetComponent<Transform>().position,player_.transform.position) < MyCharacterController.distanciaMinima_)
        {
            MyCharacterController.destroyA += destroyA;
        }else if( Vector3.Distance(GetComponent<Transform>().position, player_.transform.position) < MyCharacterController.distanciaMedia_)
        {
            MyCharacterController.empujarA += empujarA;
        }
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

    void OnDestroy()
    {
        ObjectB.contactPlayer -= imprimir;
        MyCharacterController.destroyA -= destroyA;
        MyCharacterController.empujarA -= empujarA;

    }

    void destroyA()
    {
        Destroy(gameObject);
    }

    void empujarA()
    {
        //vector que apunta desde el jugador al objetoA
        var direccion = (player_.transform.position - GetComponent<Transform>().position);
        //normalizamos el vector
        direccion = direccion / direccion.magnitude;
        GetComponent<Transform>().Translate( direccion * Time.deltaTime );
        MyCharacterController.empujarA -= empujarA;
    }
}

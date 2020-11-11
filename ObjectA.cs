using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectA : MonoBehaviour
{
    public delegate void contactWithPlayer();
    public static event contactWithPlayer touchPlayer;
    private GameObject player_;

    // Start is called before the first frame update
    void Start(){
        ObjectB.contactPlayer += imprimir;
        player_ = GameObject.FindWithTag("Player");
    }

    void Update(){
        float distanciaJugador = Vector3.Distance(GetComponent<Transform>().position, player_.transform.position);
        if( distanciaJugador < MyCharacterController.distanciaMinima_){
            MyCharacterController.empujarA -= empujarA;
            MyCharacterController.destroyA += destroyA;
        }else if( distanciaJugador < MyCharacterController.distanciaMedia_){
            MyCharacterController.destroyA -= destroyA;
            MyCharacterController.empujarA += empujarA;
        }else{
            MyCharacterController.destroyA -= destroyA;
            MyCharacterController.empujarA -= empujarA;
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player" && touchPlayer != null){
            touchPlayer();
        }
    }

    void imprimir(){
        Debug.Log("Has tocado a B!!!");
    }

    void destroyA(){
        ObjectB.contactPlayer -= imprimir;
        MyCharacterController.empujarA -= empujarA;
        MyCharacterController.destroyA -= destroyA;
        Destroy(gameObject);
    }

    void empujarA(float fuerza){
        //vector que apunta desde el jugador al objetoA
        var direccion = (player_.transform.position - GetComponent<Transform>().position);
        //normalizamos el vector
        direccion = direccion / direccion.magnitude;
        GetComponent<Transform>().Translate( fuerza * direccion * Time.deltaTime );
        MyCharacterController.empujarA -= empujarA;
    }
}

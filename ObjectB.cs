using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ObjectB : MonoBehaviour
{
    //creamos el tipo delegado collisionWithPlayer
    //collision porque es algo físico, para diferenciarlo de A
    public delegate void collisionWithPlayer();
    public static event collisionWithPlayer contactPlayer;
    public static event collisionWithPlayer playerTouchB;
    public int contador_;

    // Start is called before the first frame update
    void Start(){
        contador_ = 0;
        //establecemos que el delegado touchplayer de objetoA es nuestro metodo incrementarContador
        ObjectA.touchPlayer += incrementarContador;
    }

    void Update(){

    }

    void incrementarContador(){
        contador_++;
    }

    void OnCollisionEnter(Collision other){
        //si choco con player y mi evento contactPlayer no es nulo
        if (other.gameObject.tag == "Player" && contactPlayer != null){
            //llamo a mi evento
            contactPlayer();
        }

        if( other.gameObject.tag == "Player" && playerTouchB != null){
            playerTouchB();
        }
    }

    void OnDisable(){
        //debemos liberar los delegados, unity no lo hace por nosotros
        ObjectA.touchPlayer -= incrementarContador;
    }
}

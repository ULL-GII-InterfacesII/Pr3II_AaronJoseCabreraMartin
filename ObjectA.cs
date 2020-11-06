using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectA : MonoBehaviour
{
    //creamos el tipo delegado collisionWithPlayer
    //collision porque es algo físico, para diferenciarlo de B
    public delegate void collisionWithPlayer();
    public static event collisionWithPlayer contactPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //establecemos que el delegado touchplayer de objetoB es nuestro metodo imprimir
        ObjectB.touchPlayer += imprimir;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void imprimir()
    {
        Debug.Log("Has tocado a B!!!");
    }

    void OnCollisionEnter(Collision other)
    {
        //si choco con player y mi evento no es nulo
        if (other.gameObject.tag == "Player" && contactPlayer != null)
        {
            //llamo a mi evento
            contactPlayer();
        }
    }
    
    void OnDisable()
    {
        //debemos liberar los delegados, unity no lo hace por nosotros
        ObjectB.touchPlayer -= imprimir;
    }
}

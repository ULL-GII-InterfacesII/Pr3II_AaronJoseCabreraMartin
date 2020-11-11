using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{

    private Transform tf_;
    public float velocity_;
    public float fuerza_;
    public static float distanciaMinima_;
    public static float distanciaMedia_;
    public delegate void inRangeWithPlayer();
    public delegate void inSecondRangeWithPlayer(float fuerza);
    public static event inRangeWithPlayer destroyA;
    public static event inSecondRangeWithPlayer empujarA;

    // Start is called before the first frame update
    void Start(){
        tf_ = GetComponent<Transform>();
        velocity_ = 15F;
        fuerza_ = 10;
        distanciaMinima_ = 2.5F;
        distanciaMedia_ = 10;
        MyCamera.playerShoot +=disparar;

        MyCamera.decreasePower += bajarPoder;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey("up")){
            tf_.Translate(velocity_ * Vector3.forward * Time.deltaTime);
            //GetComponent<Rigidbody>().AddForce(velocity_ * Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey("down")){
            tf_.Translate(velocity_ * Vector3.back * Time.deltaTime);
            //GetComponent<Rigidbody>().AddForce(velocity_ * Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey("left")){
            tf_.Rotate(0, -7*velocity_  * Time.deltaTime, 0);
        }
        if (Input.GetKey("right")){
            tf_.Rotate(0, 7*velocity_ *  Time.deltaTime, 0);
        }
    }

    void disparar(){
        if(  destroyA != null){
            Debug.Log("Destruccion!!");
            destroyA();
        }
        if ( empujarA != null){
            Debug.Log("Disparo!!");
            empujarA(fuerza_);
        }
    }

    void bajarPoder(){
        Debug.Log("Baja el poder!!");
        if(fuerza_ > 1){
            fuerza_--;
        }
    }
}

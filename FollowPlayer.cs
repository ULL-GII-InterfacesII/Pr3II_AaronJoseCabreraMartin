using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowPlayer : MonoBehaviour
{
    private Transform tf_;
    private GameObject player_;
    public float velocity_;
    // Start is called before the first frame update
    void Start()
    {
        tf_ = GetComponent<Transform>();
        player_ = GameObject.FindWithTag("Player");
        velocity_ = 15F;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionJugador = player_.transform.position;
        if (Input.GetKey("up")) {
            tf_.position = positionJugador + player_.transform.TransformDirection(new Vector3(0.5F,1,0.5F));
        }
        if (Input.GetKey("down")) {
            tf_.position = positionJugador + player_.transform.TransformDirection(new Vector3(0.5F,1,0.5F));
        }
        if (Input.GetKey("left")) {
            tf_.RotateAround(positionJugador, Vector3.up, -velocity_* 7 * Time.deltaTime);
        }
        if (Input.GetKey("right")) {
            tf_.RotateAround(positionJugador, Vector3.up, velocity_ * 7 * Time.deltaTime);
        }
    }
}

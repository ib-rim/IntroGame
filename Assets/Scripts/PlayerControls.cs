using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{  
    public Vector2 moveValue;
    public float speed;
    public int count;

    void OnMove (InputValue value) {
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement*speed*Time.fixedDeltaTime);    
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            this.count = this.count + 1;
        }
    }

    void Start() {
        this.count = 0;
    }


}

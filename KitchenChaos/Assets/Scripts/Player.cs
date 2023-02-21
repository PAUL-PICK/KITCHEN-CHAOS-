using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    //This is using the old input system
    [SerializeField] private float moveSpeed = 7.0f;
   
    private bool isWalking;

    private void Update() {
         Vector2 inputVector = new Vector2(0,0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
           
        }

        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }


        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        // this forces the objects y vector into the worlds z vector
        Vector3 moveDir = new Vector3(inputVector.x ,0f ,inputVector.y);

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 20f;
        // rotates player in direction of movment
        transform.forward = Vector3.Slerp(transform.forward,moveDir, Time.deltaTime * rotateSpeed);

        

    }

    public bool IsWalking() {
        return isWalking;
    }


}

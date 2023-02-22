using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    //This is using the old input system
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private GameInput gameInput;
   
    private bool isWalking;

    private void Update() {

        Vector2 inputVector = gameInput.getMovmentVectorNormalized();

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

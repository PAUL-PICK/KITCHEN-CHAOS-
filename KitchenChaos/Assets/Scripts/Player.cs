using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour{
    //This is using the old input system
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private GameInput gameInput;
   
    private bool isWalking;

    private void Update() {

        Vector2 inputVector = gameInput.getMovmentVectorNormalized();

        // this forces the objects y vector into the worlds z vector
        Vector3 moveDir = new Vector3(inputVector.x ,0f ,inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHight,
                                            playerRadius,moveDir,moveDistance);

        
        if (!canMove) {
            // cannot move towards movDir

            // attempt only x movment
            Vector3 moveDirX = new Vector3(moveDir.x,0,0);
            canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHight,
                                           playerRadius,moveDirX,moveDistance);
            
            if (canMove) {
                // can move only on the x
                moveDir = moveDirX;
            }
            else {
                //cannot move only on x

                //attempt only on the z
                Vector3 moveDirZ = new Vector3(0,0,moveDir.x);
                canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHight,
                                           playerRadius,moveDirZ,moveDistance);

                if (canMove) {
                    //can move only on the z
                    moveDir = moveDirZ;
                }
                else {
                    // cannot move in any direction
                }
            }
        }


        if (canMove) {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 20f;
        // rotates player in direction of movment
        transform.forward = Vector3.Slerp(transform.forward,moveDir, Time.deltaTime * rotateSpeed);    

    }

    public bool IsWalking() {
        return isWalking;
    }


}

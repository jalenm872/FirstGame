using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    private void Update() {
        Vector2 inputVector = new Vector2(0,0);

        if(Input.GetKey(KeyCode.W)){
            inputVector.y = +1;
        }
        if(Input.GetKey(KeyCode.S)){
            inputVector.y = -1;
        }
        if(Input.GetKey(KeyCode.A)){
            inputVector.x = -1;
        }
        if(Input.GetKey(KeyCode.D)){
            inputVector.x = +1;
        }

        //Make sure the vector is normalized
        inputVector.Normalize();

        //Move the player
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float RotateSpeed = 10f;

        //Rotate the player to face the direction of movement with Slerp
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * RotateSpeed);

        //Debug.Log(inputVector);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 50f;

    [SerializeField] Rigidbody2D myRigidbody;

    [SerializeField] GameObject myVisual;


    private Vector2 moveDir = Vector2.zero;

    private bool isMoving = false;

    private int rotDir = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    #region Tick
    // Update is called once per frame
    void Update()
    {
        getInput();
        if (moveDir != Vector2.zero) {
            isMoving = true;
            rotate();
        } else
        {
            isMoving = false;
            myVisual.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void FixedUpdate() //for physics related functions
    {
        updateMovement();
    }
    #endregion

    #region Input Logic
    private void getInput()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
    }
    #endregion

    #region Movement Logic
    void updateMovement()
    {
        myRigidbody.velocity = moveDir.normalized * moveSpeed * Time.fixedDeltaTime;
    }
    #endregion

    private void rotate()
    {

        if (rotDir == 1)
        {
            myVisual.transform.rotation = Quaternion.Slerp(myVisual.transform.rotation, Quaternion.Euler(0, 0, 15), 10 * Time.deltaTime);
            if (myVisual.transform.localRotation.eulerAngles.z > 14 && myVisual.transform.localRotation.eulerAngles.z <16)
            {
                rotDir = -1;
            }
        } else if (rotDir == -1)
        {
            myVisual.transform.rotation = Quaternion.Slerp(myVisual.transform.rotation, Quaternion.Euler(0, 0, -15), 10 * Time.deltaTime);
            if (myVisual.transform.localRotation.eulerAngles.z > 344 && myVisual.transform.localRotation.eulerAngles.z < 346)
            {
                rotDir = 1;
            }
        }

        print(myVisual.transform.localRotation.eulerAngles.z);
        
        print(rotDir);
        
    }
}

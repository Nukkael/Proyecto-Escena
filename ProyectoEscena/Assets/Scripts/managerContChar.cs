using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerContChar : MonoBehaviour
{
    //component
    private CharacterController _charactercontroller;
    private Animator _animator;

    private Transform meshPlayer;

    // move
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.1f;
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);
        _charactercontroller = tempPlayer.GetComponent<CharacterController>();
        _animator = meshPlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        //animation
        if (inputX == 0 && inputZ == 0)
        {
            _animator.SetBool("isWalking", false);
        }
        else
        {
            _animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("isCrouch", true);
        }
        else
        {
            _animator.SetBool("isCrouch", false);
        }
    }

    private void FixedUpdate()
    {
        // movement
        v_movement = new Vector3(inputX * moveSpeed,0,inputZ * moveSpeed);
        _charactercontroller.Move(v_movement);

        //rotate
        if (inputX !=0 || inputZ !=0)
        {
            Vector3 lookDir = new Vector3(v_movement.x, 0, v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
        
    }
}

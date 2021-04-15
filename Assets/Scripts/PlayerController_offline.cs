using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum mode {
    firstperson, thirdperson
}
public class PlayerController_offline : MonoBehaviour
{
    public bool isLP;
    public Animator _animator;

    private CharacterController _characterController;

    public float Speed = 5.0f;
    public float runSpeed = 12.0f;
    public float jumpSpeed = 8.0f;
    public float RotationSpeed = 240.0f;
    public float smoothing = 3;
    private float smoothSpeed;
    private float Gravity = 20.0f;

    public float sensitivityX = 270;
    public float sensitivityY = 180;
    private Vector3 _moveDir = Vector3.zero;

    public bool isGrounded;
    // Use this for initialization

    public mode currentMode = mode.thirdperson;
    private float rotX;
    private float rotY;

    
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
  
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float oldy = _moveDir.y;
        if (currentMode == mode.thirdperson)
        {
            Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

            if (move.magnitude > 1f) move.Normalize();

            // Calculate the rotation for the player
            move = transform.InverseTransformDirection(move);

            // Get Euler angles
            float turnAmount = Mathf.Atan2(move.x, move.z);

            transform.Rotate(0, turnAmount * RotationSpeed * Time.deltaTime, 0);

            if (_characterController.isGrounded)
            {
                // _animator.SetBool("run", move.magnitude> 0);

                _moveDir = transform.forward * move.magnitude;
               
            }
        }
        else {
            _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _moveDir = Camera.main.transform.TransformDirection(_moveDir);
            _moveDir.y = 0;

            rotX += Input.GetAxis("Mouse X") * sensitivityX;
            rotY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotY = Mathf.Clamp(rotY, -45f, 45f);
            Camera.main.transform.localRotation = Quaternion.Euler(-rotY, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, rotX, 0f);
        }
        if (_characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveDir *= runSpeed;
            }
            else
            {
                _moveDir *= Speed;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _moveDir.y = jumpSpeed;
                _animator.SetTrigger("jump");
            }
        }
        else {
            _moveDir.y = oldy;
        }

        _moveDir.y -= Gravity * Time.deltaTime;

        _characterController.Move(_moveDir * Time.deltaTime);

        _animator.SetFloat("Speed", _moveDir.magnitude);
    }

}

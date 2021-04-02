using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Transform PlayerTransform;

    public Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationsSpeed = 5.0f;
    public float RotationsSpeed2 = 2.5f;

    // Use this for initialization
    void Start()
    {
        if (PlayerTransform == null)
        {
            return;
        }

        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // LateUpdate is called after Update methods
    void LateUpdate()
    {

        if (PlayerTransform == null)
        {
            return;
        }
        if (RotateAroundPlayer)
        {

            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);
            Quaternion camTurnAngle2 =
                Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationsSpeed2, Vector3.left);
            
            _cameraOffset = camTurnAngle * camTurnAngle2 * _cameraOffset;
            Debug.Log(_cameraOffset);
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(PlayerTransform);
    }
}
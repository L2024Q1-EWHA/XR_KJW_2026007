using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public Transform ObjectToConstrainRotation;

    public float translateSpeed = 3f;
    float _rotationSpeed = 5f, XRotation, YRotation;
    public float rotationSpeed = 5f;

    [SerializeField]
    float YRotationLimit = 60f;

    private void Start()
    {
        print("WSAD to move");
    }

    void Update()
    {
        ConstrainRotation();
        Translate();
    }

    void ConstrainRotation()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * _rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * _rotationSpeed;
        // XRotation --> up~down
        XRotation -= YaxisRotation;
        XRotation = Mathf.Clamp(XRotation, -40f, 20f);
        // YRotation --> left~right
        YRotation += XaxisRotation;
        YRotation = Mathf.Clamp(YRotation, -YRotationLimit, YRotationLimit);
        //print($"XRot: {XRotation}, YRot: {YRotation}");
        ObjectToConstrainRotation.transform.localRotation = Quaternion.Euler(XRotation, YRotation, 0f);
    }

    void Translate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ObjectToConstrainRotation.Translate(Vector3.forward * translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            ObjectToConstrainRotation.Translate(-Vector3.forward * translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            ObjectToConstrainRotation.Translate(-Vector3.right * translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            ObjectToConstrainRotation.Translate(Vector3.right * translateSpeed * Time.deltaTime);
        }
    }
}

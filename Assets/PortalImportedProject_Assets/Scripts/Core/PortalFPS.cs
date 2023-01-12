using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFPS : PortalTraveller
{
    CharacterController controller;
    Camera cam;
    public float yaw;
    public float pitch;
    float smoothYaw;
    float smoothPitch;

    float yawSmoothV;
    float pitchSmoothV;
    float verticalVelocity;
    Vector3 velocity;
    Vector3 smoothV;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        controller = GetComponent<CharacterController>();

        yaw = transform.eulerAngles.y;
        pitch = cam.transform.localEulerAngles.x;
        smoothYaw = yaw;
        smoothPitch = pitch;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 inputDir = new Vector3(input.x, 0, input.y).normalized;
        Vector3 worldInputDir = transform.TransformDirection(inputDir);

        //float currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed;
        //Vector3 targetVelocity = worldInputDir * currentSpeed;
        //velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref smoothV, smoothMoveTime);

        //verticalVelocity -= gravity * Time.deltaTime;
        velocity = new Vector3(velocity.x, verticalVelocity, velocity.z);
    }

    public override void Teleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        Vector3 eulerRot = rot.eulerAngles;
        float delta = Mathf.DeltaAngle(smoothYaw, eulerRot.y);
        yaw += delta;
        smoothYaw += delta;
        transform.eulerAngles = Vector3.up * smoothYaw;
        velocity = toPortal.TransformVector(fromPortal.InverseTransformVector(velocity));
        Physics.SyncTransforms();
    }
}

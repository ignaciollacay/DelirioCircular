using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : PortalTeleportTarget {
    //cambie el Portal Traveller por el PortalTeleportTarget, para cambiar reemplazar el script de Portal por el PortalTP
    public float walkSpeed = 3;
    public float runSpeed = 6;
    public float smoothMoveTime = 0.1f;
    public float jumpForce = 8;
    public float gravity = 18;
    [SerializeField] public float m_GravityMultiplier;

    public bool lockCursor;
    public float mouseSensitivity = 10;
    public Vector2 pitchMinMax = new Vector2 (-40, 85);
    public float rotationSmoothTime = 0.1f;

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

    bool jumping;
    float lastGroundedTime;
    bool disabled;

    //agrego esto para disable el player mientras se activan las cutscenes
    public bool inputAllowed = true;
    //crear nuevas variables de current and new para walk speed, run speed y mouse sensivility
    private float walkSpeedNew = 0;
    private float runSpeedNew = 0;
    private float mouseSensitivityNew = 0;

    private float walkSpeedOld;
    private float runSpeedOld;
    private float mouseSensitivityOld;


    void Start()
    {
        cam = Camera.main;
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        controller = GetComponent<CharacterController>();

        yaw = transform.eulerAngles.y;
        pitch = cam.transform.localEulerAngles.x;
        smoothYaw = yaw;
        smoothPitch = pitch;

        //Debug para ver si esta funcionando las variables
        //Debug.Log("Walk Speed currently is " + walkSpeed);
        //Debug.Log("Run Speed currently is " + runSpeed);
        //Debug.Log("Mouse Sensibility currently is " + mouseSensitivity);

        //igualo los old a los normales
        walkSpeedOld = walkSpeed;
        //Debug.Log("Old Walk Speed currently is " + walkSpeedOld);
        runSpeedOld = runSpeed;
        //Debug.Log("Old Run Speed currently is " + runSpeedOld);
        mouseSensitivityOld = mouseSensitivity;
        //Debug.Log("Old Mouse Sensibility currently is " + mouseSensitivityOld);


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Break();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            disabled = !disabled;
        }

        if (disabled)
        {
            return;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 inputDir = new Vector3(input.x, 0, input.y).normalized;
        Vector3 worldInputDir = transform.TransformDirection(inputDir);

        float currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed;
        Vector3 targetVelocity = worldInputDir * currentSpeed;
        velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref smoothV, smoothMoveTime);

        verticalVelocity -= gravity * m_GravityMultiplier * Time.deltaTime;
        velocity = new Vector3(velocity.x, verticalVelocity, velocity.z);

        var flags = controller.Move(velocity * Time.deltaTime);
        if (flags == CollisionFlags.Below)
        {
            jumping = false;
            lastGroundedTime = Time.time;
            verticalVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float timeSinceLastTouchedGround = Time.time - lastGroundedTime;
            if (controller.isGrounded || (!jumping && timeSinceLastTouchedGround < 0.15f))
            {
                jumping = true;
                verticalVelocity = jumpForce;
            }
        }

        float mX = Input.GetAxisRaw("Mouse X");
        float mY = Input.GetAxisRaw("Mouse Y");

        // Verrrrrry gross hack to stop camera swinging down at start
        float mMag = Mathf.Sqrt(mX * mX + mY * mY);
        if (mMag > 5)
        {
            mX = 0;
            mY = 0;
        }

        yaw += mX * mouseSensitivity;
        pitch -= mY * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        smoothPitch = Mathf.SmoothDampAngle(smoothPitch, pitch, ref pitchSmoothV, rotationSmoothTime);
        smoothYaw = Mathf.SmoothDampAngle(smoothYaw, yaw, ref yawSmoothV, rotationSmoothTime);

        transform.eulerAngles = Vector3.up * smoothYaw;
        cam.transform.localEulerAngles = Vector3.right * smoothPitch;

        //aca agrego el disable del input para las cutscenes
        if (inputAllowed == false)
        {
            walkSpeed = walkSpeedNew;
            runSpeed = walkSpeedNew;
            mouseSensitivity = walkSpeedNew;

            //Debug.Log("New Walk Speed currently is " + walkSpeed);
            //Debug.Log("New Run Speed currently is " + runSpeed);
            //Debug.Log("New Mouse Sensibility currently is " + mouseSensitivity);
        }
        //Ahi anda lo de arriba. Pero tengo que volverlo a su estado si inputAllowed == true
        //puedo o asignar los valores determinados que estoy usando actualmente
        // o guardar los valores en variables que pueda volver
        else
        {
            walkSpeed = walkSpeedOld;
            runSpeed = runSpeedOld;
            mouseSensitivity = mouseSensitivityOld;
        }
       
    }

    //me transforma/alinea el local rotation del player segun el local position del portal
    //UPDATE. Reemplace la funcion de Teleport por PortalTeleport, segun el cambio de scripts.
    public override void PortalTeleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        Vector3 eulerRot = rot.eulerAngles;
        float delta = Mathf.DeltaAngle (smoothYaw, eulerRot.y);
        yaw += delta;
        smoothYaw += delta;
        transform.eulerAngles = Vector3.up * smoothYaw;
        velocity = toPortal.TransformVector (fromPortal.InverseTransformVector (velocity));
        Physics.SyncTransforms ();
    }
}
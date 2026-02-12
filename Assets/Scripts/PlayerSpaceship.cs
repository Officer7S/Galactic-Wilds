using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerSpaceship : MonoBehaviour
{
    public Rigidbody rigi;
    public bool thrust = false;
    public bool stop = false;
    public float jumpSpeed = 2000f;
    public StarControls ctrl;
    private Vector2 turnInput;
    private float rollInput;
    public float turnSpeed;

    void jump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stop = false;
        thrust = true;
    }
    void brake(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stop = true;
        thrust = false;
    }
    void kill(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stop = false;
        thrust = false;
    }
    void Awake()
    {
        rigi = GetComponent<Rigidbody>();
        ctrl = new StarControls();
        ctrl.Enable();
        ctrl.SHIP.DRIVE.started += jump; //whenever ctrl.ship.drive button goes down, do the jump method at line 11, .started says when it goes down, .performed is when it is down
        ctrl.SHIP.DRIVE.canceled += kill;
        ctrl.SHIP.BRAKE.started += brake;
        ctrl.SHIP.BRAKE.canceled += kill;
    }

    private void OnDisable()
    {
        ctrl.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 lookInput = ctrl.SHIP.LOOK.ReadValue<Vector2>();
        Vector2 turnInput = ctrl.SHIP.TURN.ReadValue<Vector2>();
        lookInput = lookInput + turnInput; //i thought of either doing mouse or keyboard inputs, why not have both?
        rollInput = ctrl.SHIP.ROLL.ReadValue<float>();

        if ((lookInput.magnitude > 0.1f) || (Math.Abs(rollInput) > 0.1f))
        {
            Vector3 angleVelocity = new Vector3(-lookInput.y * turnSpeed, lookInput.x * turnSpeed, rollInput * turnSpeed * -1);
            Quaternion deltaRot = Quaternion.Euler(angleVelocity * Time.deltaTime);
            rigi.MoveRotation(rigi.rotation * deltaRot);
        }
    }
    //Fixed Update is better for Physics, cause its based on real time, not framerate
    private void FixedUpdate()
    {
        if (stop == false)
        {
            if (thrust == true)
            {
                rigi.AddForce(transform.forward * jumpSpeed, ForceMode.Acceleration); //accel for slow increase, impulse for instantanious speed
            }
        }
        else
        {
            rigi.AddForce(transform.forward * jumpSpeed * -1, ForceMode.Acceleration); //accel for slow increase, impulse for instantanious speed
        }
    }
}
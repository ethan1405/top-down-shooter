using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 450;
    public float walkSpeed = 6;
    public float runSpeed = 8;

    private Quaternion targetRotation;

    public gun gun;

    private CharacterController controller;
    private Camera cam;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    void Update()
    {
        ControlMouse();
        //ControlWASD();

        if (Input.GetButtonDown("shoot") && gun.gunType == GunType.Semi)
        {
            gun.Shoot();
        }
        else if (Input.GetButton("shoot") && gun.gunType == GunType.Auto)
        {
            gun.ShootContinuous();
        }
        else if (Input.GetButtonDown("shoot") && gun.gunType == GunType.Burst)
        {
            gun.Shootburst();
        }

        void ControlMouse()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
            targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed = 7);

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Vector3 motion = input;
            motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
            motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
            motion += Vector3.up * -4;

            controller.Move(motion * Time.deltaTime);
        }

        void ControlWASD()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));


            if (input != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(input);
                transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed = Time.deltaTime);
            }

            Vector3 motion = input;
            motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
            motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
            motion += Vector3.up * -8;

            controller.Move(motion * Time.deltaTime);
        }
    }
}

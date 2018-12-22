using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed, Gravity, accel;
    private CharacterController Control;
    private Vector3 MoveDir = Vector3.zero;
    public VirtualJoystick joystick;
    public bool StopPlayerMov;

    public bool restrictedMovement = true;

    private float _actualAccelX, _actualAccelZ;

    // Use this for initialization
    void Start()
    {
        Control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StopPlayerMov)
        {
            if (Control.isGrounded)
            {
                //Restricted Movement solo permite moverse en horizontal y vertical
                if (!restrictedMovement)
                {
                    //MoveDir = new Vector3(joystick.Horizontal(), 0, joystick.Vertical());
                    MoveDir = new Vector3(Mathf.Lerp(MoveDir.x / Speed, joystick.Horizontal(), accel * Time.deltaTime), 0, Mathf.Lerp(MoveDir.z / Speed, joystick.Vertical(), accel * Time.deltaTime)); //Movimiento con aceleracion
                }    
                else
                {
                    Vector3 MoveDir2 = joystick.RestrictedMovement();

                    _actualAccelX = Mathf.Lerp(MoveDir.x / Speed, MoveDir2.x, accel * Time.deltaTime);
                    _actualAccelZ = Mathf.Lerp(MoveDir.z / Speed, MoveDir2.z, accel * Time.deltaTime);

                    //MoveDir = new Vector3(Mathf.Lerp(MoveDir.x / Speed, MoveDir2.x, accel * Time.deltaTime), 0, Mathf.Lerp(MoveDir.z / Speed, MoveDir2.z, accel * Time.deltaTime));
                    MoveDir = new Vector3(_actualAccelX, 0, _actualAccelZ);

                    if (Mathf.Abs(MoveDir2.x) > 0)
                    {
                        MoveDir = new Vector3(_actualAccelX, 0, 0);
                    }

                    if (Mathf.Abs(MoveDir2.z) > 0)
                    {
                        MoveDir = new Vector3(0, 0, _actualAccelZ);
                    }

                    //Debug.Log("x = " +Mathf.Abs(MoveDir2.x));
                    //Debug.Log("z = " + Mathf.Abs(MoveDir2.z));
                }

                MoveDir *= Speed;

            }
            MoveDir.y -= Gravity * Time.deltaTime;
            Control.Move(MoveDir * Time.deltaTime);
            Vector3 NewDir = MoveDir;
            NewDir.y = 0;
            if (NewDir != Vector3.zero)
            {
                if (MoveDir.x != 0 || MoveDir.z != 0)
                {
                    transform.rotation = Quaternion.LookRotation(NewDir);
                }
            }
        }
        
    }
    public void OnPress()
    {
        StopPlayerMov = true;
        MoveDir = new Vector3(0, 0, 0);
        print("pulsado");
    }
    public void OnRelease()
    {
        StopPlayerMov = false;
        MoveDir = new Vector3(0, 0, 0);
        print("suelto");
    }

    public bool PlayerIsMoving()
    {
        if(MoveDir != Vector3.zero)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed, Gravity;
    private CharacterController Control;
    private Vector3 MoveDir = Vector3.zero;
    public VirtualJoystick joystick;
    private bool StopPlayerMov;

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
                MoveDir = new Vector3(joystick.Horizontal(), 0, joystick.Vertical());
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
    public void onPress()
    {
        StopPlayerMov = false;
        print("pulsado");
    }
    public void onRelease()
    {
        StopPlayerMov = true;
        print("suelto");
    }
}

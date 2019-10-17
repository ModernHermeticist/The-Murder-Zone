using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour {
    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.
    Converted to C# 27-02-13 - no credit wanted.
    Reformatted and cleaned by Ryan Breaker 23-6-18
    Original comment:
    Simple flycam I made, since I couldn't find any others made public.
    Made simple to use (drag and drop, done) for regular keyboard layout.
    Controls:
    WASD  : Directional movement
    Shift : Increase speed
    Space : Moves camera directly up per its local Y-axis
    */

    public float mainSpeed = 10.0f; // Regular speed
    public float shiftAdd = 25.0f; // Amount to accelerate when shift is pressed
    public float maxShift = 100.0f; // Maximum speed when holding shift
    public float camSens = 0.15f; // Mouse sensitivity

    public Transform cameraRotationPoint;
    public Transform cameraRack;

    private Vector3 lastMouse = new Vector3 (255, 255, 255); // kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;
    public float scrollDistanceIncrement = 10;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update () 
    {
        // Keyboard commands
        Vector3 p = GetBaseInput ();
        if (Input.GetKey (KeyCode.LeftShift)) 
        {
            totalRun += Time.deltaTime;
            p *= totalRun * shiftAdd;
            p.x = Mathf.Clamp (p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp (p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp (p.z, -maxShift, maxShift);
        } 
        else 
        {
            totalRun = Mathf.Clamp (totalRun * 0.5f, 1f, 1000f);
            p *= mainSpeed;
        }

        p *= Time.deltaTime;
        cameraRack.Translate (p);
    }

    // Returns the basic values, if it's 0 than it's not active.
    private Vector3 GetBaseInput () 
    {
        float d = Input.GetAxis ("Mouse ScrollWheel");
        Vector3 p_Velocity = new Vector3 ();

        // Forward
        if (Input.GetKey (KeyCode.W))
            p_Velocity += new Vector3 (0, 0, 1);

        // Backward
        if (Input.GetKey (KeyCode.S))
            p_Velocity += new Vector3 (0, 0, -1);

        // Left
        if (Input.GetKey (KeyCode.A))
            p_Velocity += new Vector3 (-1, 0, 0);

        // Right
        if (Input.GetKey (KeyCode.D))
            p_Velocity += new Vector3 (1, 0, 0);

        // Up
        if (d > 0f)
            p_Velocity += new Vector3 (0, -1, 0);

        // Down
        if (d < 0f)
            p_Velocity += new Vector3 (0, 1, 0);

        // Rotate Left
        if (Input.GetKey (KeyCode.Q))
            cameraRack.RotateAround(cameraRotationPoint.position, new Vector3(0, -1, 0), 80 * Time.deltaTime);

        // Rotate Right
        if (Input.GetKey (KeyCode.E))
            cameraRack.RotateAround(cameraRotationPoint.position, new Vector3(0, 1, 0), 80 * Time.deltaTime);

        return p_Velocity;
    }
}
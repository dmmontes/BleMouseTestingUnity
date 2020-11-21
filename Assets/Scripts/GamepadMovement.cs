using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scripts for gamepad's movements
/// </summary>
public class GamepadMovement : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update. Initialize objects
    /// </summary>
    void Start()
    {
        moveTimer_ = 0;
        cameraTimer_ = 0;
    }

    /// <summary>
    /// Update is called once per frame. Check gamepad's state changes
    /// </summary>
    void Update()
    {
        checkMovement();
        checkSpecialFunctions();
        checkCamera();
    }
    
    private

    /// <summary>
    /// Check the state of the movement keys (W, A, S, D)
    /// </summary>
    void checkMovement()
    {
        // Check movement every time period
        moveTimer_ += Time.deltaTime;
        if(moveTimer_ > timeToCheckState_ ) {

            // Check W key
            bool keyWPressed = false;
            if (Input.GetKey(KeyCode.W))
            {
                keyWPressed = true;
            }
            
            // Check S key
            bool keySPressed = false;
            if (Input.GetKey(KeyCode.S))
            {
                keySPressed = true;
            }
            
            // Check A key
            bool keyAPressed = false;
            if (Input.GetKey(KeyCode.A))
            {
                keyAPressed = true;
            }
            
            // Check D key
            bool keyDPressed = false;
            if (Input.GetKey(KeyCode.D))
            {
                keyDPressed = true;
            }

            // Print if there is a move
            if (keyWPressed || keySPressed || keyAPressed || keyDPressed)
            {
                Debug.Log("Movement: key(s) pressed: " +
                         (keyWPressed ? "W (up), " : "") + 
                         (keySPressed ? "S (down), " : "") +
                         (keyAPressed ? "A (left), " : "") + 
                         (keyDPressed ? "D (right), " : ""));
                moveTimer_ = 0;
            }
        }
    }

    /// <summary>
    /// Check if a special function key (key 1, 2 or 3) has been pressed
    /// </summary>
    void checkSpecialFunctions()
    {
        // Check key 1
        bool key1Pressed = false;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            key1Pressed = true;
        }
            
        // Check key 2
        bool key2Pressed = false;
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            key2Pressed = true;
        }
            
        // Check key 3
        bool key3Pressed = false;
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            key3Pressed = true;
        }

        // Print if there is a move
        if (key1Pressed || key2Pressed || key3Pressed)
        {
            Debug.Log("Special functions: key(s) pressed: " +
                     (key1Pressed ? "1 HandBrake (Button 1), " : "") + 
                     (key2Pressed ? "2 Slow Motion (Button 2), " : "") +
                     (key3Pressed ? "3 Change camera (Joystick button), " : ""));
        }

    }

    /// <summary>
    /// Check if camera has been moved 
    /// </summary>
    void checkCamera()
    {
        // Check movement every time period
        cameraTimer_ += Time.deltaTime;
        if(cameraTimer_ > timeToCheckState_ ) {
            bool moved = false;

            // Check X axis
            if (Input.GetAxis("HorizontalGamepad") < 0)
            {
                Debug.Log("Camera: Moving Left");
                moved = true;
            }
            else if (Input.GetAxis("HorizontalGamepad") > 0)
            {
                Debug.Log("Camera: Moving Right");
                moved = true;
            }

            // Check Y axis
            if (Input.GetAxis("VerticalGamepad") < 0)
            {
                Debug.Log("Camera: Moving Down");
                moved = true;
            }
            else if (Input.GetAxis("VerticalGamepad") > 0)
            {
                Debug.Log("Camera: Moving Up");
                moved = true;
            }

            // Reset camera timer
            if (moved)
            {
                cameraTimer_ = 0;
            }
        }
    }

   
  
    float moveTimer_; ///< Timer controlling time until check gamepad's moves
    float cameraTimer_; ///< Timer controlling time until check gamepad's moves
    const float timeToCheckState_ = 0.3f; ///< Timer to check gamepad's states
}

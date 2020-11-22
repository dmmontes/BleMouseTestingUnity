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

    public string TextKey1 = ""; ///< Message representing the action done when key 1 is pressed
    public string TextKey2 = ""; ///< Message representing the action done when key 2 is pressed
    public string TextKey3 = ""; ///< Message representing the action done when key 3 is pressed
    public string TextKeyC = ""; ///< Message representing the action done when key C is pressed
    public string TextKeySpace = ""; ///< Message representing the action done when key Space is pressed
    
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
    /// Check if a special function key (key 1, 2, 3, C or Space) has been pressed
    /// </summary>
    void checkSpecialFunctions()
    {
        // Check key 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Key 1 pressed: " + TextKey1 + " (Button 1)"); 
        }
            
        // Check key 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Key 2 pressed: " + TextKey2 + " (Button 2)"); 
        }
            
        // Check key 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Key 3 pressed: " + TextKey3 + " (Joystick Button)"); 
        }
            
        // Check key C
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Key C pressed: " + TextKeyC + " (Accelerometer Crouch/Standup)"); 
        }
            
        // Check key Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed: " + TextKeySpace + " (Accelerometer Jump)"); 
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

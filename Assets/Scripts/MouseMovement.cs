using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scripts for mouse's movements
/// </summary>
public class MouseMovement : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update. Initialize objects
    /// </summary>
    void Start()
    {
        // Get images objects
        normalMouse_ = GameObject.FindGameObjectWithTag("NormalMouse");
        movingLeft_ = GameObject.FindGameObjectWithTag("MovingLeft");
        movingRight_ = GameObject.FindGameObjectWithTag("MovingRight");
        leftClick_ = GameObject.FindGameObjectWithTag("LeftClick");
        rightClick_ = GameObject.FindGameObjectWithTag("RightClick");
        middleClick_ = GameObject.FindGameObjectWithTag("MiddleClick");
        leftArrowOff_ = GameObject.FindGameObjectWithTag("LeftArrowOff");
        leftArrowOn_ = GameObject.FindGameObjectWithTag("LeftArrowOn");
        rightArrowOff_ = GameObject.FindGameObjectWithTag("RightArrowOff");
        rightArrowOn_ = GameObject.FindGameObjectWithTag("RightArrowOn");
        upArrowOff_ = GameObject.FindGameObjectWithTag("UpArrowOff");
        upArrowOn_ = GameObject.FindGameObjectWithTag("UpArrowOn");
        downArrowOff_ = GameObject.FindGameObjectWithTag("DownArrowOff");
        downArrowOn_ = GameObject.FindGameObjectWithTag("DownArrowOn");
        scrollUp_ = GameObject.FindGameObjectWithTag("ScrollUp");
        scrollDown_ = GameObject.FindGameObjectWithTag("ScrollDown");

        // Set images as invisible
        movingLeft_.SetActive(false);
        movingRight_.SetActive(false);
        leftClick_.SetActive(false);
        rightClick_.SetActive(false);
        middleClick_.SetActive(false);
        leftArrowOff_.SetActive(false);
        leftArrowOn_.SetActive(false);
        rightArrowOff_.SetActive(false);
        rightArrowOn_.SetActive(false);
        upArrowOff_.SetActive(false);
        upArrowOn_.SetActive(false);
        downArrowOff_.SetActive(false);
        downArrowOn_.SetActive(false);
        scrollUp_.SetActive(false);
        scrollDown_.SetActive(false);

        // Initialize mouse position
        mousePos_.x = 0;
        mousePos_.y = 0;

        // Initialize timer to check states
        moveTimer_ = timeToCheckState_;
        scrollTimer_ = timeToCheckState_;
    }

    /// <summary>
    /// Update is called once per frame. Check mouse's state changes
    /// </summary>
    void Update()
    {
        checkRightClick();
        checkLeftClick();
        checkMiddleClick();
        checkMoves();
        checkScroll();
    }
    
    private

    /// <summary>
    /// Check if a right click has changed (pressed, released)
    /// </summary>
    void checkRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Mouse Button Clicked");
            rightClick_.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Right Mouse Button Released");
            rightClick_.SetActive(false);
        }
    }

    /// <summary>
    /// Check if a left click has changed (pressed, released)
    /// </summary>
    void checkLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Button Clicked");
            leftClick_.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Left Mouse Button Released");
            leftClick_.SetActive(false);
        }
    }


    /// <summary>
    /// Check if a middle click has changed (pressed, released)
    /// </summary>
    void checkMiddleClick()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Middle Mouse Button Clicked");
            middleClick_.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(2))
        {
            Debug.Log("Middle Mouse Button Released");
            middleClick_.SetActive(false);
        }
    }

    /// <summary>
    /// Check if mouse has been moved 
    /// </summary>
    void checkMoves()
    {
        Vector3 mousePos = Input.mousePosition;

        // Check moving in frames of "timeToCheckState"
        moveTimer_ += Time.deltaTime;
        if( moveTimer_ > timeToCheckState_ ) {

            // Check vertical and horizontal movements
            bool moved = false;
            moved |= checkVerticalMoves(mousePos);
            moved |= checkHorizontalMoves(mousePos);
           
            // Enable or disable moving images
            if (moved)
            {
                movingRight_.SetActive(true);
                movingLeft_.SetActive(true);
                moveTimer_ = 0;
            }
            else 
            {
                movingRight_.SetActive(false);
                movingLeft_.SetActive(false);

                leftArrowOff_.SetActive(false);
                leftArrowOn_.SetActive(false);
                rightArrowOff_.SetActive(false);
                rightArrowOn_.SetActive(false);
                upArrowOff_.SetActive(false);
                upArrowOn_.SetActive(false);
                downArrowOff_.SetActive(false);
                downArrowOn_.SetActive(false);
            }
        }
        // Update mouse position
        mousePos_ = mousePos;
    }

    /// <summary>
    /// Check if mouse has been moved in vertical position
    /// </summary>
    bool checkVerticalMoves(Vector3 mousePos)
    {
        bool moved = false;
        if (mousePos.y < mousePos_.y )
        {
            Debug.Log("Mouse moved DOWN. Units: " + (int)(mousePos_.y - mousePos.y));
            downArrowOn_.SetActive(true);
            downArrowOff_.SetActive(false);
            upArrowOn_.SetActive(false);
            upArrowOff_.SetActive(true);
            moved = true;
        }
        else if (mousePos.y > mousePos_.y)
        {
            Debug.Log("Mouse moved UP. Units: " + (int)(mousePos.y - mousePos_.y));
            downArrowOn_.SetActive(false);
            downArrowOff_.SetActive(true);
            upArrowOn_.SetActive(true);
            upArrowOff_.SetActive(false);
            moved = true;
        }
        else
        {
            downArrowOn_.SetActive(false);
            downArrowOff_.SetActive(true);
            upArrowOn_.SetActive(false);
            upArrowOff_.SetActive(true);
        }
        return moved;
    }

    /// <summary>
    /// Check if mouse has been moved in horizontal position
    /// </summary>
    bool checkHorizontalMoves(Vector3 mousePos)
    {
        bool moved = false;
        if (mousePos.x > mousePos_.x)
        {
            Debug.Log("Mouse moved RIGHT. Units: " + (int)(mousePos.x - mousePos_.x));
            rightArrowOn_.SetActive(true);
            rightArrowOff_.SetActive(false);
            leftArrowOn_.SetActive(false);
            leftArrowOff_.SetActive(true);
            moved = true;
        }
        else if (mousePos.x < mousePos_.x)
        {
            Debug.Log("Mouse moved LEFT. Units: " + (int)(mousePos_.x - mousePos.x));
            rightArrowOn_.SetActive(false);
            rightArrowOff_.SetActive(true);
            leftArrowOn_.SetActive(true);
            leftArrowOff_.SetActive(false);
            moved = true;
        }
        else
        {
            rightArrowOn_.SetActive(false);
            rightArrowOff_.SetActive(true);
            leftArrowOn_.SetActive(false);
            leftArrowOff_.SetActive(true);
        }
        return moved;
    }

    /// <summary>
    /// Check if mouse has scrolled up/down
    /// </summary>
    void checkScroll()
    {
        scrollTimer_ += Time.deltaTime;
        if( scrollTimer_ > timeToCheckState_ ) {
            if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                Debug.Log("Scrolling up");
                scrollUp_.SetActive(true);
                scrollDown_.SetActive(false);
                scrollTimer_ = 0;
            }
            else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                Debug.Log("Scrolling down");
                scrollDown_.SetActive(true);
                scrollUp_.SetActive(false);
                scrollTimer_ = 0;
            }
            else
            {
                scrollUp_.SetActive(false);
                scrollDown_.SetActive(false);
            }
        }
    }

    GameObject normalMouse_; ///< Object referencing to "NormalMouse" image
    GameObject movingLeft_; ///< Object referencing to "MovingLeft" image
    GameObject movingRight_; ///< Object referencing to "MovingRight" image
    GameObject leftClick_; ///< Object referencing to "LeftClick" image
    GameObject rightClick_; ///< Object referencing to "RightClick" image
    GameObject middleClick_; ///< Object referencing to "MiddleClick" image
    GameObject leftArrowOff_; ///< Object referencing to "LeftArrowOff" image
    GameObject leftArrowOn_; ///< Object referencing to "LeftArrowOn" image
    GameObject rightArrowOff_; ///< Object referencing to "LeftArrowOff" image
    GameObject rightArrowOn_; ///< Object referencing to "RightArrowOn" image
    GameObject upArrowOff_; ///< Object referencing to "UpArrowOff" image
    GameObject upArrowOn_; ///< Object referencing to "UpArrowOn" image
    GameObject downArrowOff_; ///< Object referencing to "DownArrowOff" image
    GameObject downArrowOn_; ///< Object referencing to "DownArrowOn" image
    GameObject scrollUp_; ///< Object referencing to "ScrollUp" image
    GameObject scrollDown_; ///< Object referencing to "ScrollDown" image
    Vector3 mousePos_; ///< Represents the actual position of the mouse

    float moveTimer_; ///< Timer controlling time until check mouse's moves
    float scrollTimer_; ///< Timer controlling time until check mouse's scrolls
    const float timeToCheckState_ = 0.3f; ///< Timer to check mouse's states
}

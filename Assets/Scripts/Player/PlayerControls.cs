using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Processes input from InputActions asset using New Input System
 *
 * Jeff Stevenson
 * 5.17.25
 */

public class PlayerControls : MonoBehaviour
{
    #region Private Variables
    private Vector2 directionalInput;
    
    private bool isJumpPressed;
    private bool isJumpHeld;

    private bool isAttackPressed;
    private bool isAttackHeld;
    
    private bool isIgnitePressed;
    private bool isIgniteHeld;
    #endregion
    
    #region Public Variables (Getters)

    public Vector2 DirectionalInput
    {
        get { return directionalInput; }
    }

    public bool IsJumpPressed
    {
        get { return isJumpPressed; }
    }

    public bool IsJumpHeld
    {
        get { return isJumpHeld; }
    }

    public bool IsAttackPressed
    {
        get { return isAttackPressed;  }
    }
    
    public bool IsAttackHeld
    {
        get { return isAttackHeld;  }
    }

    public bool IsIgnitePressed
    {
        get { return isIgnitePressed; }
    }

    public bool IsIgniteHeld
    {
        get { return isIgniteHeld; }
    }
    
    #endregion

    private void OnMove(InputValue value)
    {
        directionalInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        isJumpPressed = value.isPressed;
    }
    
    private void OnAttack(InputValue value)
    {
        isAttackPressed = value.isPressed;   
    }

    private void OnIgnite(InputValue value)
    {
        isIgnitePressed = value.isPressed;
    }
}

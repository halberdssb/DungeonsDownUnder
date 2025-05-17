using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Processes input from InputActions asset using New Input System
 *
 * Jeff Stevenson
 * 5.17.25
 */

namespace Player
{
    public class Input : MonoBehaviour
    {
        #region Private Variables
        private Vector2 _directionalInput;
    
        private bool _isJumpPressed;
        private bool _isJumpHeld;

        private bool _isAttackPressed;
        private bool _isAttackHeld;
    
        private bool _isIgnitePressed;
        private bool _isIgniteHeld;
        #endregion
    
        #region Public Variables (Getters)

        public Vector2 DirectionalInput
        {
            get { return _directionalInput; }
        }

        public bool IsJumpPressed
        {
            get { return _isJumpPressed; }
        }

        public bool IsJumpHeld
        {
            get { return _isJumpHeld; }
        }

        public bool IsAttackPressed
        {
            get { return _isAttackPressed;  }
        }
    
        public bool IsAttackHeld
        {
            get { return _isAttackHeld;  }
        }

        public bool IsIgnitePressed
        {
            get { return _isIgnitePressed; }
        }

        public bool IsIgniteHeld
        {
            get { return _isIgniteHeld; }
        }
    
        #endregion
        
        #region Input Methods
        private void OnMove(InputValue value)
        {
            _directionalInput = value.Get<Vector2>();
        }

        private void OnJump(InputValue value)
        {
            _isJumpPressed = value.isPressed;
        }
    
        private void OnAttack(InputValue value)
        {
            _isAttackPressed = value.isPressed;   
        }

        private void OnIgnite(InputValue value)
        {
            _isIgnitePressed = value.isPressed;
        }
        #endregion
    }
}
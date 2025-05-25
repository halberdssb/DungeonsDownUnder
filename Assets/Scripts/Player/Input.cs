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
        private float _lastHeldXDirection;
    
        private bool _isJumpPressed;
        private bool _isJumpHeld;

        private bool _isAttackPressed;
        private bool _isAttackHeld;
    
        private bool _isIgnitePressed;
        private bool _isIgniteHeld;

        private bool _jumpHeldLastFrame;
        private bool _igniteHeldLastFrame;
        private bool _attackHeldLastFrame;
        
        #endregion
    
        #region Public Variables (Getters)

        public Vector2 DirectionalInput
        {
            get { return _directionalInput; }
        }

        public float LastHeldXDirection
        {
            get { return _lastHeldXDirection; }
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

        // checks initial value pressed (NOT held) bools - physics values should be checked in fixedupdate
        private void Update()
        {
            // ignite pressed 
            if (_igniteHeldLastFrame)
            {
                _isIgnitePressed = false;
            }

            _igniteHeldLastFrame = _isIgniteHeld;
            
            // attack pressed
            if (_attackHeldLastFrame)
            {
                _isAttackPressed = false;
            }

            _attackHeldLastFrame = _isAttackHeld;
            
            // handle last held x direction
            if (_directionalInput.x != 0)
            {
                _lastHeldXDirection = Mathf.Sign(_directionalInput.x);
            }
        }
        
        // checks initial value pressed (NOT held) bools - non-physics values should be checked in update
        private void FixedUpdate()
        {
            // jump pressed 
            if (_jumpHeldLastFrame)
            {
                _isJumpPressed = false;
            }

            _jumpHeldLastFrame = _isJumpHeld;
        }
        
        #region Input Methods
        private void OnMove(InputValue value)
        {
            _directionalInput = value.Get<Vector2>();
        }

        private void OnJump(InputValue value)
        {
            _isJumpPressed = value.isPressed;
            _isJumpHeld = value.isPressed;
        }
    
        private void OnAttack(InputValue value)
        {
            _isAttackPressed = value.isPressed && !_isAttackHeld;
            _isAttackHeld = value.isPressed;
        }

        private void OnIgnite(InputValue value)
        {
            _isIgnitePressed = value.isPressed && !_isIgniteHeld;
            _isIgniteHeld = value.isPressed;
        }
        #endregion
    }
}
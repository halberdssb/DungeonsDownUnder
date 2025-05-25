using UnityEngine;

/*
 * Handles player state while grounded
 *
 * Jeff Stevenson
 * 5.17.25
 */

namespace Player.States
{
    public class GroundState : BaseState
    {
        public GroundState(StateController player)
        {
            base.InitializeState(player);
        }
    
        public override void EnterState()
        {
            return;
        }

        public override void UpdateState()
        {
            return;
        }

        public override void FixedUpdateState()
        {
            // ground movement
            player.movement.Run(player.input.DirectionalInput.x, player.data.moveSpeed, player.data.groundAccelValue, player.data.groundDecelValue);
            player.movement.ApplyFriction(player.data.groundFriction);
            
            // check for jump buffer (check if y velocity is negative to prevent stacking jump inputs when first leaving ground)
            if (player.input.IsJumpPressed || (player.movement.jumpPressedWhileAirborne && player.input.IsJumpHeld && player.movement.timeHoldingJump <= player.data.jumpBufferWindow))
            {
                player.movement.Jump(player.data.jumpForce);
                player.SwitchState(player.airState);
                return;
            }
            
            // check if not grounded (walked off of ledge)
            if (!player.movement.CheckIfGrounded())
            {
                player.SwitchState(player.airState);
                return;
            }
        }

        public override void ExitState()
        {
            return;
        }
    }
}
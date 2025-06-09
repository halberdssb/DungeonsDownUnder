using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Handles player logic while in air
 *
 * Jeff Stevenson
 * 5.17.25
 */

namespace Player.States
{
    public class AirState : BaseState
    {
        private bool allowNewJumpInput;
        private bool enteredStateHoldingJump;
        
        public AirState(StateController player)
        {
            base.InitializeState(player);
        }
        public override void EnterState()
        {
            player.movement.jumpPressedWhileAirborne = false;
            allowNewJumpInput = false;
            enteredStateHoldingJump = player.input.IsJumpHeld;
        }

        public override void UpdateState()
        {
            // handle jump hold for jump buffer
            if (player.input.IsJumpHeld)
            {
                player.movement.timeHoldingJump += Time.deltaTime;
            }
            else
            {
                player.movement.timeHoldingJump = 0f;
            }

            // new jump input handling for buffer
            if (!player.input.IsJumpHeld)
            {
                allowNewJumpInput = true;
            }
            if (player.input.IsJumpPressed && allowNewJumpInput)
            {
                player.movement.jumpPressedWhileAirborne = true;
            }
            
            // handle falling gravity
            if (player.rb.linearVelocityY < 0 && !player.movement.isUsingFallGravity)
            {
                player.rb.gravityScale = player.movement.baseGravity * player.data.fallGravityModifier;
                player.movement.isUsingFallGravity = true;
            }
            
            // increment coyote time timer
            player.movement.timeInAir += Time.deltaTime;
            
            // check for swap to ignite
            if (player.input.IsIgnitePressed)
            {
                player.movement.ApplyJumpCut();
                player.SwitchState(player.igniteStartupState);
                return;
            }
        }

        public override void FixedUpdateState()
        {
            // lateral movement
            player.movement.Run(player.input.DirectionalInput.x, player.data.moveSpeed, player.data.groundAccelValue, player.data.groundDecelValue);
            player.movement.ApplyFriction(player.data.airFriction);
            
            // handle jump cut
            if (player.rb.linearVelocity.y > 0 && !player.input.IsJumpHeld)
            {
                player.movement.ApplyJumpCut();
            }
            
            // handle coyote time
            if (!enteredStateHoldingJump && player.input.IsJumpPressed && player.movement.timeInAir < player.data.coyoteTimeWindow)
            {
                player.rb.linearVelocityY = 0f;
                player.rb.gravityScale = player.movement.baseGravity;
                player.movement.Jump(player.data.jumpForce);
            }
            
            // check if grounded
            if (player.movement.CheckIfGrounded())
            {
                player.SwitchState(player.groundState);
                return;
            }
        }

        public override void ExitState()
        {
            // reset gravity
            player.rb.gravityScale = player.movement.baseGravity;
            player.movement.isUsingFallGravity = false;

            player.movement.timeInAir = 0f;
        }
        
    }
}
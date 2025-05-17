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
            player.movement.Run(player.input.DirectionalInput.x, player.data.moveSpeed, player.data.groundAccelValue, player.data.groundDecelValue);
            player.movement.ApplyFriction(player.data.frictionValue);
        }

        public override void ExitState()
        {
            return;
        }
    }
}
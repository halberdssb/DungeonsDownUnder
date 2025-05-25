using UnityEngine;

/*
 * Handles when the player enters ignite in the air until they hit an obstacle
 *
 * Jeff Stevenson
 * 5.25.25
 */

namespace Player.States
{
    public class IgniteAirState : BaseState
    {
        public IgniteAirState(StateController player)
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
            // move laterally with ignite air values - do not apply friction here
            player.movement.Run(player.input.LastHeldXDirection, player.data.igniteAirSpeed, player.data.igniteAirAccelValue, player.data.igniteAirDecelValue);
            
            // check if hit ground to exit state
            if (player.movement.CheckIfGrounded())
            {
                player.SwitchState(player.groundState);
                return;
            }
            return;
        }

        public override void ExitState()
        {
            return;
        }
    
        public override void InitializeState(StateController player)
        {
            this.player = player;
        }
    
        public override void OnCollisionEnter(Collision collider)
        {
            //if ((player.data.groundLayerMask & (1 << collider.gameObject.layer)) != 0)
            //{
            //    
            //}
            return;
        }
    
        public override void OnCollisionExit(Collision collider)
        {
            return;
        }
    
        public override void OnTriggerEnter(Collider other)
        {
            return;
        }
    
        public override void OnTriggerExit(Collider other)
        {
            return;
        }
    }
}
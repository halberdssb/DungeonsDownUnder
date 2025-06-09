using UnityEngine;

/*
 * State player is in after an ignite charge launch - suspends gravity for
 * an amount for consistent launch force regardless of angle
 *
 * Jeff Stevenson
 * 6.9.25
 */

namespace Player.States
{
    public class IgniteLaunchState : BaseState
    {    
        private bool isLaunching;
        private float launchTimer;

        private float previousGravityScale;

        public IgniteLaunchState(StateController player)
        {
            base.InitializeState(player);
        }
        
        public override void EnterState()
        {
            launchTimer = player.data.igniteLaunchStateTime;
            previousGravityScale = player.rb.gravityScale;
            player.rb.gravityScale = 0;
        }

        public override void UpdateState()
        {
            // decrement timer and exit into normal ignite state if time is up
            if (launchTimer <= 0f)
            {
                player.SwitchState(player.igniteAirState);
                return;
            }
            
            launchTimer -= Time.deltaTime;
        }

        public override void FixedUpdateState()
        {
            return;
        }

        public override void ExitState()
        {
            player.rb.gravityScale = previousGravityScale;
        }
    }
}
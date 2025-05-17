using UnityEngine;

/*
 * Handles player state while grounded
 *
 * Jeff Stevenson
 * 5.17.25
 */

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateController player)
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
        return;
    }

    public override void ExitState()
    {
        return;
    }
}

using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Data/DataPlayerData")]
    public class Data : ScriptableObject
    {
        #region Movement
        [Header("Movement")]
        [Tooltip("Max lateral speed")]
        public float moveSpeed;

        public float groundAccelValue;
        public float groundDecelValue;
    
        [Tooltip("Handles rate of acceleration with speed - < 1 = acceleration grows w/ speed, > 1 = acceleration decreases")]
        public float velocityPower;

        [Tooltip("Amount of custom friction applied when stopping on ground")]
        public float groundFriction;
        [Tooltip("Amount of custom friction applied when stopping in air")]
        public float airFriction;

        [Space] 
        public float jumpForce;
        [Tooltip("Percentage of vertical velocity the jump cut reduces")]
        public float jumpCutMultiplier;
        [Tooltip("Time (in seconds) the player can still jump after entering air state")]
        public float coyoteTimeWindow;
        [Tooltip("Time (in seconds) a jump can be buffered before landing")]
        public float jumpBufferWindow;
        [Tooltip("Custom gravity modifier when the player is falling")]
        public float fallGravityModifier;

        #endregion
        
        #region Checks

        public LayerMask groundLayerMask;

        #endregion
    }
}
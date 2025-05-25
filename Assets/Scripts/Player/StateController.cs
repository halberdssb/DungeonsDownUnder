using Player.States;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

/*
 * Handles player states, including switching between states and calling proper state functions
 *
 * Jeff Stevenson
 * 5.17.25
 */

namespace Player
{
    public class StateController : MonoBehaviour
    {
        #region States

        private BaseState _currentState;
        
        public GroundState groundState;
        public AirState airState;
        public IgniteAirState igniteAirState;
        public IgniteChargeState igniteChargeState;
        public IgniteBuriedState igniteBuriedState;
        public IgniteCooldownState igniteCooldownState;
        public IgniteStartupState igniteStartupState;
        
        #endregion
        
        #region Component References
        public Data data;
        public Input input;
        public Movement movement;
        public Rigidbody2D rb;
        public BoxCollider2D environmentCollisionBox;
        #endregion
        
        #region Public Variables

        [Header("Debug")] 
        public bool debugEnabled;
        
        [HideInInspector]
        public bool isGrounded;
        #endregion
    
        private void Start()
        {
            CreateStates();
            
            // default to ground state
            SwitchState(groundState);
        }

        private void Update()
        {
            _currentState.UpdateState();
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdateState();
        }
        
        // Switches to a new state, calling enter and exit as necessary
        public void SwitchState(BaseState newState)
        {
            if (debugEnabled)
            {
                Debug.Log("Player exited state: " + _currentState);
                Debug.Log("Player entered state: " + newState);
            }

            
            _currentState?.ExitState();
            _currentState = newState;
            _currentState.EnterState();
        }
    
        // Instantiates all states with player reference
        private void CreateStates()
        {
            groundState = new GroundState(this);
            airState = new AirState(this);
            igniteAirState = new IgniteAirState(this);
            igniteChargeState = new IgniteChargeState(this);
            igniteBuriedState = new IgniteBuriedState(this);
            igniteCooldownState = new IgniteCooldownState(this);
            igniteStartupState = new IgniteStartupState(this);
        }
    }
}


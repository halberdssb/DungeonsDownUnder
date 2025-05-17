using Player.States;
using UnityEngine;

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
        
        private GroundState _groundState;
        
        #endregion
        
        #region Component References
        public Data data;
        public Input input;
        public Movement movement;
        #endregion
    
        private void Start()
        {
            CreateStates();
            
            // default to ground state
            SwitchState(_groundState);
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
            _currentState?.ExitState();
            _currentState = newState;
            _currentState.EnterState();
        }
    
        // Instantiates all states with player reference
        private void CreateStates()
        {
            _groundState = new GroundState(this);
        }
    }
}


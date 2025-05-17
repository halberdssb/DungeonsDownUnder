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

        [Tooltip("Amount of custom friction applied when stopping")]
        public float frictionValue;

        #endregion
    }
}
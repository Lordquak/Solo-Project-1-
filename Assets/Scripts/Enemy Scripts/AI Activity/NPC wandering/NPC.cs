using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class NPC : MonoBehaviour
    {
        [HideInInspector]
        public NavMeshAgent Agent;

        [HideInInspector]
        public Animator Animator;

        public float CurrentSpeed
        {
            get { return Agent.velocity.magnitude; }
        }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
        }

        #region Sensors

        public NPC Sensor;
        
        public Vector3 SensorPosition
        {
            get
            {
                return transform.position + Vector3.up * 1.5f;
            }
        }

        public void MakeNoise(NoiseInfo noiseInfo)
        {
            noiseInfo.Owner = this;

            NoiseSystem.Instance?.MakeNoise(noiseInfo);
        }


        #endregion
    }
}

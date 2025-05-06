using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

namespace Game

{
    public class NPCWander : NPCComponent
    {

        public Area Area;

        enum EState
        {
            Wandering,
            Waiting
        }

        [SerializeField]
        float maxWaitTime = 2f;

        [SerializeField]
        float maxWaitTimeRandom = 4f;

        [Space(15f)]
        float maxWanderTime = 6f;

        //float currentMaxWaitTime = 3f;

        [SerializeField]
        private float waitTime = 0f;

        [Header("Debugging")]
        [SerializeField]
        EState state = EState.Wandering;

        [SerializeField]
        private float wanderTime = 0f;



        private void Start()
        {
            if (Random.Range(0f, 100.0f) > 50f)
            {
                ChangeState(EState.Wandering);
            }
            else
            {
                ChangeState(EState.Waiting);
            }
        }


        private void Update()
        {
            if (state == EState.Waiting)
            {
                waitTime -= Time.deltaTime;

                if (waitTime < 0f)
                {
                    ChangeState(EState.Wandering);
                }
            }
            else if (state == EState.Wandering)
            {
                wanderTime -= Time.deltaTime;


                if (HasArrived() || wanderTime < 0f )
                {
                    ChangeState(EState.Waiting);
                }
            }
        }
            void ChangeState(EState newState)
            {
                state = newState;


                if (state == EState.Wandering)
                {
                    npc.Agent.isStopped = false;

                    SetRandomDestination();

                    wanderTime = maxWanderTime;
                }
                else if (state == EState.Waiting)
                {
                waitTime = maxWaitTime + Random.Range(0f, maxWaitTimeRandom);

                    npc.Agent.isStopped = true;
                }

            }
            bool HasArrived()
            {
                return npc.Agent.remainingDistance <= npc.Agent.stoppingDistance;


            }

            void SetRandomDestination()
            {
                npc.Agent.SetDestination(Area.GetRandomPoint());
            }
        
    }
}

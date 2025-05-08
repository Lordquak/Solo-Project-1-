using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;

using UnityEngine.AI;
using Game; //For use of Navmesh agent

public class FunctionalAdult : MonoBehaviour, IHear
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private NPCWander npcWander = null; // Reference to NPCWander script

    [SerializeField, Tooltip("How far away, in meters, the agent will run from danger.")]
    private float displacementFromDanger = 10f;
    private Vector3 targetPos;
    private bool isMovingToTarget = false;

    void Awake()
    {
        if (agent == null && !TryGetComponent(out agent))
            Debug.LogWarning(name + " doesn't have an agent!");
    }

    public void RespondToSound(Sound sound)
    {
        if (sound.soundType == Sound.SoundType.Interesting)
        {
            // Move to the sound position
            targetPos = sound.pos;
            MoveTo(targetPos);

            agent.speed = 13f;

            // Disable NPC wandering while responding to sound
            npcWander.enabled = false;

            // Track that we are moving to a target
            isMovingToTarget = true;
        }
        else
        {
           
            // Enable wandering for other sound types
            npcWander.enabled = true;
            
        }
    }

    private void MoveTo(Vector3 pos)
    {
        // Set the destination for the NavMeshAgent
        agent.SetDestination(pos);
        agent.isStopped = false; // Ensure the agent is moving
    }

    void Update()
    {
        // Check if we are moving to the target position
        if (isMovingToTarget)
        {
            // Check if the NPC has reached the destination
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                // If agent has stopped moving (destination reached)
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Re-enable NPCWander once we reach the destination
                    npcWander.enabled = true;

                    // Stop checking movement
                    isMovingToTarget = false;
                }
            }
        }


    }
}

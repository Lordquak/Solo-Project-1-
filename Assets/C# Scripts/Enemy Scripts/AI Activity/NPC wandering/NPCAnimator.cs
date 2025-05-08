
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.NavigationTutorial
{
    public class NPCanimator : NPCComponent
    {
        private void Update()
        {
            npc.Animator.SetFloat("Speed", npc.CurrentSpeed);
        }
    }
}

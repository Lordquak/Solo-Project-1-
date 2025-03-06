using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public enum NoiseType 
    { 
      Footsteps,

    
    }
    public struct NoiseInfo
    {

     public NPC Owner;
     public NoiseType Type;
     public Vector3 Position;
     public float Radius;
    }
}
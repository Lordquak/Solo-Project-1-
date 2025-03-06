using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class NoiseSystem : MonoBehaviour
    {
        [SerializeField]
        LayerMask CharacterLayers = Physics.DefaultRaycastLayers;

        public static NoiseSystem Instance { get; private set; }

        

        public void MakeNoise(NoiseInfo noise)
        {
            var colliders = Physics.OverlapSphere(noise.Position, noise.Radius, CharacterLayers, QueryTriggerInteraction.Ignore);

            foreach (var collider in colliders)
            {
                INoiseListener listener = collider.GetComponentInParent<INoiseListener>();

                listener?.OnNoiseHeard(noise);
            }
        }



        void Awake()
        {
            Instance = this;
        }
    }
}
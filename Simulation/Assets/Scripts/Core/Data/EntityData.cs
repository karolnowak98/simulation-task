using UnityEngine;

namespace GlassyCode.Simulation.Core.Data
{
    public abstract class EntityData : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; } 
    }
}
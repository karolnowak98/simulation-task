using GlassyCode.Simulation.Agents.Data;
using GlassyCode.Simulation.Core.Pools.Object;
using GlassyCode.Simulation.Core.Utility;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Agents.Logic
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Agent : GlassyObjectPoolElement<Agent>, IAgent
    {
        [field: SerializeField] public AgentData Data { get; private set; }

        private Rigidbody _rb;
        private int _health;
        private int _moveSpeed;
        private int _damage;

        private void Awake()
        {
            TryGetComponent(out _rb);

            _health = Data.InitialHealth;
            _moveSpeed = Data.MoveSpeed;
            _damage = Data.Damage;
        }
        
        private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("Wall"))
            {
                
            }

            if (col.CompareTag("Agent"))
            {
                col.TryGetComponent<IAgent>(out var agent);
                agent?.TakeDamage(_damage);
            }
        }
        
        public override void Reset()
        {
            _rb.SetRandomDirectionVelocityXZ(_moveSpeed);
            
            Enable();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Pool.Release(this);
                Destroy();
            }
        }
        
        public sealed class Factory : PlaceholderFactory<Object, Agent>{ }
    }
}
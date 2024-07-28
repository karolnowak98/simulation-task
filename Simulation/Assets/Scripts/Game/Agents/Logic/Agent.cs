using GlassyCode.Simulation.Core.Pools.Object;
using GlassyCode.Simulation.Core.Utility.Extensions;
using GlassyCode.Simulation.Core.Utility.Interfaces;
using GlassyCode.Simulation.Game.Agents.Data;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.Logic
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public sealed class Agent : GlassyObjectPoolElement<Agent>, IAgent, ISelectable, IDamageable
    {
        [field: SerializeField] public AgentData Data { get; private set; }
        [field: SerializeField] public GameObject Selection { get; private set; }

        [Inject] private SignalBus _signalBus;
        
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
        
        private void OnCollisionEnter(Collision col)
        {
            var colGo = col.gameObject;

            if (!colGo.CompareTag("Agent") || !colGo.TryGetComponent<IDamageable>(out var damageable))
            {
                return;
            }
            
            damageable.TakeDamage(_damage);
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
                Die();
            }
        }
        
        public void Die()
        {
            Deselect();
            Pool.TryRelease(this);
            _signalBus.TryFire(new AgentDiedSignal{ Agent = this });
        }

        public void Select()
        {
            Selection.SetActive(true);
        }

        public void Deselect()
        {
            Selection.SetActive(false);
        }
        
        public sealed class Factory : PlaceholderFactory<Object, Agent>{ }
    }
}
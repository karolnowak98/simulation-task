using System;
using GlassyCode.Simulation.Core.Pools.Object;
using GlassyCode.Simulation.Core.Utility.Extensions;
using GlassyCode.Simulation.Core.Utility.Interfaces;
using GlassyCode.Simulation.Game.Agents.Data;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

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

        public int Health
        {
            get => _health;
            private set
            {
                if (_health != value)
                {
                    _health = value;
                    OnHealthChanged?.Invoke(_health);
                }
            }
        }

        public int MoveSpeed { get; private set; }
        public int Damage { get; private set; }

        public event Action<int> OnHealthChanged;
        public event Action OnDied;
        
        [Inject]
        private void Construct(Vector3 position, Transform parent, IGlassyObjectPool<Agent> pool)
        {
            SetPosition(position);
            SetParent(parent);
            Pool = pool;
        }
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            MoveSpeed = Data.MoveSpeed;
            Damage = Data.Damage;
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Agent") && col.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(Damage);
            }
        }

        public override void Reset()
        {
            _rb.SetRandomDirectionVelocityXZ(MoveSpeed);
            Health = Data.InitialHealth;
            Enable();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Deselect();
            Pool.TryRelease(this);
            OnDied?.Invoke();
            _signalBus.TryFire(new AgentDiedSignal { Agent = this });
        }

        public void Select()
        {
            Selection.SetActive(true);
        }

        public void Deselect()
        {
            Selection.SetActive(false);
        }

        public sealed class Factory : PlaceholderFactory<Object, Vector3, Transform, IGlassyObjectPool<Agent>, Agent> {}
    }
}
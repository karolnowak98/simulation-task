using System;
using GlassyCode.Simulation.Core.Utility.Extensions;
using GlassyCode.Simulation.Core.Utility.Interfaces;
using GlassyCode.Simulation.Game.Agents.Data;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using GlassyCode.Simulation.Game.Global.Input;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.Logic.Selector
{
    public sealed class AgentSelector : IAgentSelector, IEnableable, IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IInputManager _inputManager;
        private readonly Camera _camera;
        private readonly LayerMask _layerMask;
        private IAgent _selectedAgent;
        private bool _canSelect;

        public event Action<IAgent> OnAgentSelected;
        public event Action OnAgentDeselected;
        public event Action<int> OnSelectedAgentHealthChanged;

        public AgentSelector(SignalBus signalBus, IInputManager inputManager, IAgentsConfig config)
        {
            _layerMask = config.LayerMask;
            _signalBus = signalBus;
            _inputManager = inputManager;
            _camera = CameraExtensions.GetMainCamera();
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<AgentDiedSignal>(OnAgentDied);
        }

        public void Dispose()
        {
            _signalBus.Subscribe<AgentDiedSignal>(OnAgentDied);
        }

        public void Enable()
        {
            if (_canSelect)
            {
                return;
            }

            _inputManager.OnSelect += SelectAgent;
            _inputManager.OnCancel += DeselectAgent;
            _canSelect = true;
        }

        public void Disable()
        {
            if (!_canSelect)
            {
                return;
            } 

            _inputManager.OnSelect -= SelectAgent;
            _inputManager.OnCancel -= DeselectAgent;
            _canSelect = false;
        }

        private void SelectAgent()
        {
            var ray = _camera.ScreenPointToRay(_inputManager.MousePosition);

            var hitCollider = PhysicsExtensions.GetRayastHitCollider(ray, _layerMask);
            if (hitCollider == null)
            {
                DeselectAgent();
                return;
            }
            
            if (hitCollider.TryGetComponent(out IAgent agent))
            {
                DeselectAgent();  
                _selectedAgent = agent;
                _selectedAgent.Select();
                _selectedAgent.OnHealthChanged += OnHealthChanged;
                _selectedAgent.OnDied += DeselectAgent;
                OnAgentSelected?.Invoke(agent);
            }
        }

        private void DeselectAgent()
        {
            if (_selectedAgent == null)
            {
                return;
            }
            
            _selectedAgent.Deselect();
            _selectedAgent.OnHealthChanged -= OnHealthChanged;
            _selectedAgent.OnDied -= DeselectAgent;
            _selectedAgent = null;
            OnAgentDeselected?.Invoke();
        }
        
        private void OnAgentDied(AgentDiedSignal signal)
        {
            if (_selectedAgent == signal.Agent)
            {
                DeselectAgent();
            }
        }

        private void OnHealthChanged(int health)
        {
            OnSelectedAgentHealthChanged?.Invoke(health);
        }
    }
}
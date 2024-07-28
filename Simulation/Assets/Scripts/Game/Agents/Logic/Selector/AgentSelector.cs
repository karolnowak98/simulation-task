using System;
using GlassyCode.Simulation.Core.Utility.Extensions;
using GlassyCode.Simulation.Core.Utility.Interfaces;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using GlassyCode.Simulation.Game.Input;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.Logic.Selector
{
    public sealed class AgentSelector : IAgentSelector, IEnableable, IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IInputManager _inputManager;
        private readonly Camera _camera;
        
        private IAgent _selectedAgent;
        private bool _isEnabled;

        public AgentSelector(SignalBus signalBus, IInputManager inputManager)
        {
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
            if (_isEnabled)
            {
                return;
            }

            _inputManager.OnSelect += SelectAgent;
            _inputManager.OnCancel += DeselectAgent;
            _isEnabled = true;
        }

        public void Disable()
        {
            if (!_isEnabled)
            {
                return;
            } 

            _inputManager.OnSelect -= SelectAgent;
            _inputManager.OnCancel -= DeselectAgent;
            _isEnabled = false;
        }

        private void SelectAgent()
        {
            var mouseScreenPosition = _inputManager.MousePosition;
            var ray = _camera.ScreenPointToRay(mouseScreenPosition);

            if (Physics.Raycast(ray, out var hit))
            {
                var collider = hit.collider;
                
                if (collider.CompareTag("Agent") && collider.TryGetComponent<IAgent>(out var agent))
                {
                    DeselectAgent();  
                    _selectedAgent = agent;
                    _selectedAgent.Select();
                    _selectedAgent.OnHealthChanged += FireHealthChangedSignal;
                    _selectedAgent.OnDied += DeselectAgent;
                    _signalBus.TryFire(new AgentSelectedSignal{ Agent = agent });
                }
            }
        }

        private void DeselectAgent()
        {
            if (_selectedAgent == null)
            {
                return;
            }
            
            _selectedAgent.Deselect();
            _selectedAgent.OnHealthChanged -= FireHealthChangedSignal;
            _selectedAgent.OnDied -= DeselectAgent;
            _selectedAgent = null;
            _signalBus.TryFire(new AgentDeselectedSignal());
        }
        
        private void OnAgentDied(AgentDiedSignal signal)
        {
            if (_selectedAgent != signal.Agent)
            {
                return;
            }
            
            DeselectAgent();
        }

        private void FireHealthChangedSignal(int health)
        {
            _signalBus.TryFire(new SelectedAgentHealthChangedSignal{ Health = health });
        }
    }
}
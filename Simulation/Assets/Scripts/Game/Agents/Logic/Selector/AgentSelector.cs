using GlassyCode.Simulation.Core.Utility.Extensions;
using GlassyCode.Simulation.Core.Utility.Interfaces;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using GlassyCode.Simulation.Game.Input;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.Logic.Selector
{
    public sealed class AgentSelector : IAgentSelector, IEnableable
    {
        private readonly SignalBus _signalBus;
        private readonly IInputManager _inputManager;
        private readonly Camera _camera;
        
        private ISelectable _selected;
        private bool _isEnabled;

        public AgentSelector(SignalBus signalBus, IInputManager inputManager)
        {
            _signalBus = signalBus;
            _inputManager = inputManager;
            _camera = CameraExtensions.GetMainCamera();
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
                
                if (collider.CompareTag("Agent") && collider.TryGetComponent<ISelectable>(out var selectable))
                {
                    DeselectAgent();  
                    selectable.Select();
                    _selected = selectable;
                    _signalBus.TryFire(new AgentSelectedSignal{ Agent = _selected });
                }
            }
        }

        private void DeselectAgent()
        {
            if (_selected == null)
            {
                return;
            }
            
            _selected.Deselect();
            _selected = null;
            _signalBus.TryFire(new AgentDeselectedSignal());
        }
    }
}
using System;
using GlassyCode.Simulation.Core.UI;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.UI
{
    public sealed class AgentInfoPanel : UIElement, IInitializable, IDisposable
    {
        [field: SerializeField] public TextMeshProUGUI NameTmp { get; private set; }
        [field: SerializeField] public TextMeshProUGUI HealthTmp { get; private set; }
        
        [Inject] private SignalBus _signalBus;

        public void Initialize()
        {
            _signalBus.Subscribe<AgentSelectedSignal>(SetAndShow);
            _signalBus.Subscribe<AgentDeselectedSignal>(Hide);
            _signalBus.Subscribe<SelectedAgentHealthChangedSignal>(SetHealth);
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<AgentSelectedSignal>(SetAndShow);
            _signalBus.TryUnsubscribe<AgentDeselectedSignal>(Hide);
            _signalBus.TryUnsubscribe<SelectedAgentHealthChangedSignal>(SetHealth);
        }

        private void SetAndShow(AgentSelectedSignal signal)
        {
            var agent = signal.Agent;
            var data = agent.Data;

            NameTmp.text = data.Name;
            HealthTmp.text = $"{agent.Health}";
            Show();
        }
        
        private void SetHealth(SelectedAgentHealthChangedSignal signal)
        {
            HealthTmp.text = $"{signal.Health}";
        }
    }
}
using System;
using GlassyCode.Simulation.Core.UI;
using GlassyCode.Simulation.Game.Agents.Logic;
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
        
        [Inject] private IAgentsManager _agentsManager;

        public void Initialize()
        {
            _agentsManager.Selector.OnAgentSelected += SetAndShow;
            _agentsManager.Selector.OnAgentDeselected += Hide;
            _agentsManager.Selector.OnSelectedAgentHealthChanged += SetHealth;
        }

        public void Dispose()
        {
            _agentsManager.Selector.OnAgentSelected -= SetAndShow;
            _agentsManager.Selector.OnAgentDeselected -= Hide;
            _agentsManager.Selector.OnSelectedAgentHealthChanged -= SetHealth;
        }

        private void SetAndShow(IAgent agent)
        {
            var data = agent.Data;

            NameTmp.text = data.Name;
            HealthTmp.text = $"{agent.Health}";
            Show();
        }
        
        private void SetHealth(int health)
        {
            HealthTmp.text = $"{health}";
        }
    }
}
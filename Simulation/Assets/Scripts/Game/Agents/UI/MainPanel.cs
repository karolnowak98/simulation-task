using System;
using GlassyCode.Simulation.Core.UI;
using GlassyCode.Simulation.Core.Utility.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.UI
{
    public sealed class MainPanel : UIElement, IInitializable, IDisposable
    {
        [field: SerializeField] public Button StartBtn { get; private set; }
        
        [Inject] private IEnableable _agentsManager;

        public void Initialize()
        {
            StartBtn.onClick.AddListener(StartGame);
        }

        public void Dispose()
        {
            StartBtn.onClick.RemoveAllListeners();
        }

        private void StartGame()
        {
            _agentsManager.Enable();
            Hide();
        }
    }
}
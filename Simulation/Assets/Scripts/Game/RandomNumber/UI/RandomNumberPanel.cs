using System;
using GlassyCode.Simulation.Core.UI;
using GlassyCode.Simulation.Game.RandomNumber.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GlassyCode.Simulation.Game.RandomNumber.UI
{
    public sealed class RandomNumberPanel : UIElement, IInitializable, IDisposable
    {
        [field: SerializeField] public Button ClickBtn { get; private set; }
        [field: SerializeField] public TextMeshProUGUI NumberTmp { get; private set; }
        [field: SerializeField] public TextMeshProUGUI MarkoPoloTmp { get; private set; }

        [Inject] private IRandomNumberManager _randomNumberManager;
        
        public void Initialize()
        {
            ClickBtn.onClick.AddListener(() => _randomNumberManager.RandomNumber());
            _randomNumberManager.OnRandomNumberChanged += UpdatePanel;
        }

        public void Dispose()
        {
            ClickBtn.onClick.RemoveAllListeners();
            _randomNumberManager.OnRandomNumberChanged -= UpdatePanel;
        }

        private void UpdatePanel(int number)
        {
            NumberTmp.text = $"{number}";

            var text = "";
            
            if (_randomNumberManager.IsDivisibleByFifteen)
            {
                text = _randomNumberManager.Config.DivisibleByFifteenText;
            }
            else if (_randomNumberManager.IsDivisibleByThree)
            {
                text = _randomNumberManager.Config.DivisibleByThreeText;
            }
            else if (_randomNumberManager.IsDivisibleByFive)
            {
                text = _randomNumberManager.Config.DivisibleByFiveText;
            }

            MarkoPoloTmp.text = text;
        }
    }
}
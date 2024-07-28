using System;
using GlassyCode.Simulation.Core.UI;
using GlassyCode.Simulation.Game.RandomNumber.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GlassyCode.Simulation.Game.RandomNumber.UI
{
    public sealed class NumberPanel : UIElement, IInitializable, IDisposable
    {
        [field: SerializeField] public Button ClickBtn { get; private set; }
        [field: SerializeField] public TextMeshProUGUI NumberTmp { get; private set; }
        [field: SerializeField] public TextMeshProUGUI MarkoPoloTmp { get; private set; }

        [Inject] private INumberManager _numberManager;
        
        public void Initialize()
        {
            ClickBtn.onClick.AddListener(() => _numberManager.GenerateRandomNumber());
            _numberManager.OnRandomNumberChanged += UpdatePanel;
        }

        public void Dispose()
        {
            ClickBtn.onClick.RemoveAllListeners();
            _numberManager.OnRandomNumberChanged -= UpdatePanel;
        }

        private void UpdatePanel(int number)
        {
            NumberTmp.text = $"{number}";

            var text = "";

            //More optimal would be checking if the number is divisible by 3 and 5 instead of 15, prioritize clarity
            if (_numberManager.IsDivisibleByFifteen)
            {
                text = _numberManager.Config.DivisibleByFifteenText;
            }
            else if (_numberManager.IsDivisibleByThree)
            {
                text = _numberManager.Config.DivisibleByThreeText;
            }
            else if (_numberManager.IsDivisibleByFive)
            {
                text = _numberManager.Config.DivisibleByFiveText;
            }

            MarkoPoloTmp.text = text;
        }
    }
}
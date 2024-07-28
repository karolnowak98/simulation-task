using System;
using GlassyCode.Simulation.Core.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace GlassyCode.Simulation.Game.Global.Input
{
    public sealed class InputManager : IInputManager, IInitializable, IDisposable
    {
        private readonly InputControls _controls = new();

        public event Action OnSelect;
        public event Action OnCancel;

        public Vector2 MousePosition => Mouse.current.position.ReadValue();

        public void Initialize()
        {
            _controls.Simulation.Select.performed += _ => OnSelect?.Invoke();
            _controls.Simulation.Cancel.performed += _ => OnCancel?.Invoke();
            _controls.Enable();
        }

        public void Dispose()
        {
            _controls.Disable();
        }
    }
}
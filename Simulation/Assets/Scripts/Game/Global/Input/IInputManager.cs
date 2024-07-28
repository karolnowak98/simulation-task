using System;
using UnityEngine;

namespace GlassyCode.Simulation.Game.Global.Input
{
    public interface IInputManager
    {
        Vector2 MousePosition { get; }
        event Action OnSelect;
        event Action OnCancel;
    }
}
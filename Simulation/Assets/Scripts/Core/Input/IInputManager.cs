using System;
using UnityEngine;

namespace GlassyCode.Simulation.Core.Input
{
    public interface IInputManager
    {
        Vector2 MoveAxis { get; }
        event Action OnSpacePressed;
    }
}
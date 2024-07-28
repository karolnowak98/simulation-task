﻿using System;
using Zenject;

namespace GlassyCode.Simulation.Game.Input
{
    public sealed class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(InputManager), typeof(IInputManager), 
                    typeof(IInitializable), typeof(IDisposable))
                .To<InputManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}
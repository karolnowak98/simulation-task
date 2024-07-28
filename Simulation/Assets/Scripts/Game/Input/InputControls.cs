//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Data/InputControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GlassyCode.Simulation.Core.Input
{
    public partial class @InputControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Simulation"",
            ""id"": ""5085c3be-0abf-4b7a-8025-567c42edfaef"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""685faee1-04a5-4a6d-9d80-49febaef390e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""7699bf27-5983-48db-ba1b-6de3df070573"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ea7efca0-e133-4753-b802-749c1dc00f84"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3078bf1b-d994-4fdf-9656-0a101656e1f4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1f5faae-2b3a-4617-ac4e-d5ae7f667d86"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Simulation
            m_Simulation = asset.FindActionMap("Simulation", throwIfNotFound: true);
            m_Simulation_Select = m_Simulation.FindAction("Select", throwIfNotFound: true);
            m_Simulation_Cancel = m_Simulation.FindAction("Cancel", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Simulation
        private readonly InputActionMap m_Simulation;
        private List<ISimulationActions> m_SimulationActionsCallbackInterfaces = new List<ISimulationActions>();
        private readonly InputAction m_Simulation_Select;
        private readonly InputAction m_Simulation_Cancel;
        public struct SimulationActions
        {
            private @InputControls m_Wrapper;
            public SimulationActions(@InputControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Select => m_Wrapper.m_Simulation_Select;
            public InputAction @Cancel => m_Wrapper.m_Simulation_Cancel;
            public InputActionMap Get() { return m_Wrapper.m_Simulation; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SimulationActions set) { return set.Get(); }
            public void AddCallbacks(ISimulationActions instance)
            {
                if (instance == null || m_Wrapper.m_SimulationActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_SimulationActionsCallbackInterfaces.Add(instance);
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }

            private void UnregisterCallbacks(ISimulationActions instance)
            {
                @Select.started -= instance.OnSelect;
                @Select.performed -= instance.OnSelect;
                @Select.canceled -= instance.OnSelect;
                @Cancel.started -= instance.OnCancel;
                @Cancel.performed -= instance.OnCancel;
                @Cancel.canceled -= instance.OnCancel;
            }

            public void RemoveCallbacks(ISimulationActions instance)
            {
                if (m_Wrapper.m_SimulationActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ISimulationActions instance)
            {
                foreach (var item in m_Wrapper.m_SimulationActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_SimulationActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public SimulationActions @Simulation => new SimulationActions(this);
        public interface ISimulationActions
        {
            void OnSelect(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
        }
    }
}

// GENERATED AUTOMATICALLY FROM 'Assets/Data/Input/ConsoleInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ConsoleInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }

    public @ConsoleInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ConsoleInput"",
    ""maps"": [
        {
            ""name"": ""Console"",
            ""id"": ""6c9fa5d8-810c-4a5a-b72d-8124fa7a397c"",
            ""actions"": [
                {
                    ""name"": ""Open"",
                    ""type"": ""Button"",
                    ""id"": ""96b782f4-91cd-4da9-b9cd-abca121324b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e7f012ec-73bf-4d37-b3e6-d4a915522928"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Console
        m_Console = asset.FindActionMap("Console", throwIfNotFound: true);
        m_Console_Open = m_Console.FindAction("Open", throwIfNotFound: true);
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

    // Console
    private readonly InputActionMap m_Console;
    private IConsoleActions m_ConsoleActionsCallbackInterface;
    private readonly InputAction m_Console_Open;

    public struct ConsoleActions
    {
        private @ConsoleInput m_Wrapper;

        public ConsoleActions(@ConsoleInput wrapper)
        {
            m_Wrapper = wrapper;
        }

        public InputAction @Open => m_Wrapper.m_Console_Open;

        public InputActionMap Get()
        {
            return m_Wrapper.m_Console;
        }

        public void Enable()
        {
            Get().Enable();
        }

        public void Disable()
        {
            Get().Disable();
        }

        public bool enabled => Get().enabled;

        public static implicit operator InputActionMap(ConsoleActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IConsoleActions instance)
        {
            if (m_Wrapper.m_ConsoleActionsCallbackInterface != null)
            {
                @Open.started -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnOpen;
                @Open.performed -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnOpen;
                @Open.canceled -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnOpen;
            }

            m_Wrapper.m_ConsoleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Open.started += instance.OnOpen;
                @Open.performed += instance.OnOpen;
                @Open.canceled += instance.OnOpen;
            }
        }
    }

    public ConsoleActions @Console => new ConsoleActions(this);

    public interface IConsoleActions
    {
        void OnOpen(InputAction.CallbackContext context);
    }
}

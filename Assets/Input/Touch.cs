//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Input/Touch.inputactions
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

public partial class @Touch : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Touch()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Touch"",
    ""maps"": [
        {
            ""name"": ""AR-Touch"",
            ""id"": ""0aed3925-fc51-4e2c-b87d-584d62fd4578"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Value"",
                    ""id"": ""93c3652d-3f21-45e5-932a-9f6fb55ddbec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c941e28-9d2b-4fdf-afe1-9aed78b5d650"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AR-Touch
        m_ARTouch = asset.FindActionMap("AR-Touch", throwIfNotFound: true);
        m_ARTouch_Touch = m_ARTouch.FindAction("Touch", throwIfNotFound: true);
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

    // AR-Touch
    private readonly InputActionMap m_ARTouch;
    private IARTouchActions m_ARTouchActionsCallbackInterface;
    private readonly InputAction m_ARTouch_Touch;
    public struct ARTouchActions
    {
        private @Touch m_Wrapper;
        public ARTouchActions(@Touch wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_ARTouch_Touch;
        public InputActionMap Get() { return m_Wrapper.m_ARTouch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ARTouchActions set) { return set.Get(); }
        public void SetCallbacks(IARTouchActions instance)
        {
            if (m_Wrapper.m_ARTouchActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_ARTouchActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_ARTouchActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_ARTouchActionsCallbackInterface.OnTouch;
            }
            m_Wrapper.m_ARTouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
            }
        }
    }
    public ARTouchActions @ARTouch => new ARTouchActions(this);
    public interface IARTouchActions
    {
        void OnTouch(InputAction.CallbackContext context);
    }
}

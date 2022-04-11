// GENERATED AUTOMATICALLY FROM 'Assets/VivecontrolUwu#.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VivecontrolUwu : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VivecontrolUwu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VivecontrolUwu#"",
    ""maps"": [
        {
            ""name"": ""ViveControlUwu"",
            ""id"": ""fb518266-b27e-45d5-812a-ca3aa9e22111"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b488545d-3ecb-4b57-9b4f-4fecc94f9a8c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Settings"",
                    ""type"": ""Button"",
                    ""id"": ""dc2fe3f3-8603-4029-b76e-0d7af7f1b2c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d181a5f5-4efd-4401-838a-732edb5c3d03"",
                    ""path"": ""<XRController>{LeftHand}/touchpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98b70f71-4a3f-464f-a9a8-0e432d272f50"",
                    ""path"": ""<ViveController>{LeftHand}/menu"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Settings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ViveControlUwu
        m_ViveControlUwu = asset.FindActionMap("ViveControlUwu", throwIfNotFound: true);
        m_ViveControlUwu_Movement = m_ViveControlUwu.FindAction("Movement", throwIfNotFound: true);
        m_ViveControlUwu_Settings = m_ViveControlUwu.FindAction("Settings", throwIfNotFound: true);
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

    // ViveControlUwu
    private readonly InputActionMap m_ViveControlUwu;
    private IViveControlUwuActions m_ViveControlUwuActionsCallbackInterface;
    private readonly InputAction m_ViveControlUwu_Movement;
    private readonly InputAction m_ViveControlUwu_Settings;
    public struct ViveControlUwuActions
    {
        private @VivecontrolUwu m_Wrapper;
        public ViveControlUwuActions(@VivecontrolUwu wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_ViveControlUwu_Movement;
        public InputAction @Settings => m_Wrapper.m_ViveControlUwu_Settings;
        public InputActionMap Get() { return m_Wrapper.m_ViveControlUwu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ViveControlUwuActions set) { return set.Get(); }
        public void SetCallbacks(IViveControlUwuActions instance)
        {
            if (m_Wrapper.m_ViveControlUwuActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ViveControlUwuActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ViveControlUwuActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ViveControlUwuActionsCallbackInterface.OnMovement;
                @Settings.started -= m_Wrapper.m_ViveControlUwuActionsCallbackInterface.OnSettings;
                @Settings.performed -= m_Wrapper.m_ViveControlUwuActionsCallbackInterface.OnSettings;
                @Settings.canceled -= m_Wrapper.m_ViveControlUwuActionsCallbackInterface.OnSettings;
            }
            m_Wrapper.m_ViveControlUwuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Settings.started += instance.OnSettings;
                @Settings.performed += instance.OnSettings;
                @Settings.canceled += instance.OnSettings;
            }
        }
    }
    public ViveControlUwuActions @ViveControlUwu => new ViveControlUwuActions(this);
    public interface IViveControlUwuActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSettings(InputAction.CallbackContext context);
    }
}

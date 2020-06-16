// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/BatControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BatControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BatControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BatControls"",
    ""maps"": [
        {
            ""name"": ""BatMap"",
            ""id"": ""e23f9db6-3dc2-40f8-9ff8-f01cb996f062"",
            ""actions"": [
                {
                    ""name"": ""Finger1"",
                    ""type"": ""Value"",
                    ""id"": ""b89d61cb-5ffc-4ef1-99e7-e4475b23f052"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlyLeft"",
                    ""type"": ""Button"",
                    ""id"": ""c9369a50-7583-408b-931b-c7c379a8a694"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlyRight"",
                    ""type"": ""Button"",
                    ""id"": ""bf8c6a68-93cf-43ec-b79c-143cd1a443a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""bd2ad439-46e0-4ed8-b9fc-d9717631cf78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8bd03b6f-edee-4e36-90f7-1ce2769b9c07"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Finger1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19ee82d0-e22c-44f6-831f-a9b38eecb7b6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfb4711a-dc32-4444-98f1-342a3d56a3b8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd16e725-de27-4304-b78a-1fa6935cce64"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1fb5ec9-23f9-409a-9164-da98a34d9ba4"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbc4a5f6-c483-4bfa-a8ec-3ac30646fab1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe89f8f2-69fb-43f0-ad74-647c8d5c2ce6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BatMap
        m_BatMap = asset.FindActionMap("BatMap", throwIfNotFound: true);
        m_BatMap_Finger1 = m_BatMap.FindAction("Finger1", throwIfNotFound: true);
        m_BatMap_FlyLeft = m_BatMap.FindAction("FlyLeft", throwIfNotFound: true);
        m_BatMap_FlyRight = m_BatMap.FindAction("FlyRight", throwIfNotFound: true);
        m_BatMap_Dash = m_BatMap.FindAction("Dash", throwIfNotFound: true);
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

    // BatMap
    private readonly InputActionMap m_BatMap;
    private IBatMapActions m_BatMapActionsCallbackInterface;
    private readonly InputAction m_BatMap_Finger1;
    private readonly InputAction m_BatMap_FlyLeft;
    private readonly InputAction m_BatMap_FlyRight;
    private readonly InputAction m_BatMap_Dash;
    public struct BatMapActions
    {
        private @BatControls m_Wrapper;
        public BatMapActions(@BatControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Finger1 => m_Wrapper.m_BatMap_Finger1;
        public InputAction @FlyLeft => m_Wrapper.m_BatMap_FlyLeft;
        public InputAction @FlyRight => m_Wrapper.m_BatMap_FlyRight;
        public InputAction @Dash => m_Wrapper.m_BatMap_Dash;
        public InputActionMap Get() { return m_Wrapper.m_BatMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BatMapActions set) { return set.Get(); }
        public void SetCallbacks(IBatMapActions instance)
        {
            if (m_Wrapper.m_BatMapActionsCallbackInterface != null)
            {
                @Finger1.started -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFinger1;
                @Finger1.performed -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFinger1;
                @Finger1.canceled -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFinger1;
                @FlyLeft.started -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFlyLeft;
                @FlyLeft.performed -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFlyLeft;
                @FlyLeft.canceled -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFlyLeft;
                @FlyRight.started -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFlyRight;
                @FlyRight.performed -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFlyRight;
                @FlyRight.canceled -= m_Wrapper.m_BatMapActionsCallbackInterface.OnFlyRight;
                @Dash.started -= m_Wrapper.m_BatMapActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_BatMapActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_BatMapActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_BatMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Finger1.started += instance.OnFinger1;
                @Finger1.performed += instance.OnFinger1;
                @Finger1.canceled += instance.OnFinger1;
                @FlyLeft.started += instance.OnFlyLeft;
                @FlyLeft.performed += instance.OnFlyLeft;
                @FlyLeft.canceled += instance.OnFlyLeft;
                @FlyRight.started += instance.OnFlyRight;
                @FlyRight.performed += instance.OnFlyRight;
                @FlyRight.canceled += instance.OnFlyRight;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public BatMapActions @BatMap => new BatMapActions(this);
    public interface IBatMapActions
    {
        void OnFinger1(InputAction.CallbackContext context);
        void OnFlyLeft(InputAction.CallbackContext context);
        void OnFlyRight(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}

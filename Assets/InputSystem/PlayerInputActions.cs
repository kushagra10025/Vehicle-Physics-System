// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""1935b9ef-f071-4055-84af-c636a57a58d3"",
            ""actions"": [
                {
                    ""name"": ""Brake"",
                    ""type"": ""PassThrough"",
                    ""id"": ""171e896c-6254-472c-849d-f99c1de89415"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Thrust"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9a232362-dc1a-45d8-ad83-230b0ed0455c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rudder"",
                    ""type"": ""PassThrough"",
                    ""id"": ""66d45cb3-3e5f-46c9-832b-56dec14a6374"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9e5fcdeb-8962-40ec-8b6b-fc2cd22344d7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87c54189-927a-43bb-98e8-b8573e592e83"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""a0cdd4f8-a542-4f64-a5a0-b20e961a3818"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""98efdeee-18b5-468d-86be-59d10b310095"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7a78fa8c-a172-4c80-a128-07d8a41af28e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftJoystickUD"",
                    ""id"": ""26a66aeb-0aeb-4067-8caa-314444ee17ab"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""49c5a359-63ef-4377-9a3e-86c6465fcf7e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2bd565f6-e8e0-439f-bdac-a41d1b7d03a8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""65793e34-e370-4d0b-8256-f22d8b17842c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rudder"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ecdd4074-9bf6-439f-8f1b-12bcddeb93af"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1b6e6d5e-fbfe-460e-b359-87580b3bd148"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftJoystickLR"",
                    ""id"": ""2a492f25-6d6e-4c79-b655-38600d524853"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rudder"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a21b99be-e9b2-4c21-addb-89218fdd656f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""69c9bd19-f5cb-4965-b54c-c7e6f33ac977"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""DebugActions"",
            ""id"": ""b3249641-cd92-429e-9571-e20aae404dac"",
            ""actions"": [
                {
                    ""name"": ""ResetPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a8e44c22-00bd-4c93-9040-384985c8fea6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""77ee3d75-4dac-4172-bccf-55e9710b2b35"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""ResetPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Brake = m_PlayerControls.FindAction("Brake", throwIfNotFound: true);
        m_PlayerControls_Thrust = m_PlayerControls.FindAction("Thrust", throwIfNotFound: true);
        m_PlayerControls_Rudder = m_PlayerControls.FindAction("Rudder", throwIfNotFound: true);
        // DebugActions
        m_DebugActions = asset.FindActionMap("DebugActions", throwIfNotFound: true);
        m_DebugActions_ResetPosition = m_DebugActions.FindAction("ResetPosition", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Brake;
    private readonly InputAction m_PlayerControls_Thrust;
    private readonly InputAction m_PlayerControls_Rudder;
    public struct PlayerControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Brake => m_Wrapper.m_PlayerControls_Brake;
        public InputAction @Thrust => m_Wrapper.m_PlayerControls_Thrust;
        public InputAction @Rudder => m_Wrapper.m_PlayerControls_Rudder;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Brake.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBrake;
                @Thrust.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnThrust;
                @Thrust.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnThrust;
                @Thrust.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnThrust;
                @Rudder.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRudder;
                @Rudder.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRudder;
                @Rudder.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRudder;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Thrust.started += instance.OnThrust;
                @Thrust.performed += instance.OnThrust;
                @Thrust.canceled += instance.OnThrust;
                @Rudder.started += instance.OnRudder;
                @Rudder.performed += instance.OnRudder;
                @Rudder.canceled += instance.OnRudder;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // DebugActions
    private readonly InputActionMap m_DebugActions;
    private IDebugActionsActions m_DebugActionsActionsCallbackInterface;
    private readonly InputAction m_DebugActions_ResetPosition;
    public struct DebugActionsActions
    {
        private @PlayerInputActions m_Wrapper;
        public DebugActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ResetPosition => m_Wrapper.m_DebugActions_ResetPosition;
        public InputActionMap Get() { return m_Wrapper.m_DebugActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActionsActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActionsActions instance)
        {
            if (m_Wrapper.m_DebugActionsActionsCallbackInterface != null)
            {
                @ResetPosition.started -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnResetPosition;
                @ResetPosition.performed -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnResetPosition;
                @ResetPosition.canceled -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnResetPosition;
            }
            m_Wrapper.m_DebugActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ResetPosition.started += instance.OnResetPosition;
                @ResetPosition.performed += instance.OnResetPosition;
                @ResetPosition.canceled += instance.OnResetPosition;
            }
        }
    }
    public DebugActionsActions @DebugActions => new DebugActionsActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerControlsActions
    {
        void OnBrake(InputAction.CallbackContext context);
        void OnThrust(InputAction.CallbackContext context);
        void OnRudder(InputAction.CallbackContext context);
    }
    public interface IDebugActionsActions
    {
        void OnResetPosition(InputAction.CallbackContext context);
    }
}

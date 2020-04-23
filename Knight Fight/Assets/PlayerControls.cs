// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""f76f5698-4da4-4884-8a97-81e4be31d376"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""0f16c0ee-573c-4e97-af4f-adf35d02cf15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""230f9f2f-03f7-4774-bc77-ce3669454596"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ThrowWep"",
                    ""type"": ""Button"",
                    ""id"": ""f333faed-cc0e-4877-a7da-ef77e264d505"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""53f458f9-940b-459d-857c-a95f67605689"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""34918fc3-0108-435c-8b69-24d2b9ebaa0a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df5c4572-57d1-4e44-9a89-ef698c4935a5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11dac243-63c3-4d15-8d20-113875faa6bc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowWep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6f9825a-b45e-400d-8e80-982354b548c9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuInput"",
            ""id"": ""796bcb0d-6305-44dd-a961-77f8f1684b01"",
            ""actions"": [
                {
                    ""name"": ""Join"",
                    ""type"": ""Button"",
                    ""id"": ""27949091-c09b-4a61-ad7e-1cdc3cbe9d7d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Leave"",
                    ""type"": ""Button"",
                    ""id"": ""2d07fe4d-0c9f-4155-a989-05aef151110d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToMenu"",
                    ""type"": ""Button"",
                    ""id"": ""b79cf0bb-555c-4463-8311-e6b56c900a37"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6c66f8bf-e1ff-482c-92dd-3f70c6e3bf0f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f6c6e9a-ed26-4113-ae87-9c46054769f0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Leave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""576f4b50-ec12-44b4-9793-40706481ca45"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_ThrowWep = m_Gameplay.FindAction("ThrowWep", throwIfNotFound: true);
        m_Gameplay_Attack = m_Gameplay.FindAction("Attack", throwIfNotFound: true);
        // MenuInput
        m_MenuInput = asset.FindActionMap("MenuInput", throwIfNotFound: true);
        m_MenuInput_Join = m_MenuInput.FindAction("Join", throwIfNotFound: true);
        m_MenuInput_Leave = m_MenuInput.FindAction("Leave", throwIfNotFound: true);
        m_MenuInput_ToMenu = m_MenuInput.FindAction("ToMenu", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_ThrowWep;
    private readonly InputAction m_Gameplay_Attack;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @ThrowWep => m_Wrapper.m_Gameplay_ThrowWep;
        public InputAction @Attack => m_Wrapper.m_Gameplay_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @ThrowWep.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrowWep;
                @ThrowWep.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrowWep;
                @ThrowWep.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrowWep;
                @Attack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @ThrowWep.started += instance.OnThrowWep;
                @ThrowWep.performed += instance.OnThrowWep;
                @ThrowWep.canceled += instance.OnThrowWep;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // MenuInput
    private readonly InputActionMap m_MenuInput;
    private IMenuInputActions m_MenuInputActionsCallbackInterface;
    private readonly InputAction m_MenuInput_Join;
    private readonly InputAction m_MenuInput_Leave;
    private readonly InputAction m_MenuInput_ToMenu;
    public struct MenuInputActions
    {
        private @PlayerControls m_Wrapper;
        public MenuInputActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Join => m_Wrapper.m_MenuInput_Join;
        public InputAction @Leave => m_Wrapper.m_MenuInput_Leave;
        public InputAction @ToMenu => m_Wrapper.m_MenuInput_ToMenu;
        public InputActionMap Get() { return m_Wrapper.m_MenuInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuInputActions set) { return set.Get(); }
        public void SetCallbacks(IMenuInputActions instance)
        {
            if (m_Wrapper.m_MenuInputActionsCallbackInterface != null)
            {
                @Join.started -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnJoin;
                @Join.performed -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnJoin;
                @Join.canceled -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnJoin;
                @Leave.started -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnLeave;
                @Leave.performed -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnLeave;
                @Leave.canceled -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnLeave;
                @ToMenu.started -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnToMenu;
                @ToMenu.performed -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnToMenu;
                @ToMenu.canceled -= m_Wrapper.m_MenuInputActionsCallbackInterface.OnToMenu;
            }
            m_Wrapper.m_MenuInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Join.started += instance.OnJoin;
                @Join.performed += instance.OnJoin;
                @Join.canceled += instance.OnJoin;
                @Leave.started += instance.OnLeave;
                @Leave.performed += instance.OnLeave;
                @Leave.canceled += instance.OnLeave;
                @ToMenu.started += instance.OnToMenu;
                @ToMenu.performed += instance.OnToMenu;
                @ToMenu.canceled += instance.OnToMenu;
            }
        }
    }
    public MenuInputActions @MenuInput => new MenuInputActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnThrowWep(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IMenuInputActions
    {
        void OnJoin(InputAction.CallbackContext context);
        void OnLeave(InputAction.CallbackContext context);
        void OnToMenu(InputAction.CallbackContext context);
    }
}

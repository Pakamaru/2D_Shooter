// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerControls.inputactions'

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
            ""name"": ""Level"",
            ""id"": ""3c3915f3-563b-45f9-8c3c-8ed3675f0933"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""de143ead-02c9-465d-9ede-460bad5d5d32"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""2bb06e42-3dba-42cb-8ed6-df62e964cb3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation X"",
                    ""type"": ""Value"",
                    ""id"": ""ec46adfc-c387-41c8-9141-65f20a9bdc9a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation Y"",
                    ""type"": ""Value"",
                    ""id"": ""5c015259-3f37-47d9-9294-dd7a542d127b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2f70c5c3-7e8c-49d6-a048-22130a3ef82f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f1ebab01-80a2-41a5-a4fb-ba8bfd9261af"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""dba20d45-45fa-4351-8b6b-cea67031d260"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e6ceb726-e4a0-4b70-a372-edd1bcdf922d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""93970a1c-c65f-45b4-83de-e5a48725daa7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a408f666-4740-40db-b6bf-32c1320c7bc3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fd9b949a-e837-4e71-bfc0-3a1875bfd684"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""9b158c70-38ee-417e-898f-25d630fd5788"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""07fe4eca-53fe-4baa-b708-1316018a334d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""220e3260-3ab2-4196-91cf-0445fa653b47"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""233573c7-43fd-4784-811b-a8b7b479f77a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2afe22b4-0ec4-46c6-9174-b8d642971116"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b190cabe-6839-4692-8448-a662132e6ca1"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecbc3815-503a-4a8f-a706-16d42f5091a1"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41459a40-3b10-4817-af23-3a87bd69a77a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""2466f5e7-a13a-4b92-8191-bf24ab8d8592"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": []
}");
        // Level
        m_Level = asset.FindActionMap("Level", throwIfNotFound: true);
        m_Level_Move = m_Level.FindAction("Move", throwIfNotFound: true);
        m_Level_Shoot = m_Level.FindAction("Shoot", throwIfNotFound: true);
        m_Level_RotationX = m_Level.FindAction("Rotation X", throwIfNotFound: true);
        m_Level_RotationY = m_Level.FindAction("Rotation Y", throwIfNotFound: true);
        m_Level_Pause = m_Level.FindAction("Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
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

    // Level
    private readonly InputActionMap m_Level;
    private ILevelActions m_LevelActionsCallbackInterface;
    private readonly InputAction m_Level_Move;
    private readonly InputAction m_Level_Shoot;
    private readonly InputAction m_Level_RotationX;
    private readonly InputAction m_Level_RotationY;
    private readonly InputAction m_Level_Pause;
    public struct LevelActions
    {
        private @PlayerControls m_Wrapper;
        public LevelActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Level_Move;
        public InputAction @Shoot => m_Wrapper.m_Level_Shoot;
        public InputAction @RotationX => m_Wrapper.m_Level_RotationX;
        public InputAction @RotationY => m_Wrapper.m_Level_RotationY;
        public InputAction @Pause => m_Wrapper.m_Level_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Level; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LevelActions set) { return set.Get(); }
        public void SetCallbacks(ILevelActions instance)
        {
            if (m_Wrapper.m_LevelActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnMove;
                @Shoot.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnShoot;
                @RotationX.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationX;
                @RotationX.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationX;
                @RotationX.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationX;
                @RotationY.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationY;
                @RotationY.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationY;
                @RotationY.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationY;
                @Pause.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_LevelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @RotationX.started += instance.OnRotationX;
                @RotationX.performed += instance.OnRotationX;
                @RotationX.canceled += instance.OnRotationX;
                @RotationY.started += instance.OnRotationY;
                @RotationY.performed += instance.OnRotationY;
                @RotationY.canceled += instance.OnRotationY;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public LevelActions @Level => new LevelActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface ILevelActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnRotationX(InputAction.CallbackContext context);
        void OnRotationY(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
    }
}

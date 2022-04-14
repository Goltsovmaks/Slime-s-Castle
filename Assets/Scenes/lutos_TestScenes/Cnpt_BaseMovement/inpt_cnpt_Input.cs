// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/lutos_TestScenes/Cnpt_BaseMovement/inpt_cnpt_Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inpt_cnpt_Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inpt_cnpt_Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""inpt_cnpt_Input"",
    ""maps"": [
        {
            ""name"": ""Slime"",
            ""id"": ""3991cbad-1a83-4b5f-b327-40be0ff80e47"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""f7e3b5ac-4f77-4a9a-917c-2284cef2d13b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""11163f91-d9ae-48b2-9cfb-1536f8de3acb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextForm_Slime"",
                    ""type"": ""Button"",
                    ""id"": ""d7212b87-b796-47ed-a7c9-8601e0e5f835"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextForm_Spider"",
                    ""type"": ""Button"",
                    ""id"": ""6818c4b7-b856-4801-9213-bcbc4878c318"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextForm_Firefly"",
                    ""type"": ""Button"",
                    ""id"": ""b18bc9f6-4d7d-4c39-9c3a-16be0fba0ac4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HoldSkill"",
                    ""type"": ""Button"",
                    ""id"": ""ca9451b5-0cec-469d-87f0-6b0d5b987531"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1)""
                },
                {
                    ""name"": ""Skill_1"",
                    ""type"": ""Button"",
                    ""id"": ""dd3d2d59-6034-4ba7-b12f-9bdf41cbaa3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill_2"",
                    ""type"": ""Button"",
                    ""id"": ""6a4c3d4b-4580-4aba-b91e-c38dbeb97c70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""e522c592-0d10-4b8a-a820-62a27f3c3c15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a58f2d9c-9d34-4852-b21a-eec80dcba01f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92a38c9d-dbd8-4782-9323-dfb4a0574785"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88941862-b002-469e-8948-7ae480ab5be6"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""NextForm_Slime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3188596-09ce-4e13-8d6b-9576bb62aa52"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""NextForm_Spider"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc5534ef-61fb-41e7-abd2-49cd72cf99cb"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""NextForm_Firefly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2c0befc-f608-43e2-b6c7-951f3ba7c0e0"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""HoldSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a5686efb-62f2-4c46-940a-53bb54742157"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""411b8634-dd75-421a-9c62-e403f76c348d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b1920803-fe87-4ae4-97e9-9212ec522e8d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""281ce590-a1a8-43d1-8007-1c8569dcdb6a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0d9f826c-a013-4180-8b8c-d62eec83aef6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cbbdebbd-9577-4640-9231-843a26ec43e4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Skill_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec642101-24ef-40e4-b197-8752970fba56"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Skill_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b20d222-03c7-4981-9a03-08226284d263"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""4c07d217-72a2-4ba6-a93e-629b6fc8f3ea"",
            ""actions"": [
                {
                    ""name"": ""ReturnToPreviousMenu"",
                    ""type"": ""Button"",
                    ""id"": ""f24a44c9-bea1-4fe1-9c8d-73722b973db0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d744ee80-af8a-4e6e-b08d-da7efad88e9f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturnToPreviousMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard+Mouse"",
            ""bindingGroup"": ""KeyBoard+Mouse"",
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
        }
    ]
}");
        // Slime
        m_Slime = asset.FindActionMap("Slime", throwIfNotFound: true);
        m_Slime_Movement = m_Slime.FindAction("Movement", throwIfNotFound: true);
        m_Slime_Jump = m_Slime.FindAction("Jump", throwIfNotFound: true);
        m_Slime_NextForm_Slime = m_Slime.FindAction("NextForm_Slime", throwIfNotFound: true);
        m_Slime_NextForm_Spider = m_Slime.FindAction("NextForm_Spider", throwIfNotFound: true);
        m_Slime_NextForm_Firefly = m_Slime.FindAction("NextForm_Firefly", throwIfNotFound: true);
        m_Slime_HoldSkill = m_Slime.FindAction("HoldSkill", throwIfNotFound: true);
        m_Slime_Skill_1 = m_Slime.FindAction("Skill_1", throwIfNotFound: true);
        m_Slime_Skill_2 = m_Slime.FindAction("Skill_2", throwIfNotFound: true);
        m_Slime_Interaction = m_Slime.FindAction("Interaction", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_ReturnToPreviousMenu = m_UI.FindAction("ReturnToPreviousMenu", throwIfNotFound: true);
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

    // Slime
    private readonly InputActionMap m_Slime;
    private ISlimeActions m_SlimeActionsCallbackInterface;
    private readonly InputAction m_Slime_Movement;
    private readonly InputAction m_Slime_Jump;
    private readonly InputAction m_Slime_NextForm_Slime;
    private readonly InputAction m_Slime_NextForm_Spider;
    private readonly InputAction m_Slime_NextForm_Firefly;
    private readonly InputAction m_Slime_HoldSkill;
    private readonly InputAction m_Slime_Skill_1;
    private readonly InputAction m_Slime_Skill_2;
    private readonly InputAction m_Slime_Interaction;
    public struct SlimeActions
    {
        private @Inpt_cnpt_Input m_Wrapper;
        public SlimeActions(@Inpt_cnpt_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Slime_Movement;
        public InputAction @Jump => m_Wrapper.m_Slime_Jump;
        public InputAction @NextForm_Slime => m_Wrapper.m_Slime_NextForm_Slime;
        public InputAction @NextForm_Spider => m_Wrapper.m_Slime_NextForm_Spider;
        public InputAction @NextForm_Firefly => m_Wrapper.m_Slime_NextForm_Firefly;
        public InputAction @HoldSkill => m_Wrapper.m_Slime_HoldSkill;
        public InputAction @Skill_1 => m_Wrapper.m_Slime_Skill_1;
        public InputAction @Skill_2 => m_Wrapper.m_Slime_Skill_2;
        public InputAction @Interaction => m_Wrapper.m_Slime_Interaction;
        public InputActionMap Get() { return m_Wrapper.m_Slime; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SlimeActions set) { return set.Get(); }
        public void SetCallbacks(ISlimeActions instance)
        {
            if (m_Wrapper.m_SlimeActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnJump;
                @NextForm_Slime.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Slime;
                @NextForm_Slime.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Slime;
                @NextForm_Slime.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Slime;
                @NextForm_Spider.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Spider;
                @NextForm_Spider.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Spider;
                @NextForm_Spider.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Spider;
                @NextForm_Firefly.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Firefly;
                @NextForm_Firefly.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Firefly;
                @NextForm_Firefly.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnNextForm_Firefly;
                @HoldSkill.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnHoldSkill;
                @HoldSkill.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnHoldSkill;
                @HoldSkill.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnHoldSkill;
                @Skill_1.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_1;
                @Skill_1.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_1;
                @Skill_1.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_1;
                @Skill_2.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_2;
                @Skill_2.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_2;
                @Skill_2.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_2;
                @Interaction.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnInteraction;
            }
            m_Wrapper.m_SlimeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @NextForm_Slime.started += instance.OnNextForm_Slime;
                @NextForm_Slime.performed += instance.OnNextForm_Slime;
                @NextForm_Slime.canceled += instance.OnNextForm_Slime;
                @NextForm_Spider.started += instance.OnNextForm_Spider;
                @NextForm_Spider.performed += instance.OnNextForm_Spider;
                @NextForm_Spider.canceled += instance.OnNextForm_Spider;
                @NextForm_Firefly.started += instance.OnNextForm_Firefly;
                @NextForm_Firefly.performed += instance.OnNextForm_Firefly;
                @NextForm_Firefly.canceled += instance.OnNextForm_Firefly;
                @HoldSkill.started += instance.OnHoldSkill;
                @HoldSkill.performed += instance.OnHoldSkill;
                @HoldSkill.canceled += instance.OnHoldSkill;
                @Skill_1.started += instance.OnSkill_1;
                @Skill_1.performed += instance.OnSkill_1;
                @Skill_1.canceled += instance.OnSkill_1;
                @Skill_2.started += instance.OnSkill_2;
                @Skill_2.performed += instance.OnSkill_2;
                @Skill_2.canceled += instance.OnSkill_2;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
            }
        }
    }
    public SlimeActions @Slime => new SlimeActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_ReturnToPreviousMenu;
    public struct UIActions
    {
        private @Inpt_cnpt_Input m_Wrapper;
        public UIActions(@Inpt_cnpt_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReturnToPreviousMenu => m_Wrapper.m_UI_ReturnToPreviousMenu;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @ReturnToPreviousMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnReturnToPreviousMenu;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ReturnToPreviousMenu.started += instance.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.performed += instance.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.canceled += instance.OnReturnToPreviousMenu;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyBoardMouseSchemeIndex = -1;
    public InputControlScheme KeyBoardMouseScheme
    {
        get
        {
            if (m_KeyBoardMouseSchemeIndex == -1) m_KeyBoardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyBoard+Mouse");
            return asset.controlSchemes[m_KeyBoardMouseSchemeIndex];
        }
    }
    public interface ISlimeActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnNextForm_Slime(InputAction.CallbackContext context);
        void OnNextForm_Spider(InputAction.CallbackContext context);
        void OnNextForm_Firefly(InputAction.CallbackContext context);
        void OnHoldSkill(InputAction.CallbackContext context);
        void OnSkill_1(InputAction.CallbackContext context);
        void OnSkill_2(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnReturnToPreviousMenu(InputAction.CallbackContext context);
    }
}

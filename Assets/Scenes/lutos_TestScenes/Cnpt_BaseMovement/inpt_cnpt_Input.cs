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
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""Value"",
                    ""id"": ""a76f9d67-93f7-43be-bd7c-babcb43a8dae"",
                    ""expectedControlType"": """",
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
                    ""name"": ""Skill_1_hold"",
                    ""type"": ""Button"",
                    ""id"": ""ca9451b5-0cec-469d-87f0-6b0d5b987531"",
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
                    ""name"": ""wAsD"",
                    ""id"": ""48ce1692-1af6-4dcd-a4f8-3a17ecd1cc1b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d32fc351-fa64-4b15-959d-6d19e83fba18"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1cbb0c7f-e078-4b2d-befc-a581bb914978"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""67341fa5-a58d-45e7-a528-fea13c15988a"",
                    ""path"": ""1DAxis(minValue=-100,maxValue=100)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9a66923a-3cc9-457a-b24f-fdf6e91add48"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bc4daf23-4274-4811-a4c4-430ebd0cd698"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""action"": ""Skill_1_hold"",
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
        m_Slime_HorizontalMovement = m_Slime.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_Slime_Jump = m_Slime.FindAction("Jump", throwIfNotFound: true);
        m_Slime_NextForm_Slime = m_Slime.FindAction("NextForm_Slime", throwIfNotFound: true);
        m_Slime_NextForm_Spider = m_Slime.FindAction("NextForm_Spider", throwIfNotFound: true);
        m_Slime_NextForm_Firefly = m_Slime.FindAction("NextForm_Firefly", throwIfNotFound: true);
        m_Slime_Skill_1_hold = m_Slime.FindAction("Skill_1_hold", throwIfNotFound: true);
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
    private readonly InputAction m_Slime_HorizontalMovement;
    private readonly InputAction m_Slime_Jump;
    private readonly InputAction m_Slime_NextForm_Slime;
    private readonly InputAction m_Slime_NextForm_Spider;
    private readonly InputAction m_Slime_NextForm_Firefly;
    private readonly InputAction m_Slime_Skill_1_hold;
    public struct SlimeActions
    {
        private @Inpt_cnpt_Input m_Wrapper;
        public SlimeActions(@Inpt_cnpt_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_Slime_HorizontalMovement;
        public InputAction @Jump => m_Wrapper.m_Slime_Jump;
        public InputAction @NextForm_Slime => m_Wrapper.m_Slime_NextForm_Slime;
        public InputAction @NextForm_Spider => m_Wrapper.m_Slime_NextForm_Spider;
        public InputAction @NextForm_Firefly => m_Wrapper.m_Slime_NextForm_Firefly;
        public InputAction @Skill_1_hold => m_Wrapper.m_Slime_Skill_1_hold;
        public InputActionMap Get() { return m_Wrapper.m_Slime; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SlimeActions set) { return set.Get(); }
        public void SetCallbacks(ISlimeActions instance)
        {
            if (m_Wrapper.m_SlimeActionsCallbackInterface != null)
            {
                @HorizontalMovement.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnHorizontalMovement;
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
                @Skill_1_hold.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_1_hold;
                @Skill_1_hold.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_1_hold;
                @Skill_1_hold.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnSkill_1_hold;
            }
            m_Wrapper.m_SlimeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMovement.started += instance.OnHorizontalMovement;
                @HorizontalMovement.performed += instance.OnHorizontalMovement;
                @HorizontalMovement.canceled += instance.OnHorizontalMovement;
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
                @Skill_1_hold.started += instance.OnSkill_1_hold;
                @Skill_1_hold.performed += instance.OnSkill_1_hold;
                @Skill_1_hold.canceled += instance.OnSkill_1_hold;
            }
        }
    }
    public SlimeActions @Slime => new SlimeActions(this);
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
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnNextForm_Slime(InputAction.CallbackContext context);
        void OnNextForm_Spider(InputAction.CallbackContext context);
        void OnNextForm_Firefly(InputAction.CallbackContext context);
        void OnSkill_1_hold(InputAction.CallbackContext context);
    }
}

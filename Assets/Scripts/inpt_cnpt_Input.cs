// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/inpt_cnpt_Input.inputactions'

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
                    ""name"": ""ReturnToPreviousMenu"",
                    ""type"": ""Button"",
                    ""id"": ""e379d397-c301-4e73-a6fe-7a03aa852f4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""30380270-6cbf-4380-8914-197fdb20c2fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
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
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""NextForm_Spider"",
                    ""type"": ""Button"",
                    ""id"": ""6818c4b7-b856-4801-9213-bcbc4878c318"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""NextForm_Firefly"",
                    ""type"": ""Button"",
                    ""id"": ""b18bc9f6-4d7d-4c39-9c3a-16be0fba0ac4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
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
                },
                {
                    ""name"": ""ChooseForm"",
                    ""type"": ""Button"",
                    ""id"": ""2ff3ba77-baa4-439d-808e-c35f5cf4e377"",
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
                    ""name"": """",
                    ""id"": ""cbbdebbd-9577-4640-9231-843a26ec43e4"",
                    ""path"": ""<Keyboard>/r"",
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
                    ""path"": ""<Keyboard>/t"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""6d16d6b1-dbbd-42b9-9e71-9751c22319af"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Pause"",
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
                    ""path"": ""<Keyboard>/w"",
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
                    ""path"": ""<Keyboard>/s"",
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
                    ""path"": ""<Keyboard>/a"",
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
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""97e7e737-3d7e-4bc3-a45f-9c1368c820bd"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""ReturnToPreviousMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""900e5df8-8b3f-4ea0-9bf7-947aad219fda"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""ChooseForm"",
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
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f24a44c9-bea1-4fe1-9c8d-73722b973db0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReturnToPreviousMenu"",
                    ""type"": ""Button"",
                    ""id"": ""02f879b6-f597-4bf9-bf5a-cf63df971276"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnButtonPressedTest"",
                    ""type"": ""Button"",
                    ""id"": ""01d8c797-93ac-42f9-a1ab-a19856136c08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ContinueDialogue"",
                    ""type"": ""Button"",
                    ""id"": ""34b36fb1-e4ba-4c7a-87cb-4cc1a8e38fe1"",
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
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""827a1a30-4393-426c-8d91-9dc6283c201f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""ReturnToPreviousMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19a69ee3-f132-4a00-a9d1-f70d4c717500"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""OnButtonPressedTest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f27361e8-42fd-499a-b565-796fce45486f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""ContinueDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI1"",
            ""id"": ""c08ff974-369c-4b39-9069-3dd08bbb37f8"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""42c3adcf-1107-4c05-9e3e-1c5be1bc7483"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""37387694-11b8-4bdc-8108-51ff00c98235"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""e6357bd5-0729-41fd-91c2-1ffcf0b191e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25381e97-bc0e-4d6d-b5bd-54003d78f683"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f335b381-c981-4707-8807-92b387e09645"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""94cab775-3fd7-4118-9007-77d32888524b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5e35298b-5711-4f64-925a-0de9b81d5174"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""045b582c-81a7-4d74-9166-545b59366d90"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d4328407-b86d-4322-94ce-bde87cb732cb"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""11bff000-9e51-409c-a895-7002906375cc"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""cfc3463d-a3a8-4dfe-8f74-d327adedecdb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""16f9c174-3c9b-4d73-adfc-5ebb81a1f446"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a692086b-b9d3-431c-97d9-58ddcaebec9b"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4d255fd1-dfc5-4aa7-9520-c369f9a43cd3"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0ad6e1a3-7623-448f-b7f5-a38e7afc03fd"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d4e9878b-f778-4bd9-9e77-8185e9be71ff"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b84ad5e3-1efa-4438-9352-acf2a6cb19dc"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""22308076-611e-41f6-a809-5dcca86187aa"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""38964bbe-95ff-4c55-9249-5faca267b337"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""87fcf4dd-f03d-4bb5-95de-fbf3f977e38a"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""5de07985-f867-4e7d-867e-25497deff053"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe2479e2-cb4f-4ff0-98f3-142c909a8cb9"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""421f3c66-97c2-42a3-9d27-4bd7d4a86118"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ca6aad38-57d0-4211-81b5-cae21791a36d"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4927bc24-62dd-4f37-b6e4-6b2b6a2a8691"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""38ce013b-7141-4087-8588-1c91258fd103"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""89dde47b-7220-4855-b422-d773740d4ba9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""28166c33-2dc6-46b6-8360-98374b91e0bd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""359cf3e2-8c30-416d-bdc8-aa4fadfedd31"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6249e968-bbe3-41b2-97fc-26df19986cdb"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d88e45d8-bf0d-46ab-a2ca-46a1e8eb648f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1c07a937-f482-4bd5-a594-a4e348bddc95"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f9dc87a5-10f2-40ea-89f0-8020b5a3473e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c8487510-5087-4a4b-8eee-b61284adec19"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""27e1cb1b-f8fb-40ef-af89-302c7d29cdbc"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c438c1f0-990f-4476-8095-e7789e5a42a9"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca92806a-29c4-4d01-951f-089d33d3d7ee"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KeyBoard+Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d255307a-cefb-432c-9bf5-932a7e54f463"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c617b4b-81f4-49c1-9495-af7dd2f58c31"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bd68a7c-8b47-477f-a924-f367ff41fb99"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KeyBoard+Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""833d6131-0af3-457f-9f31-3be1194522b9"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d83a148-4325-42fa-9c93-99feea9d8eb2"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82542b56-3882-4d21-bcd2-dbe87cfeeaf8"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0528624-8f9c-43d2-9e18-3f98ecefec8e"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KeyBoard+Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b11192a7-46ec-4a1a-8335-1a618bd047c7"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KeyBoard+Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f057ab26-c7af-42bb-b8b4-72029d63f31a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KeyBoard+Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bc6897c-289b-42d2-b8b0-90fa9cf91e6a"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83e7bc96-8a19-4b31-8926-5b9e920b8e98"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Win"",
            ""id"": ""0d8363b0-63a3-42af-9aaa-9abeb5074f43"",
            ""actions"": [
                {
                    ""name"": ""QuitGame"",
                    ""type"": ""Button"",
                    ""id"": ""8fb5e6f2-ae69-4aac-910c-d1b19bfafac0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2d4f0d34-39fc-43e5-94d1-c6d222744f0e"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard+Mouse"",
                    ""action"": ""QuitGame"",
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
        m_Slime_ReturnToPreviousMenu = m_Slime.FindAction("ReturnToPreviousMenu", throwIfNotFound: true);
        m_Slime_Pause = m_Slime.FindAction("Pause", throwIfNotFound: true);
        m_Slime_Movement = m_Slime.FindAction("Movement", throwIfNotFound: true);
        m_Slime_Jump = m_Slime.FindAction("Jump", throwIfNotFound: true);
        m_Slime_NextForm_Slime = m_Slime.FindAction("NextForm_Slime", throwIfNotFound: true);
        m_Slime_NextForm_Spider = m_Slime.FindAction("NextForm_Spider", throwIfNotFound: true);
        m_Slime_NextForm_Firefly = m_Slime.FindAction("NextForm_Firefly", throwIfNotFound: true);
        m_Slime_HoldSkill = m_Slime.FindAction("HoldSkill", throwIfNotFound: true);
        m_Slime_Skill_1 = m_Slime.FindAction("Skill_1", throwIfNotFound: true);
        m_Slime_Skill_2 = m_Slime.FindAction("Skill_2", throwIfNotFound: true);
        m_Slime_Interaction = m_Slime.FindAction("Interaction", throwIfNotFound: true);
        m_Slime_ChooseForm = m_Slime.FindAction("ChooseForm", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        m_UI_ReturnToPreviousMenu = m_UI.FindAction("ReturnToPreviousMenu", throwIfNotFound: true);
        m_UI_OnButtonPressedTest = m_UI.FindAction("OnButtonPressedTest", throwIfNotFound: true);
        m_UI_ContinueDialogue = m_UI.FindAction("ContinueDialogue", throwIfNotFound: true);
        // UI1
        m_UI1 = asset.FindActionMap("UI1", throwIfNotFound: true);
        m_UI1_Navigate = m_UI1.FindAction("Navigate", throwIfNotFound: true);
        m_UI1_Submit = m_UI1.FindAction("Submit", throwIfNotFound: true);
        m_UI1_Cancel = m_UI1.FindAction("Cancel", throwIfNotFound: true);
        m_UI1_Point = m_UI1.FindAction("Point", throwIfNotFound: true);
        m_UI1_Click = m_UI1.FindAction("Click", throwIfNotFound: true);
        m_UI1_ScrollWheel = m_UI1.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI1_MiddleClick = m_UI1.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI1_RightClick = m_UI1.FindAction("RightClick", throwIfNotFound: true);
        m_UI1_TrackedDevicePosition = m_UI1.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI1_TrackedDeviceOrientation = m_UI1.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        // Win
        m_Win = asset.FindActionMap("Win", throwIfNotFound: true);
        m_Win_QuitGame = m_Win.FindAction("QuitGame", throwIfNotFound: true);
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
    private readonly InputAction m_Slime_ReturnToPreviousMenu;
    private readonly InputAction m_Slime_Pause;
    private readonly InputAction m_Slime_Movement;
    private readonly InputAction m_Slime_Jump;
    private readonly InputAction m_Slime_NextForm_Slime;
    private readonly InputAction m_Slime_NextForm_Spider;
    private readonly InputAction m_Slime_NextForm_Firefly;
    private readonly InputAction m_Slime_HoldSkill;
    private readonly InputAction m_Slime_Skill_1;
    private readonly InputAction m_Slime_Skill_2;
    private readonly InputAction m_Slime_Interaction;
    private readonly InputAction m_Slime_ChooseForm;
    public struct SlimeActions
    {
        private @Inpt_cnpt_Input m_Wrapper;
        public SlimeActions(@Inpt_cnpt_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReturnToPreviousMenu => m_Wrapper.m_Slime_ReturnToPreviousMenu;
        public InputAction @Pause => m_Wrapper.m_Slime_Pause;
        public InputAction @Movement => m_Wrapper.m_Slime_Movement;
        public InputAction @Jump => m_Wrapper.m_Slime_Jump;
        public InputAction @NextForm_Slime => m_Wrapper.m_Slime_NextForm_Slime;
        public InputAction @NextForm_Spider => m_Wrapper.m_Slime_NextForm_Spider;
        public InputAction @NextForm_Firefly => m_Wrapper.m_Slime_NextForm_Firefly;
        public InputAction @HoldSkill => m_Wrapper.m_Slime_HoldSkill;
        public InputAction @Skill_1 => m_Wrapper.m_Slime_Skill_1;
        public InputAction @Skill_2 => m_Wrapper.m_Slime_Skill_2;
        public InputAction @Interaction => m_Wrapper.m_Slime_Interaction;
        public InputAction @ChooseForm => m_Wrapper.m_Slime_ChooseForm;
        public InputActionMap Get() { return m_Wrapper.m_Slime; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SlimeActions set) { return set.Get(); }
        public void SetCallbacks(ISlimeActions instance)
        {
            if (m_Wrapper.m_SlimeActionsCallbackInterface != null)
            {
                @ReturnToPreviousMenu.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnReturnToPreviousMenu;
                @Pause.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnPause;
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
                @ChooseForm.started -= m_Wrapper.m_SlimeActionsCallbackInterface.OnChooseForm;
                @ChooseForm.performed -= m_Wrapper.m_SlimeActionsCallbackInterface.OnChooseForm;
                @ChooseForm.canceled -= m_Wrapper.m_SlimeActionsCallbackInterface.OnChooseForm;
            }
            m_Wrapper.m_SlimeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ReturnToPreviousMenu.started += instance.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.performed += instance.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.canceled += instance.OnReturnToPreviousMenu;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
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
                @ChooseForm.started += instance.OnChooseForm;
                @ChooseForm.performed += instance.OnChooseForm;
                @ChooseForm.canceled += instance.OnChooseForm;
            }
        }
    }
    public SlimeActions @Slime => new SlimeActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Pause;
    private readonly InputAction m_UI_ReturnToPreviousMenu;
    private readonly InputAction m_UI_OnButtonPressedTest;
    private readonly InputAction m_UI_ContinueDialogue;
    public struct UIActions
    {
        private @Inpt_cnpt_Input m_Wrapper;
        public UIActions(@Inpt_cnpt_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputAction @ReturnToPreviousMenu => m_Wrapper.m_UI_ReturnToPreviousMenu;
        public InputAction @OnButtonPressedTest => m_Wrapper.m_UI_OnButtonPressedTest;
        public InputAction @ContinueDialogue => m_Wrapper.m_UI_ContinueDialogue;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @ReturnToPreviousMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnReturnToPreviousMenu;
                @OnButtonPressedTest.started -= m_Wrapper.m_UIActionsCallbackInterface.OnOnButtonPressedTest;
                @OnButtonPressedTest.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnOnButtonPressedTest;
                @OnButtonPressedTest.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnOnButtonPressedTest;
                @ContinueDialogue.started -= m_Wrapper.m_UIActionsCallbackInterface.OnContinueDialogue;
                @ContinueDialogue.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnContinueDialogue;
                @ContinueDialogue.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnContinueDialogue;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @ReturnToPreviousMenu.started += instance.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.performed += instance.OnReturnToPreviousMenu;
                @ReturnToPreviousMenu.canceled += instance.OnReturnToPreviousMenu;
                @OnButtonPressedTest.started += instance.OnOnButtonPressedTest;
                @OnButtonPressedTest.performed += instance.OnOnButtonPressedTest;
                @OnButtonPressedTest.canceled += instance.OnOnButtonPressedTest;
                @ContinueDialogue.started += instance.OnContinueDialogue;
                @ContinueDialogue.performed += instance.OnContinueDialogue;
                @ContinueDialogue.canceled += instance.OnContinueDialogue;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // UI1
    private readonly InputActionMap m_UI1;
    private IUI1Actions m_UI1ActionsCallbackInterface;
    private readonly InputAction m_UI1_Navigate;
    private readonly InputAction m_UI1_Submit;
    private readonly InputAction m_UI1_Cancel;
    private readonly InputAction m_UI1_Point;
    private readonly InputAction m_UI1_Click;
    private readonly InputAction m_UI1_ScrollWheel;
    private readonly InputAction m_UI1_MiddleClick;
    private readonly InputAction m_UI1_RightClick;
    private readonly InputAction m_UI1_TrackedDevicePosition;
    private readonly InputAction m_UI1_TrackedDeviceOrientation;
    public struct UI1Actions
    {
        private @Inpt_cnpt_Input m_Wrapper;
        public UI1Actions(@Inpt_cnpt_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI1_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI1_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI1_Cancel;
        public InputAction @Point => m_Wrapper.m_UI1_Point;
        public InputAction @Click => m_Wrapper.m_UI1_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI1_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI1_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI1_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI1_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI1_TrackedDeviceOrientation;
        public InputActionMap Get() { return m_Wrapper.m_UI1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UI1Actions set) { return set.Get(); }
        public void SetCallbacks(IUI1Actions instance)
        {
            if (m_Wrapper.m_UI1ActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnRightClick;
                @TrackedDevicePosition.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UI1ActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UI1ActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UI1ActionsCallbackInterface.OnTrackedDeviceOrientation;
            }
            m_Wrapper.m_UI1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
            }
        }
    }
    public UI1Actions @UI1 => new UI1Actions(this);

    // Win
    private readonly InputActionMap m_Win;
    private IWinActions m_WinActionsCallbackInterface;
    private readonly InputAction m_Win_QuitGame;
    public struct WinActions
    {
        private @Inpt_cnpt_Input m_Wrapper;
        public WinActions(@Inpt_cnpt_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @QuitGame => m_Wrapper.m_Win_QuitGame;
        public InputActionMap Get() { return m_Wrapper.m_Win; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WinActions set) { return set.Get(); }
        public void SetCallbacks(IWinActions instance)
        {
            if (m_Wrapper.m_WinActionsCallbackInterface != null)
            {
                @QuitGame.started -= m_Wrapper.m_WinActionsCallbackInterface.OnQuitGame;
                @QuitGame.performed -= m_Wrapper.m_WinActionsCallbackInterface.OnQuitGame;
                @QuitGame.canceled -= m_Wrapper.m_WinActionsCallbackInterface.OnQuitGame;
            }
            m_Wrapper.m_WinActionsCallbackInterface = instance;
            if (instance != null)
            {
                @QuitGame.started += instance.OnQuitGame;
                @QuitGame.performed += instance.OnQuitGame;
                @QuitGame.canceled += instance.OnQuitGame;
            }
        }
    }
    public WinActions @Win => new WinActions(this);
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
        void OnReturnToPreviousMenu(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnNextForm_Slime(InputAction.CallbackContext context);
        void OnNextForm_Spider(InputAction.CallbackContext context);
        void OnNextForm_Firefly(InputAction.CallbackContext context);
        void OnHoldSkill(InputAction.CallbackContext context);
        void OnSkill_1(InputAction.CallbackContext context);
        void OnSkill_2(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnChooseForm(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnReturnToPreviousMenu(InputAction.CallbackContext context);
        void OnOnButtonPressedTest(InputAction.CallbackContext context);
        void OnContinueDialogue(InputAction.CallbackContext context);
    }
    public interface IUI1Actions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
    }
    public interface IWinActions
    {
        void OnQuitGame(InputAction.CallbackContext context);
    }
}

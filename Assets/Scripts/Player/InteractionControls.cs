// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/InteractionControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InteractionControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InteractionControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InteractionControls"",
    ""maps"": [
        {
            ""name"": ""Interaction"",
            ""id"": ""1920ea07-91c3-4292-b3f8-ae4e5ff73ec1"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""a8e1ca65-1fa6-4dd8-933e-70bff4accaca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LMB"",
                    ""type"": ""Button"",
                    ""id"": ""387a7916-b307-4080-9bc0-11e5a546573e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RMB"",
                    ""type"": ""Button"",
                    ""id"": ""04b1b73e-bc6a-42fe-84e9-be0fa3e8a427"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""011e70e8-5862-45e6-96bb-2d7302ede9d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dialog"",
                    ""type"": ""Button"",
                    ""id"": ""204aa7e3-0b51-4a80-9093-60bf9513ce6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""88545ddb-dac6-4bd4-89fe-ea25fdd800b6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ca05f54-c14f-43f0-9eb5-3aaad00926bf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bcfea28-d815-4615-84af-a60fc8e9cf9b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2bf165e-8426-483a-bd75-9e348e8504ef"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98769b3c-550b-4921-a80d-5b35ab3f6722"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
        m_Interaction_LMB = m_Interaction.FindAction("LMB", throwIfNotFound: true);
        m_Interaction_RMB = m_Interaction.FindAction("RMB", throwIfNotFound: true);
        m_Interaction_Inventory = m_Interaction.FindAction("Inventory", throwIfNotFound: true);
        m_Interaction_Dialog = m_Interaction.FindAction("Dialog", throwIfNotFound: true);
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

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_Interact;
    private readonly InputAction m_Interaction_LMB;
    private readonly InputAction m_Interaction_RMB;
    private readonly InputAction m_Interaction_Inventory;
    private readonly InputAction m_Interaction_Dialog;
    public struct InteractionActions
    {
        private @InteractionControls m_Wrapper;
        public InteractionActions(@InteractionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Interaction_Interact;
        public InputAction @LMB => m_Wrapper.m_Interaction_LMB;
        public InputAction @RMB => m_Wrapper.m_Interaction_RMB;
        public InputAction @Inventory => m_Wrapper.m_Interaction_Inventory;
        public InputAction @Dialog => m_Wrapper.m_Interaction_Dialog;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @LMB.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnLMB;
                @LMB.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnLMB;
                @LMB.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnLMB;
                @RMB.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnRMB;
                @RMB.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnRMB;
                @RMB.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnRMB;
                @Inventory.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInventory;
                @Dialog.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnDialog;
                @Dialog.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnDialog;
                @Dialog.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnDialog;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @LMB.started += instance.OnLMB;
                @LMB.performed += instance.OnLMB;
                @LMB.canceled += instance.OnLMB;
                @RMB.started += instance.OnRMB;
                @RMB.performed += instance.OnRMB;
                @RMB.canceled += instance.OnRMB;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Dialog.started += instance.OnDialog;
                @Dialog.performed += instance.OnDialog;
                @Dialog.canceled += instance.OnDialog;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);
    public interface IInteractionActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnLMB(InputAction.CallbackContext context);
        void OnRMB(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnDialog(InputAction.CallbackContext context);
    }
}

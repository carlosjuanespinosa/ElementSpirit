//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputJugador.inputactions
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

public partial class @InputJugador : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputJugador()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputJugador"",
    ""maps"": [
        {
            ""name"": ""Jugador"",
            ""id"": ""b88993b7-707b-4305-a0bc-b3875492c1a7"",
            ""actions"": [
                {
                    ""name"": ""Caminar"",
                    ""type"": ""Value"",
                    ""id"": ""e2745549-1e3d-42c4-a250-8ae4b7708498"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AtaqueDist"",
                    ""type"": ""Button"",
                    ""id"": ""7773dc29-0f05-4b9f-b582-e5bf83c8c17b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AtaqueDistCar"",
                    ""type"": ""Button"",
                    ""id"": ""3bc1416c-3bd2-42e8-9444-9d34a9f0ab2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AtaqueMele"",
                    ""type"": ""Button"",
                    ""id"": ""e56ff7a7-a8e9-4cf7-9496-e8ce889f24d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Defensa"",
                    ""type"": ""Button"",
                    ""id"": ""5725547f-d3d4-4535-94af-90ce4ea696fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8b935a58-db9b-40e3-8518-4addbf5fee3d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c89aded5-d141-41c4-a984-cf343c2cacb7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""07dc560f-7dd2-4828-8219-526e3fd6fc11"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81756890-9e01-407d-b6c4-c4f06c84b665"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""06be8fa4-fa36-4807-9f14-5974fa687d44"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""df4deab7-1985-4117-9eb8-fb35eba94695"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""181964df-ff53-4bac-a922-1c8edd24eccc"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""70edb4a7-8f4f-4fee-afe8-912d7976a935"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""25967eb5-7557-4d6b-b760-46dfe4b86b4f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""06405032-1f2a-4379-a9e5-c0477671bbfe"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Caminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4a75df4f-2c08-40b4-9a2e-f026269df8ee"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueDist"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1020074-b941-4cd8-be5b-d8d2ba7961a0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueDist"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6040e31-c4a7-428a-9f01-b534e97389ac"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold(duration=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueDistCar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be14561d-f544-4650-8bde-2ecc98de8642"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Hold(duration=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueDistCar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7ccbe14-b301-4730-9ffa-16d22ab911cd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueMele"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""647fc15b-ff77-485b-9f72-96df879b33dd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueMele"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51bd2c93-24a8-4753-802c-551b33a3a6dc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defensa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f97fa301-afb1-47c2-be12-2caa76ca92b7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defensa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d823d4d6-5637-469b-b840-ceb1834495d9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defensa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Jugador
        m_Jugador = asset.FindActionMap("Jugador", throwIfNotFound: true);
        m_Jugador_Caminar = m_Jugador.FindAction("Caminar", throwIfNotFound: true);
        m_Jugador_AtaqueDist = m_Jugador.FindAction("AtaqueDist", throwIfNotFound: true);
        m_Jugador_AtaqueDistCar = m_Jugador.FindAction("AtaqueDistCar", throwIfNotFound: true);
        m_Jugador_AtaqueMele = m_Jugador.FindAction("AtaqueMele", throwIfNotFound: true);
        m_Jugador_Defensa = m_Jugador.FindAction("Defensa", throwIfNotFound: true);
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

    // Jugador
    private readonly InputActionMap m_Jugador;
    private IJugadorActions m_JugadorActionsCallbackInterface;
    private readonly InputAction m_Jugador_Caminar;
    private readonly InputAction m_Jugador_AtaqueDist;
    private readonly InputAction m_Jugador_AtaqueDistCar;
    private readonly InputAction m_Jugador_AtaqueMele;
    private readonly InputAction m_Jugador_Defensa;
    public struct JugadorActions
    {
        private @InputJugador m_Wrapper;
        public JugadorActions(@InputJugador wrapper) { m_Wrapper = wrapper; }
        public InputAction @Caminar => m_Wrapper.m_Jugador_Caminar;
        public InputAction @AtaqueDist => m_Wrapper.m_Jugador_AtaqueDist;
        public InputAction @AtaqueDistCar => m_Wrapper.m_Jugador_AtaqueDistCar;
        public InputAction @AtaqueMele => m_Wrapper.m_Jugador_AtaqueMele;
        public InputAction @Defensa => m_Wrapper.m_Jugador_Defensa;
        public InputActionMap Get() { return m_Wrapper.m_Jugador; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JugadorActions set) { return set.Get(); }
        public void SetCallbacks(IJugadorActions instance)
        {
            if (m_Wrapper.m_JugadorActionsCallbackInterface != null)
            {
                @Caminar.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnCaminar;
                @Caminar.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnCaminar;
                @Caminar.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnCaminar;
                @AtaqueDist.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueDist;
                @AtaqueDist.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueDist;
                @AtaqueDist.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueDist;
                @AtaqueDistCar.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueDistCar;
                @AtaqueDistCar.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueDistCar;
                @AtaqueDistCar.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueDistCar;
                @AtaqueMele.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueMele;
                @AtaqueMele.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueMele;
                @AtaqueMele.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtaqueMele;
                @Defensa.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnDefensa;
                @Defensa.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnDefensa;
                @Defensa.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnDefensa;
            }
            m_Wrapper.m_JugadorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Caminar.started += instance.OnCaminar;
                @Caminar.performed += instance.OnCaminar;
                @Caminar.canceled += instance.OnCaminar;
                @AtaqueDist.started += instance.OnAtaqueDist;
                @AtaqueDist.performed += instance.OnAtaqueDist;
                @AtaqueDist.canceled += instance.OnAtaqueDist;
                @AtaqueDistCar.started += instance.OnAtaqueDistCar;
                @AtaqueDistCar.performed += instance.OnAtaqueDistCar;
                @AtaqueDistCar.canceled += instance.OnAtaqueDistCar;
                @AtaqueMele.started += instance.OnAtaqueMele;
                @AtaqueMele.performed += instance.OnAtaqueMele;
                @AtaqueMele.canceled += instance.OnAtaqueMele;
                @Defensa.started += instance.OnDefensa;
                @Defensa.performed += instance.OnDefensa;
                @Defensa.canceled += instance.OnDefensa;
            }
        }
    }
    public JugadorActions @Jugador => new JugadorActions(this);
    public interface IJugadorActions
    {
        void OnCaminar(InputAction.CallbackContext context);
        void OnAtaqueDist(InputAction.CallbackContext context);
        void OnAtaqueDistCar(InputAction.CallbackContext context);
        void OnAtaqueMele(InputAction.CallbackContext context);
        void OnDefensa(InputAction.CallbackContext context);
    }
}

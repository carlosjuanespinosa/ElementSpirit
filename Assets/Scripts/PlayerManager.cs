using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<LayerMask> capasJugador;
    [SerializeField] private List<Transform> posicionSpawn;
    [SerializeField] private List<Material> tipoJugador;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CinemachineVirtualCamera mainVirtualCamera;
    [SerializeField] private CinemachineTargetGroup cinemachineTargetGroup;

    private PlayerInputManager playerInputManager;

    private List<int> indiceJugadores;

    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        indiceJugadores = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Rejoin();
        }
    }
    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
        playerInputManager.onPlayerLeft += RemovePlayer;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
        playerInputManager.onPlayerLeft -= RemovePlayer;
    }

    private bool PlayerExists(PlayerInput player)
    {
        return indiceJugadores.Contains(player.playerIndex);
    }

    private void AddPlayer(PlayerInput playerInput)
    {
        Transform playerParentObject = playerInput.transform.parent;

        if (!PlayerExists(playerInput))
        {
            playerParentObject.position = posicionSpawn[playerInput.playerIndex].position;
        }

        CinemachineVirtualCamera virtualPlayerCamera = playerParentObject.GetComponentInChildren<CinemachineVirtualCamera>();
        Camera playerCamera = playerParentObject.GetComponentInChildren<Camera>();
        if (playerInputManager.splitScreen)
        {
            mainCamera.gameObject.SetActive(false);
            mainVirtualCamera.gameObject.SetActive(false);

            int layerToSet = (int)Mathf.Log(capasJugador[playerInput.playerIndex], 2);
        }
    }

    private void RemovePlayer(PlayerInput playerInput)
    {

    }

    private void Rejoin()
    {
        playerInputManager.splitScreen = !playerInputManager.splitScreen;
        PlayerInput[] players = FindObjectsOfType <PlayerInput>();
        
        foreach (PlayerInput player in players)
        {
            AddPlayer(player);
        }
    }
}

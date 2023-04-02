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

    private float WEIGHT = 8;
    private float RADIUS = 4;

    


    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        indiceJugadores = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
       
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
         Debug.Log("add player debug");
        //Transform playerParentObject = playerInput.transform.parent;
       
        if (!PlayerExists(playerInput))
        {
           playerInput.transform.position = posicionSpawn[playerInput.playerIndex].position;
           //LAYERS JUGADORES
            int layerPlayer = (int)Mathf.Log(capasJugador[playerInput.playerIndex], 2);
            playerInput.gameObject.layer= layerPlayer;

            if (playerInput.TryGetComponent(out ColorSelector colorSelector))
            {
                colorSelector.ChangeMainMaterial(tipoJugador[playerInput.playerIndex]);
            }

                if (playerInput.gameObject.TryGetComponent(out Jugador jugador))
                {
                    foreach (ParticleSystem particle in jugador.particle)
                    {
                        particle.gameObject.layer = layerPlayer;


                    }
                }
            

           

            //for(int i=0; i<=7; i++)
            //{
            //    playerInput.transform.GetChild(i).gameObject.layer = layerPlayer;
                
            //    if (layerPlayer == capasJugador[0])
            //    {
                    

            //        // ParticleSystemGameObjectFilter.LayerMask pa =   playerInput.transform.GetChild(i).gameObject.GetComponent<ParticleSystemGameObjectFilter.LayerMask>();
            //        // pa = capasJugador[1];
            //    }

            //    if (layerPlayer == capasJugador[1])
            //    {
            //        //playerInput.transform.GetChild(i).gameObject.


            //    }


            //    //playerInput.transform.GetChild(i).GetComponent<ParticleSystemGameObjectFilter> != layerPlayer;
            //}
            


        }
        // ADD TARGET GROUP
        cinemachineTargetGroup.AddMember(playerInput.transform, WEIGHT, RADIUS);
        

        /*CinemachineVirtualCamera virtualPlayerCamera = playerInput.GetComponentInChildren<CinemachineVirtualCamera>();
         Camera playerCamera = playerInput.GetComponentInChildren<Camera>();
        if (playerInputManager.splitScreen)
         {
             mainCamera.gameObject.SetActive(false);
             mainVirtualCamera.gameObject.SetActive(false);

             int layerToSet = (int)Mathf.Log(capasJugador[playerInput.playerIndex], 2);

             virtualPlayerCamera.enabled = true;
             playerCamera.enabled = true;

             virtualPlayerCamera.gameObject.layer = layerToSet;

             playerCamera.cullingMask |= 1 << layerToSet;
         }
         else
         {
             virtualPlayerCamera.enabled = false;
             playerCamera.enabled = false;

             mainCamera.gameObject.SetActive(true);
             mainVirtualCamera.gameObject.SetActive(true);

             if (cinemachineTargetGroup.FindMember(playerInput.transform) < 0)
             {
                 cinemachineTargetGroup.AddMember(playerInput.transform, 1, 2);
                 cinemachineTargetGroup.DoUpdate();
             }
         }*/
        if (!PlayerExists(playerInput))
            indiceJugadores.Add(playerInput.playerIndex);
    }

    private void RemovePlayer(PlayerInput playerInput)
    {
        indiceJugadores.Remove(playerInput.playerIndex);
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

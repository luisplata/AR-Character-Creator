using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InstallerStatesOfGame : MonoBehaviour, IMediadorAR
{
    [SerializeField] ARSession m_Session;
    [SerializeField] ARRaycastManager m_RaycastManager;
    [SerializeField] private ARSessionOrigin sessionOrigin;
    [SerializeField] private StateOfGame stateOfGame;
    [SerializeField] private ARPlaneManager plane;
    [SerializeField] private ARPointCloudManager point;
    [SerializeField] private ColliderInCamera coli;
    [SerializeField] private Transform player;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    private bool _hasClick;
    private Vector2 _mousePosition;

    IEnumerator Start()
    {
        stateOfGame.Write($"{ARSession.state}");
        if ((ARSession.state == ARSessionState.None) || (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }
        stateOfGame.Write($"{ARSession.state}");
        if (ARSession.state == ARSessionState.Unsupported)
        {
            // Start some fallback experience for unsupported devices
        }
        else
        {
            ARSession.stateChanged += onChange;
            StatesOfGame(ARSession.state);
        }

    }


    void onChange(ARSessionStateChangedEventArgs eventArgs)
    {
        StatesOfGame(eventArgs.state);
    }

    private void StatesOfGame(ARSessionState eventArgs)
    {
        switch (eventArgs)
        {
            case ARSessionState.None:
            case ARSessionState.Unsupported:
            case ARSessionState.CheckingAvailability:
            case ARSessionState.NeedsInstall:
            case ARSessionState.Installing:
                //stateOfGame.Write($"{eventArgs} here is: None, unsuporeted, installing");
                stateOfGame.Restart();
                break;
            case ARSessionState.Ready:
            case ARSessionState.SessionTracking:
            case ARSessionState.SessionInitializing:
                //stateOfGame.Write($"{eventArgs} here is: ready, traking, initializing");
                //stateOfGame.Write($"configurando");
                stateOfGame.Configuration(this);
                coli.Configurate(stateOfGame);
                coli.OnCollisionEnterDelegate += () => { stateOfGame.Write($"OnCollisionEnterDelegate"); };
                break;
        }
    }

    public void StartSession()
    {
        //stateOfGame.Write($"StartSession");
        m_Session.enabled = true;
        ARSession.stateChanged += onChange;
    }

    public Camera GetSessionOrigin()
    {
        return sessionOrigin.camera;
    }

    public GameObject InstantiateObjectInRaycast(Vector2 pointToRay, GameObject prefab)
    {
        if (m_RaycastManager.Raycast(pointToRay,s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;
            //stateOfGame.Write($"{hitPose.position} pose");
            
            var spawnedObject = Instantiate(prefab);
            spawnedObject.transform.position = hitPose.position;
            spawnedObject.transform.rotation = hitPose.rotation;
            
            //stateOfGame.Write($"{spawnedObject.transform.position} spawned");
            
            return spawnedObject;
        }

        throw new Exception("no instancio nada");
    }

    public ARRaycastManager GetRayCastManager()
    {
        return m_RaycastManager;
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        //stateOfGame.Write($"{context.ReadValue<Vector2>()}");
        _mousePosition = context.ReadValue<Vector2>();
    }
    
    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //button is press
            _hasClick = true;
        }
        else if (context.canceled)
        {
            //button is released
            _hasClick = false;
        }
        //stateOfGame.Write($"_hasClick {_hasClick}");
    }
    public bool Touch()
    {
        return _hasClick;// Input.touchCount > 0;
    }

    public void HideDebuggers()
    {
        plane.planePrefab = null;
        point.pointCloudPrefab = null;
    }

    public Vector2 GetMousePosition()
    {
        return _mousePosition;
    }

    public Transform GetPlayer()
    {
        return player;
    }

    public void Repetir()
    {
        SceneManager.LoadScene(0);
    }
}
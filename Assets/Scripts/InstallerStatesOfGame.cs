using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
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
            stateOfGame.Configuracion(this);
        }

    }


    void onChange(ARSessionStateChangedEventArgs eventArgs)
    {
        stateOfGame.Write($"{eventArgs.state}");
    }

    public void StartSession()
    {
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
            stateOfGame.Write($"{hitPose.position} pose");
            
            var spawnedObject = Instantiate(prefab);
            spawnedObject.transform.position = hitPose.position;
            spawnedObject.transform.rotation = hitPose.rotation;
            
            stateOfGame.Write($"{spawnedObject.transform.position} spawned");
            
            return spawnedObject;
        }

        throw new Exception("no instancio nada");
    }

    public ARRaycastManager GetRayCastManager()
    {
        return m_RaycastManager;
    }

    public bool Touch()
    {
        return Input.touchCount > 0;
    }

    public Vector2 TouchPosition()
    {
        return Input.GetTouch(0).position;
    }

    public void HideDebuggers()
    {
        plane.enabled = false;
        point.enabled = false;
    }

    public void Repetir()
    {
        SceneManager.LoadScene(0);
    }
}
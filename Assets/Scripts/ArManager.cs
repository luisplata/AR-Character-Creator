using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager m_RaycastManager;
    [SerializeField] GameObject m_PlacedPrefab;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] ARSession m_Session;
    public GameObject spawnedObject { get; private set; }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    IEnumerator Start()
    {
        if ((ARSession.state == ARSessionState.None) || (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            // Start some fallback experience for unsupported devices
        }
        else
        {
            // Start the AR session
            m_Session.enabled = true;
            ARSession.stateChanged += onChange;
        }

    }

    void onChange(ARSessionStateChangedEventArgs eventArgs)
    {
        Debug.Log(eventArgs.state);
        text.text += $"{eventArgs.state} \n";
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            AddObject(Input.GetTouch(0).position);
        }
    }

    public void AddObject(Vector2 position)
    {
        text.text += "click \n";
        var touchPosition = position;
        if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;
            text.text += $"{hitPose.position} pose \n";
            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(m_PlacedPrefab);
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }

            text.text += $"{spawnedObject.transform.position} position of spawned \n";
        }
    }
}
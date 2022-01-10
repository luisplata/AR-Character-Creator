using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArManager : MonoBehaviour
{

    [SerializeField]
    ARRaycastManager m_RaycastManager;
    [SerializeField]
    GameObject m_PlacedPrefab;
    public GameObject spawnedObject { get; private set; }
    
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    
    public void AddObject(InputAction.CallbackContext context)
    {
        var touchPosition = context.ReadValue<Vector2>();
        if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                //spawnedObject.transform.position = hitPose.position;
            }
        }
    }
}

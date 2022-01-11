using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DoomieAr : MonoBehaviour, IMediadorAR
{
    [SerializeField] private Transform hitPose;
    [SerializeField] private StateOfGame state;

    private void Start()
    {
        state.Configuracion(this);
    }

    public void StartSession()
    {
        
    }

    public Camera GetSessionOrigin()
    {
        return Camera.main;
    }

    public GameObject InstantiateObjectInRaycast(Vector2 pointToRay, GameObject prefab)
    {
        
        var spawnedObject = Instantiate(prefab);
        spawnedObject.transform.position = hitPose.position;
        spawnedObject.transform.rotation = hitPose.rotation;
        return spawnedObject;
    }

    public ARRaycastManager GetRayCastManager()
    {
        throw new NotImplementedException();
    }

    public bool Touch()
    {
        return Input.GetMouseButtonDown(0);                                
    }

    public Vector2 TouchPosition()
    {
        return Input.mousePosition;
    }

    public void HideDebuggers()
    {
        
    }
}
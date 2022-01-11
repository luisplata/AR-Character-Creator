using UnityEngine;
using UnityEngine.XR.ARFoundation;

public interface IMediadorAR
{
    void StartSession();
    Camera GetSessionOrigin();
    GameObject InstantiateObjectInRaycast(Vector2 pointToRay, GameObject prefab);
    ARRaycastManager GetRayCastManager();
    bool Touch();
    Vector2 TouchPosition();
    void HideDebuggers();
}
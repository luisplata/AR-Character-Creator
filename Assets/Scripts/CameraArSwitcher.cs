using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class CameraArSwitcher : MonoBehaviour
{
    [SerializeField]
    ARCameraManager m_CameraManager;

    [SerializeField] private TextMeshProUGUI text;
    
    public ARCameraManager cameraManager
    {
        get => m_CameraManager;
        set => m_CameraManager = value;
    }
    
    [SerializeField]
    ARSession m_Session;

    private bool _hasClick = true;

    private void Start()
    {
        text.text += "inicio\n";
        ARSession.stateChanged += ARSessionOnstateChanged;
    }

    private void ARSessionOnstateChanged(ARSessionStateChangedEventArgs obj)
    {
        text.text += $"{obj.state}\n";
    }

    public ARSession session
    {
        get => m_Session;
        set => m_Session = value;
    }
    
    public void OnTouch(InputAction.CallbackContext context)
    {
        _hasClick = true;
        text.text += "click en evento\n";
    }
    void Update()
    {
        if (m_CameraManager == null || m_Session == null)
            return;
    
        if (_hasClick)
        {
            text.text += "click\n";
            if (m_CameraManager.requestedFacingDirection == CameraFacingDirection.User)
            {
                text.text += "word\n";
                m_CameraManager.requestedFacingDirection = CameraFacingDirection.World;
            }
            else
            {
                text.text += "user\n";
                m_CameraManager.requestedFacingDirection = CameraFacingDirection.User;
            }

            _hasClick = false;
        }
    }
}
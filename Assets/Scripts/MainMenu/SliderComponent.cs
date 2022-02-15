using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SliderComponent : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private List<GameObject> contents;
    [SerializeField]private float smooth;

    private float _scrollPos = 0;

    private bool touch;
    private float limitToTakeOtherTab;
    private float limitLeftToTakeOtherTab;
    private float distanceAllways;
    private float limitValue;

    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //button is press
            touch = false;
        }
        else if (context.canceled)
        {
            //button is released
            touch = true;
        }
    }

    private void Start()
    {
        
        distanceAllways = 1f / (contents.Count - 1);
        limitValue = distanceAllways / 8;
        
        limitToTakeOtherTab = limitValue + (distanceAllways * _scrollPos);
        limitLeftToTakeOtherTab = (distanceAllways * _scrollPos) - limitValue;
    }

    // Update is called once per frame
    void Update()
    {
        var valueUpdate = scrollbar.value;
        //var limitToTakeOtherTab = limitValue + (distanceAllways * _scrollPos);
        //var limitLeftToTakeOtherTab = (distanceAllways * _scrollPos) - limitValue;
        
        Debug.Log(distanceAllways);
        Debug.Log(limitValue);
        Debug.Log(valueUpdate);
        Debug.Log($"{(limitToTakeOtherTab + (limitValue * 3))} {limitToTakeOtherTab}");
        Debug.Log($"{(limitLeftToTakeOtherTab - (limitValue * 3))} {limitLeftToTakeOtherTab}");
        Debug.Log($"{valueUpdate <= _scrollPos * distanceAllways} valueUpdate <= _scrollPos * distanceAllways");
        Debug.Log($"{valueUpdate >= _scrollPos * distanceAllways} valueUpdate >= _scrollPos * distanceAllways");
        Debug.Log(touch);
        if (touch)
        {
            scrollbar.value = Mathf.Lerp(valueUpdate, _scrollPos * distanceAllways, smooth);
            limitToTakeOtherTab = limitValue + (distanceAllways * _scrollPos);
            limitLeftToTakeOtherTab = (distanceAllways * _scrollPos) - limitValue;
        }
        else
        {
            if (valueUpdate <= _scrollPos * distanceAllways)
            {
                //izquierda
                if (valueUpdate < limitLeftToTakeOtherTab)
                {
                    _scrollPos--;
                }
            }
            else if(valueUpdate >= _scrollPos * distanceAllways)
            {
                //derecha
                if (valueUpdate > limitToTakeOtherTab)
                {
                    _scrollPos++;
                }
            }
        }

        if (_scrollPos >= contents.Count)
        {
            _scrollPos = 3;
            scrollbar.value = 1;
        }
        
        if (_scrollPos < 0)
        {
            _scrollPos = 0;
            scrollbar.value = 0;
        }
    }
}

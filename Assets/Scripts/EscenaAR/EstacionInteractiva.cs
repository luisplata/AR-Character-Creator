using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EstacionInteractiva : MonoBehaviour
{
    [SerializeField] private Animator anim, animDeContenido;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Image iconoDeVideo, iconoDeTexto, iconoDeAudio, iconoDeNext;
    [SerializeField] private Sprite imagenDeVideo, imagenDeTexto, imagenDeAudio, imagenDeNext;
    [SerializeField] private VideoPlayer componenteDeVideoVideo, componenteDeVideoAudio;
    [SerializeField] private TextMeshProUGUI componenteDeTexto;
    [SerializeField] private string textoParaMostrar;
    [SerializeField] private VideoClip videoParaMostrarVideo, videoParaMostrarAudio;
    [SerializeField] private Canvas canvasCanvas;
    private IMediator _mediator;
    private bool _canuse;
    private Transform _targetForLookAt;

    public void Configuracion(Camera camera1, IMediator mediator, Transform targetForLookAt)
    {
        _mediator = mediator;
        canvas.SetActive(false);
        
        canvasCanvas.worldCamera = camera1;
        
        iconoDeVideo.sprite = imagenDeVideo;
        iconoDeAudio.sprite = imagenDeAudio;
        iconoDeTexto.sprite = imagenDeTexto;
        iconoDeNext.sprite = imagenDeNext;
        _canuse = true;
        _targetForLookAt = targetForLookAt;
        componenteDeTexto.text = textoParaMostrar;

        componenteDeVideoVideo.clip = videoParaMostrarVideo;
        componenteDeVideoAudio.clip = videoParaMostrarAudio;
    }

    private void Update()
    {
        if (!_canuse) return;
        transform.LookAt(_targetForLookAt);
    }

    public void ButtonVideo()
    {
        _mediator.Write("click in video");
        animDeContenido.SetBool("showVideo", true);
        anim.gameObject.SetActive(false);
    }
    public void ButtonAudio()
    {
        _mediator.Write("click in audio");
        animDeContenido.SetBool("showAudio", true);
        anim.gameObject.SetActive(false);
    }
    public void ButtonTexto()
    {
        Debug.Log("click texto");
        animDeContenido.SetBool("showText", true);
        anim.gameObject.SetActive(false);
    }
    
    public void ExitButton()
    {
        Debug.Log("click exit");
        animDeContenido.SetBool("showText", false);
        animDeContenido.SetBool("showVideo", false);
        animDeContenido.SetBool("showAudio", false);
        anim.gameObject.SetActive(true);
        anim.SetBool("open", true);
    }
    
    public void ButtonNext()
    {
        Debug.Log("click next");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
        anim.SetBool("open", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("open", false);
        StartCoroutine(CloseCanvas());
    }

    IEnumerator CloseCanvas()
    {
        yield return new WaitForSeconds(.5f);
        canvas.SetActive(false);
    }
}
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Video;

public class EscenarioInteractivo : MonoBehaviour
{
    [SerializeField] private List<EstacionInteractiva> estacionesInteractivas;
    private IMediator _mediator;

    public void Configuracion(Camera camera, IMediator mediator, Transform player)
    {
        _mediator = mediator;
        foreach (var estacionInteractiva in estacionesInteractivas)
        {
            estacionInteractiva.Configuracion(camera, _mediator, player);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArShooter : ShooterToEnemies
{
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    protected override bool TryGetTouchPosition()
    {
        //_mediator.Write("Click en AR");
        return Input.touchCount > 0;
    }

    protected override void FixUpdate()
    {
        _mediator.Write("Touch");
        var touchPosition = Input.GetTouch(0).position;
        var ray = _mediator.GetSessionOrigin().ScreenPointToRay(touchPosition);
        var allCol = Physics.RaycastAll(ray);
        foreach (var hit in allCol)
        {
            if (hit.transform.TryGetComponent<EnemyInGame>(out var e))
            {
                e.DestroyLogic();
                _mediator.Write($"Colisiono");
            }
        }
        /*
        if (_mediator.GetRayCastManager().Raycast(touchPosition, s_Hits))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;
            _mediator.Write($"{hitPose.position} position");
            foreach (var hit in s_Hits)
            {
                _mediator.Write($"{hit.trackable.gameObject.name} name");
                if (hit.trackable.gameObject.TryGetComponent<EnemyInGame>(out var e))
                {
                    e.DestroyLogic();
                    _mediator.Write($"Colisiono");
                    break;
                }
            }
        }*/
    }
}
using UnityEngine;

public class ClickShooter : ShooterToEnemies
{
    protected override bool TryGetTouchPosition()
    {
        return Input.GetMouseButtonDown(0);
    }

    protected override void FixUpdate()
    {
        //logica del raycast
        RaycastHit[] hits;
        var posicion = transform.position;
        // Does the ray intersect any objects excluding the player layer
        var _mousePos = Input.mousePosition;
        _mousePos.z = 2;
        _mediator.Write($"{_mousePos} mouse");
        hits = Physics.RaycastAll(Camera.main.transform.position, (Camera.main.ScreenToWorldPoint(_mousePos) - Camera.main.transform.position), Mathf.Infinity);
        _mediator.Write($"{Camera.main.ScreenToWorldPoint(_mousePos)} screanToWord");
        Debug.DrawRay(Camera.main.transform.position, ((Camera.main.ScreenToWorldPoint(_mousePos) - Camera.main.transform.position)) * 100, Color.yellow);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.TryGetComponent<EnemyInGame>(out var e))
            {
                e.DestroyLogic();
                _mediator.Write($"Colisiono");
                break;
            }
        }
    }
}
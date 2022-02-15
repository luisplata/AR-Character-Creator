using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{
    public void OnMovePlayer(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        Debug.Log($"{input}");
        GetComponent<Rigidbody>().velocity = new Vector3(input.x, 0, input.y);
    }
}

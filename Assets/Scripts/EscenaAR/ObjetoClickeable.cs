using UnityEngine;
using UnityEngine.Events;

public class ObjetoClickeable : MonoBehaviour
{
    [SerializeField] private EstacionInteractiva estacion;
    public UnityEvent UnityAction;

    public void Click()
    {
        UnityAction?.Invoke();
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObjetoClickeable : MonoBehaviour
{
    public UnityEvent UnityAction;
    private bool isEnable = true;

    public void Click()
    {
        if(!isEnable) return;
        UnityAction?.Invoke();
        isEnable = false;
        StartCoroutine(Sleep());
    }

    public IEnumerator Sleep()
    {
        yield return new WaitForSeconds(.5f);
        isEnable = true;
    }
}

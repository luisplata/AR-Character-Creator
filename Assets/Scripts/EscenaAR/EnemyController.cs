using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void Configure()
    {
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = Vector3.one;
        animator.Play(ServiceLocator.Instance.GetService<IAnimations>().GetIdle());
    }

    public void PlayNextAnim()
    {
        animator.Play(ServiceLocator.Instance.GetService<IAnimations>().NextAnim());
    }
    
    public void PlayPreviousAnim()
    {
        animator.Play(ServiceLocator.Instance.GetService<IAnimations>().PreviousAnim());
    }
}

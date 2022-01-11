using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

public class WaitForClick : IEnemyState
{
    private readonly IMediator _mediator;

    public WaitForClick(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async UniTask<StateResult> DoAction(object data)
    {
        while (!_mediator.HasClickInScream())
        {
            await UniTask.Delay(TimeSpan.FromMilliseconds(100));
        }
        _mediator.ShootRaycast(()=>
        {
            
        });
        _mediator.HideDebuggers();
        return new StateResult(EnemyStatesConfiguration.Game);
    }
}
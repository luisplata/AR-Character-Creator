﻿using System;
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
        //_mediator.Write($"Esperando por click");
        while (!_mediator.HasClickInScream())
        {
            await UniTask.NextFrame();
        }
        //_mediator.Write($"Clikeo");
        if (!_mediator.ShootRaycast(() => {  }))
        {
            return new StateResult(EnemyStatesConfiguration.WaitForClickInSpace);
        }
        _mediator.HideDebuggers();
        return new StateResult(EnemyStatesConfiguration.Game);
    }
}
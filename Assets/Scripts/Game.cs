﻿using System;
using Cysharp.Threading.Tasks;

public class Game : IEnemyState
{
    private readonly IMediator _mediator;

    public Game(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async UniTask<StateResult> DoAction(object data)
    {
        _mediator.ConfiguraEnemigoSpawner();
        _mediator.ConfigureShooter();
        while (!_mediator.FinishGame())
        {
            await UniTask.Delay(TimeSpan.FromMilliseconds(100));
            
        }

        return new StateResult(EnemyStatesConfiguration.FinishGame);
    }
}
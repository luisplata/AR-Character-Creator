using UnityEngine;

public interface ICharacterFactory
{
    EnemyController Create(string id);
    EnemyController GetNextCharacter();
    EnemyController GetPreviousCharacter();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour, ICharacterFactory
{
    private CharactersConfiguration charactersConfiguration;

    public void Configurate(CharactersConfiguration charactersConfiguration)
    {
        this.charactersConfiguration = charactersConfiguration;
    }
        
    public EnemyController Create(string id)
    {
        return Instantiate(charactersConfiguration.GetCharacter().Instantiable);
    }

    public EnemyController GetNextCharacter()
    {
        return Instantiate(charactersConfiguration.GetNextCharacter().Instantiable);
    }

    public EnemyController GetPreviousCharacter()
    {
        return Instantiate(charactersConfiguration.GetPreviousCharacter().Instantiable);
    }
}
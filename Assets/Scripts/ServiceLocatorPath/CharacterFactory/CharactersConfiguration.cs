using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Character configuration")]
public class CharactersConfiguration : ScriptableObject
{
    [SerializeField] private Character[] characters;
    private Dictionary<string, Character> idToCharacters;
    private int index;

    private void Awake()
    {
        idToCharacters = new Dictionary<string, Character>(characters.Length);
        foreach (var character in characters)
        {
            idToCharacters.Add(character.Id, character);
        }
    }

    public Character GetCharacterPrefabById(string id)
    {
        if (!idToCharacters.TryGetValue(id, out var character))
        {
            throw new Exception($"Character with id {id} does not exit");
        }
        return character;
    }

    public Character GetNextCharacter()
    {
        index++;
        if (index > characters.Length -1)
        {
            index = 0;
        }
        return GetCharacter();
    }
    public Character GetPreviousCharacter()
    {
        index--;
        if (index < 0)
        {
            index = characters.Length-1;
        }
        return GetCharacter();
    }

    public Character GetCharacter()
    {
        return characters[index];
    }
}
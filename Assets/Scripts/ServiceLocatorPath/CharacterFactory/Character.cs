using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected string id;
    [SerializeField] protected EnemyController instantiable;
    public string Id => id;
    public EnemyController Instantiable => instantiable;
}
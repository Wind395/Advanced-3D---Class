using UnityEngine;
using UnityEngine.AI;

public abstract class Enemies : MonoBehaviour
{

    public GameObject path;
    public float health;
    public float damage;

    public abstract void Attack();
    public abstract void Move();
    public abstract void Die();
}

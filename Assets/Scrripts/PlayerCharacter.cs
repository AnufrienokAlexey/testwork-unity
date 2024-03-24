using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;

    private void Start()
    {
        health = 10;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
    }
}

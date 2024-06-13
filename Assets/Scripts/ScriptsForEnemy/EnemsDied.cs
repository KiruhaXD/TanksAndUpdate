using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemsDied : MonoBehaviour
{
    [SerializeField] public int enemsAlive;

    public void ZombiesDied() => enemsAlive--;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField]
    Item item;

    public float puntos;

    public void Consume()
    {
        puntos = item.points;
        Destroy(gameObject);
    }
}

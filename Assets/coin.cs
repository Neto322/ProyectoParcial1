using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField]
    Item item;

    public float puntos;

     void Start() {
         puntos = item.points;
    }
    public void Consume()
    {
        Destroy(gameObject);


        
      
    }
}

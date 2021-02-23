using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Items/Item", order = 0)]

public class Item : ScriptableObject {
    
    [SerializeField]
     string objectName;

    [SerializeField , TextArea(3,10)]
     string description;

    [SerializeField]
     public float points;

}

   
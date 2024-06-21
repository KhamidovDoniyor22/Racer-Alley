using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.GetComponent<ObjectType>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}

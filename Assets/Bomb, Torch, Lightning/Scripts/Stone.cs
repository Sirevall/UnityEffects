using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
}

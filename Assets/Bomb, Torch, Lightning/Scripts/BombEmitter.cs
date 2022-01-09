using UnityEngine;
using System.Collections;

public class BombEmitter : MonoBehaviour
{
    public GameObject BombPrefab;
    void Start ()
    {
        StartCoroutine (DropBombs ());
    }

    IEnumerator DropBombs ()
    {
        while (Application.isPlaying)
        {
            CreateBomb ();
            yield return new WaitForSeconds (5);
        }
    }

    void CreateBomb ()
    {
        if (BombPrefab != null)
        {
            Instantiate (BombPrefab, transform.position, BombPrefab.transform.rotation);
        }
    }
}

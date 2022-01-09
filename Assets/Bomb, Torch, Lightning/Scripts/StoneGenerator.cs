using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
    public GameObject[] Prefab;
    public int Count;
    public float Radius;


    void Start()
    {
        StartCoroutine(CreateCubes());
    }
    private void CubeCreator()
    {
        float randomX = UnityEngine.Random.Range(Radius * -1, Radius);
        float randomZ = UnityEngine.Random.Range(Radius*-1, Radius);
        float randomAngle = UnityEngine.Random.Range(0f, 361f);
        int prefabNumber = UnityEngine.Random.Range(0, Prefab.Length);
        Vector3 pos = new Vector3(randomX, 0f, randomZ);

        Instantiate(Prefab[prefabNumber], pos, Quaternion.Euler(0f, randomAngle, 0f));
    }
    IEnumerator CreateCubes()
    {
        while (Application.isPlaying)
        {
            for (int i = 0; i < Count; i++)
            {
                CubeCreator();
            }
            yield return new WaitForSeconds(5);
        }
    }
}

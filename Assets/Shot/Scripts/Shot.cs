using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject ShotEffect;

    private Vector3 _shotEffectPosition;

    private void Start()
    {
        _shotEffectPosition = gameObject.transform.GetChild(0).GetComponent<Transform>().position;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }
    private void Shooting()
    {
        GameObject shot = (GameObject)Instantiate(ShotEffect, _shotEffectPosition, ShotEffect.transform.rotation);
        Destroy(shot, shot.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleScrip : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem FireworksAll;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Enemy"))
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(FireworksAll);
        FireworksAll.Play();
    }
}

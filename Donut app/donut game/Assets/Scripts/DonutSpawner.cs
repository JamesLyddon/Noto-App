using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutSpawner : MonoBehaviour
{
    public GameObject[] donuts;
    public AudioSource blip;
    public GameObject explosionEffect;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {

            var donutInstance = donuts[Random.Range(0, 4)];
            StartCoroutine(SpawnDonut(donutInstance));
            blip.pitch = Random.Range(0.5f, 1.5f);
        }
    }

    IEnumerator SpawnDonut(GameObject donut)
    {
        var tempDonut = Instantiate(donut, new Vector3((Random.Range(-0.5f, 0.5f)), Random.Range(1.0f, 2.5f), Random.Range(-0.15f, 0.15f)), Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(tempDonut);
    }
}

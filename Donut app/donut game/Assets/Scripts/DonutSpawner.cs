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
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(pos);
        var tempDonut = Instantiate(donut, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), Quaternion.identity);
        
        yield return new WaitForSeconds(3);
        var tempExplosion = Instantiate(explosionEffect, tempDonut.transform.position, tempDonut.transform.rotation);
        tempExplosion.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 5f);
        tempExplosion.GetComponent<AudioSource>().Play();
        Collider[] colliders = Physics.OverlapSphere(tempDonut.transform.position, 1);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(200, tempDonut.transform.position, 1);
            }
        }

        Destroy(tempDonut);
        yield return new WaitForSeconds(1);
        Destroy(tempExplosion);
    }
}

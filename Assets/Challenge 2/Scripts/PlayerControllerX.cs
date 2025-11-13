using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float nextValidTime = 0f;
    private float cooldownTime = 3.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextValidTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            nextValidTime = Time.time + cooldownTime;
        }
    }
}

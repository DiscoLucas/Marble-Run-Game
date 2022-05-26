using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnableObject;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnableObject, transform.position, transform.rotation);
        Debug.Log("object was spawned");
        System.Threading.Thread.Sleep(2);
        Object.Destroy(spawnableObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

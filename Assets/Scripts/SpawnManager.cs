using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject kostkaPrefab;
    public GameObject colider;

    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(kostkaPrefab, new Vector3 (0,0,0), kostkaPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Instantiate(colider, new Vector3(0, 0, 0), colider.transform.rotation);

    }
}

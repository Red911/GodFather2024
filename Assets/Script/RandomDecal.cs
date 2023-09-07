using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering.Universal;

public class RandomDecal : MonoBehaviour
{
    [Header("Decals")]
    public Transform[] spawners;
    public GameObject[] decalPrefabs;

    [Header("Decals")]
    public GameObject decalPrefab;
    public int nDecals = 2;

    [Range(0.1f, 0.7f)]
    public float minScale;
    [Range(0.1f, 0.7f)]
    public float maxScale;
    
    
    void Start()
    {
        
        for (int i = 0; i <= nDecals; i++)
        {
            decalPrefab = decalPrefabs[Random.Range(0, decalPrefabs.Length)];
            
            GameObject decalProjectorInst = Instantiate(decalPrefab, spawners[i].position, spawners[i].rotation);
            DecalProjector decalProjectorComp = decalProjectorInst.GetComponent<DecalProjector>();

            float scale = Random.Range(minScale, maxScale);
            
            decalProjectorComp.size = new Vector3(scale, scale, 1f);
            
            decalProjectorComp.material = new Material(decalProjectorComp.material);
        }
        
    }

    
    void Update()
    {
        
    }
}

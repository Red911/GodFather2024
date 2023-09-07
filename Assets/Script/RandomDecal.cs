using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RandomDecal : MonoBehaviour
{
    [Header("List")] public Transform[] spawners;
    public GameObject[] decalPrefabs;

    [Header("Decals")] public GameObject decalPrefab;
    public float probability = 0.5f;
    private int _nDecals = 1;

    [Range(0.1f, 0.7f)] public float minScale;
    [Range(0.1f, 0.7f)] public float maxScale;

    private Vector3 _lastPosition;

    void Start()
    {
        RandDecals();
    }


    void RandDecals()
    {

    _nDecals = RandIncreaseDecal(probability);

        for (int i = 0; i <= _nDecals;
    i++)
    {
        Transform decalPos = spawners[Random.Range(0, spawners.Length)];


        if (decalPos.position == _lastPosition)
        {
            decalPos = spawners[Random.Range(0, spawners.Length)];
        }

        _lastPosition = decalPos.position;

        decalPrefab = decalPrefabs[Random.Range(0, decalPrefabs.Length)];

        GameObject decalProjectorInst = Instantiate(decalPrefab, decalPos);



        DecalProjector decalProjectorComp = decalProjectorInst.GetComponent<DecalProjector>();

        float scale = Random.Range(minScale, maxScale);

        decalProjectorComp.size = new Vector3(scale, scale, 1.5f);

        decalProjectorComp.material = new Material(decalProjectorComp.material);
    }
}


int RandIncreaseDecal(float proba)
    {
        int numberDecals = 0;
        float rand = Random.value;
        
        if (rand <= proba)
        {
            numberDecals += 1;
        }
        
        return numberDecals;
    }
}

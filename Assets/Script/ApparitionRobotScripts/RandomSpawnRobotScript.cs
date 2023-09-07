using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnRobotScript : MonoBehaviour
{
    public RobotPartsScriptableObject robotPartsData;

    private LightsScript lightsScript;

    public bool nextRobot;

    public GameObject _actualHead;
    public GameObject _actualArm;
    public GameObject _actualAntenne;
    public GameObject _actualBody;

    private int _indexHead;
    private int _indexArm;
    private int _indexAntenne;
    private int _indexBody;

    [SerializeField] private bool isAGoodRobot;

    // Start is called before the first frame update
    void Start()
    {
        lightsScript = GameObject.Find("RobotLightsManager").GetComponent<LightsScript>();

        //robotPartsData = ScriptableObject.CreateInstance<RobotPartsScriptableObject>();

        isAGoodRobot= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextRobot)
        {
            nextRobot= false;
            NextRobot();
        }
    }

    public void NextRobot()
    {
        lightsScript.NewLightCombination();
        lightsScript.ActivateAllLights();
        int r = Random.Range(0, 20);
        if (r <10)
        {
            Debug.Log("Bon robot en création");
            isAGoodRobot= true;
            MakeGoodRobot();
        }
        else
        {
            Debug.Log("Mauvais robot en création");
            isAGoodRobot = false;
            MakeFakeRobot();
        }
    }

    private void MakeGoodRobot()
    {
        string codeRGB = lightsScript.combinaisonActuelle;
        switch (codeRGB)
        {
            case "RRG":
                _actualBody = robotPartsData.listeBody[1];
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(1, 3);
                _indexHead = Random.Range(0, 3);
                while (_indexHead == 1)
                {
                    _indexHead = Random.Range(0, 3);
                }
                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                
                break;
            case "RGB":
                _indexBody = 2;
                _indexAntenne = 0;
                _indexArm = 1;
                _indexHead = 2;
                
                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "RBR":
                _actualBody = robotPartsData.listeBody[0];
                _indexAntenne = Random.Range(1,3);
                _indexArm = Random.Range (0,3);
                _indexHead = Random.Range(0,2);
                while (_indexArm == 1)
                {
                    _indexArm = Random.Range(0, 3);
                }

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                break;
            case "GGB":
                _indexBody = 2;
                _indexAntenne = Random.Range(1,3);
                _indexArm = 0;
                _indexHead = 8;

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "GBR":
                _indexBody = 0;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(1, 3);
                _indexHead = 2;

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "GRG":
                _indexBody = 1;
                _indexAntenne = 1;
                _indexArm = 1;
                _indexHead = Random.Range(6,9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "BBR":
                _indexBody = 0;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = 2;
                _indexHead = Random.Range(3,6);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "BGB":
                _indexBody = 2;
                _indexAntenne = 0;
                _indexArm = 2;
                _indexHead = 5;

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "BRG":
                _indexBody = 1;
                _indexAntenne = 2;
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(3,5);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
        }
    }
    private void MakeFakeRobot()
    {
        string codeRGB = lightsScript.combinaisonActuelle;
        switch (codeRGB)
        {
            case "RRG":
                _indexBody = 1;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualBody = robotPartsData.listeBody[_indexBody];
                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                break;
            case "RGB":
                _indexBody = 2;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "RBR":
                _indexBody = 0;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "GGB":
                _indexBody = 2;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "GBR":
                _indexBody = 0;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "GRG":
                _indexBody = 1;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "BBR":
                _indexBody = 0;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "BGB":
                _indexBody = 2;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
            case "BRG":
                _indexBody = 1;
                _indexAntenne = Random.Range(0, 3);
                _indexArm = Random.Range(0, 3);
                _indexHead = Random.Range(0, 9);

                _actualAntenne = robotPartsData.listeAntenne[_indexAntenne];
                _actualArm = robotPartsData.listeArm[_indexArm];
                _actualHead = robotPartsData.listeHead[_indexHead];
                _actualBody = robotPartsData.listeBody[_indexBody];
                break;
        }
    }
}

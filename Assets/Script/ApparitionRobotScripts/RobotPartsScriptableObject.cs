using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RobotPartsData", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class RobotPartsScriptableObject : ScriptableObject
{

    public GameObject[] listeHead;
    public GameObject[] listeBody;
    public GameObject[] listeAntenne;
    public GameObject[] listeArm;

}

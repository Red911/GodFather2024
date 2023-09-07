using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleRobotScript : MonoBehaviour
{
    public RandomSpawnRobotScript spawnRobotScript;

    public Transform[] listeBodyApparents = new Transform[3];
    public Transform[] listeHeadApparents = new Transform[9];
    public Transform[] listeArmApparents = new Transform[3];
    public Transform[] listeAntenneApparents = new Transform[3];

    [SerializeField] private bool assemble;

    // Start is called before the first frame update
    void Start()
    {
        spawnRobotScript = GetComponent<RandomSpawnRobotScript>();

        listeHeadApparents = new Transform[9];
        listeAntenneApparents = new Transform[3];
        listeArmApparents = new Transform[3];
        listeBodyApparents = new Transform[3];

        int index = 0;
        
        for (int i = 1; i < 4; i++)
        {
            listeBodyApparents[index] = GameObject.Find("Char_Body" + i).GetComponent<Transform>();
            index++;
        }
        index = 0;
        for (int i = 1; i < 4; i++)
        {
            listeAntenneApparents[index] = GameObject.Find("Char_Antenne" + i).GetComponent<Transform>();
            index++;
        }
        index = 0;
        for (int i = 1; i < 4; i++)
        {
            listeArmApparents[index] = GameObject.Find("Char_Arm" + i).GetComponent<Transform>();
            index++;
        }

        string typeOeil = "a";
        index = 0;
        for (int j = 1; j< 4; j++)
        {
            for (int i = 0; i<3;i++)
            {
                listeHeadApparents[index] = GameObject.Find("Char_Head" + j + typeOeil).GetComponent<Transform>();
                index++;
                if (typeOeil == "a")
                {
                    typeOeil= "b";
                }
                else
                {
                    if (typeOeil == "b")
                    {
                        typeOeil= "c";
                    }
                    else
                    {
                        typeOeil= "a";
                    }
                }
            }
        }

        foreach (Transform tran in listeBodyApparents)
        {
            tran.gameObject.SetActive(false);
        }
        foreach (Transform tran in listeHeadApparents)
        {
            tran.gameObject.SetActive(false);
        }
        foreach (Transform tran in listeArmApparents)
        {
            tran.gameObject.SetActive(false);
        }
        foreach (Transform tran in listeAntenneApparents)
        {
            tran.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (assemble == true)
        {
            assemble= false;
            AssembleRobot();
        }
    }

    public void AssembleRobot()
    {
        foreach (Transform tran in listeBodyApparents)
        {
            if (tran.gameObject.name == spawnRobotScript._actualBody.name)
            {
                tran.gameObject.SetActive(true);
            }
        }
        foreach (Transform tran in listeHeadApparents)
        {
            if (tran.gameObject.name == spawnRobotScript._actualHead.name)
            {
                tran.gameObject.SetActive(true);
            }
        }
        foreach (Transform tran in listeArmApparents)
        {
            if (tran.gameObject.name == spawnRobotScript._actualArm.name)
            {
                tran.gameObject.SetActive(true);
            }
        }
        foreach (Transform tran in listeAntenneApparents)
        {
            if (tran.gameObject.name == spawnRobotScript._actualAntenne.name)
            {
                tran.gameObject.SetActive(true);
            }
        }
    }
}

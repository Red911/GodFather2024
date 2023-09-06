using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsScript : MonoBehaviour
{

    private Light _light1;
    private Light _light2;
    private Light _light3;

    // Start is called before the first frame update
    void Start()
    {
        _light1= GameObject.Find("RobotLight_1").GetComponentInChildren<Light>();
        _light2= GameObject.Find("RobotLight_2").GetComponentInChildren<Light>();
        _light3= GameObject.Find("RobotLight_3").GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

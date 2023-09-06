using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsScript : MonoBehaviour
{

    private Light _light1;
    private Light _light2;
    private Light _light3;

    [SerializeField] private float _lightsIntensity;

    [SerializeField] private bool _activateAllLights;

    [SerializeField] private bool _activateHeadLight;
    [SerializeField] private bool _activateBodyLight;

    public GameObject _robotHead;

    public GameObject _robotBody;

    // Start is called before the first frame update
    void Start()
    {
        _light1= GameObject.Find("RobotLight_1").GetComponentInChildren<Light>();
        _light2= GameObject.Find("RobotLight_2").GetComponentInChildren<Light>();
        _light3= GameObject.Find("RobotLight_3").GetComponentInChildren<Light>();

        _lightsIntensity = 0.01f;

        HideLights();
    }

    // Update is called once per frame
    void Update()
    {
        if (_activateAllLights == true) //Active les lumières liées à head et body
        {
            ShowLights();
            _activateAllLights = false;
            _activateBodyLight = true;
            _activateHeadLight = true;
        }

        if (_activateBodyLight == true) //Active les lumières liées à body
        {
            _activateBodyLight = false;
            ActivateBodyLight();
        }

        if (_activateHeadLight == true) //Active les lumières liées à head
        {
            _activateHeadLight = false;
            ActivateHeadLight();
        }
    }

    //Active les lumières liées à head
    public void ActivateHeadLight()
    {

        if (_robotHead != null && _robotHead.name != null)
        {
            string headName = _robotHead.name.Substring(0, _robotHead.name.Length-1); //Retire l'indicateur de qualité puisque la lumière ne prend pas en compte celui-ci

            switch(headName) //Applique une couleur en fonction du nom de la tête
            {
                case "Char_Head1":
                    _light1.color = Color.red;
                    Debug.Log("couleur rouge");
                    break;

                case "Char_Head2":
                    _light1.color = Color.blue;
                    break;

                case "Char_Head3":
                    _light1.color = Color.green;
                    break;


            }
        }
    }
    //Active les lumières liées à body
    public void ActivateBodyLight()
    {

        if (_robotBody != null && _robotBody.name != null)
        {
            string bodyName = _robotBody.name.Substring(0, _robotBody.name.Length);

            switch (bodyName) //Applique une couleur en fonction du nom du corps
            {
                case "Char_Body1":
                    _light2.color = Color.blue;
                    _light3.color = Color.red;
                    break;

                case "Char_Body2":
                    _light2.color = Color.red;
                    _light3.color = Color.green;
                    break;

                case "Char_Body3":
                    _light2.color = Color.green;
                    _light3.color = Color.blue;
                    break;
            }
        }
    }

    //Chache les lumières en reduisant leur intensité
    public void HideLights()
    {
        _light1.intensity = 0;
        _light2.intensity = 0;
        _light3.intensity = 0;
    }
    //Montre les lumières en augmentant leur intensité
    public void ShowLights()
    {
        _light1.intensity = _lightsIntensity;
        _light2.intensity = _lightsIntensity;
        _light3.intensity = _lightsIntensity;
    }
}

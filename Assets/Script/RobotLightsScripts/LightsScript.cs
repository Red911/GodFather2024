using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsScript : MonoBehaviour
{

    private Light _light1;
    private Light _light2;
    private Light _light3;

    public string[] listeCombinaisonCouleur;/* = new string[5];*/

    public string combinaisonActuelle;

    public float _lightsIntensity;

    [SerializeField] private bool _assignateLights;
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

        listeCombinaisonCouleur = new string[]{ "RRG", "RGB", "RBR", "GGB", "GBR", "GRG", "BBR", "BGB", "BRG" };


        _lightsIntensity = 0.01f;

        HideLights();
    }

    // Update is called once per frame
    void Update()
    {
        if(_assignateLights)
        {
            NewLightCombination();
            _assignateLights= false;
        }

        if (_activateAllLights == true) //Active les lumières liées à head et body
        {
            ActivateAllLights();
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

    public void NewLightCombination()
    {
        int c = Random.Range(0, 9); //aléatoire de 0 à 8
        combinaisonActuelle = listeCombinaisonCouleur[c];
    }

    public void ActivateAllLights()
    {
        ShowLights();
        _activateAllLights = false;
        _activateBodyLight = true;
        _activateHeadLight = true;
    }
    //Active les lumières liées à head
    public void ActivateHeadLight()
    {

        if (combinaisonActuelle != null || combinaisonActuelle != "")
        {

            switch(combinaisonActuelle[0]) //Applique une couleur en fonction du nom de la tête
            {
                case 'R':
                    _light1.color = Color.red;
                    break;

                case 'B':
                    _light1.color = Color.blue;
                    break;

                case 'G':
                    _light1.color = Color.green;
                    break;


            }
        }
    }
    //Active les lumières liées à body
    public void ActivateBodyLight()
    {
        if (combinaisonActuelle != null || combinaisonActuelle != "")
        {
            switch (combinaisonActuelle[1]) //Applique une couleur en fonction du nom du corps
            {
                case 'B':
                    _light2.color = Color.blue;
                    break;

                case 'R':
                    _light2.color = Color.red;
                    break;

                case 'G':
                    _light2.color = Color.green;
                    break;
            }
            switch (combinaisonActuelle[2])
            {
                case 'B':
                    _light3.color = Color.blue;
                    break;

                case 'R':
                    _light3.color = Color.red;
                    break;

                case 'G':
                    _light3.color = Color.green;
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

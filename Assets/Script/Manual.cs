using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Manual : MonoBehaviour
{
    private bool manualIsOpen = false;
    private GameObject activePage;
    public int previousOpenPageNumber;
    public int actualPage = 0;
    private RectTransform rt;
    private bool isSlidingDown = false;
    private bool isSlidingUp = false;
    public Vector2 startPos;
    public Vector2 stopPos;
    public Vector2 path;
    public AnimationCurve animCurve;
    private float time;

    [SerializeField]
    
    private GameObject[] manualPages;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        startPos = rt.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(manualIsOpen == false && Input.GetKeyDown(KeyCode.O))
        {
            manualIsOpen = true;

            StartCoroutine(SlideBookDown());

            activePage = manualPages[actualPage];
        }
        else if(manualIsOpen == true && Input.GetKeyDown(KeyCode.L))
        {
            manualIsOpen = false;

            StartCoroutine(SlideBookUp());

            activePage = null;
        }
        if (manualIsOpen && Input.GetKeyDown(KeyCode.F))
        {
            GoToNextPage();
            TrackActualPage();
        }

        if (manualIsOpen && Input.GetKeyDown(KeyCode.S))
        {
            GoToPreviousPage();
            TrackActualPage();
        }
    }

    private void GoToNextPage()
    {
        for (int i = 0; i < manualPages.Length; i++)
        {
            if (manualPages[i] == activePage)
            {
                previousOpenPageNumber = i;

                if (previousOpenPageNumber + 1 <= 4) //MODIFER LE 4 PAR LE NOMBRE DE PAGES
                {
                    activePage.SetActive(false);
                    activePage = manualPages[previousOpenPageNumber + 1];
                    activePage.SetActive(true);
                }
                else if(actualPage == 4)  //MODIFER LE 4 PAR LE NOMBRE DE PAGES
                {
                    activePage.SetActive(false);
                    activePage = manualPages[0];
                    activePage.SetActive(true);
                }
                break;
            }
        } 
    }
    private void GoToPreviousPage()
    {
        for (int i = 0; i < manualPages.Length; i++)
        {
            if (manualPages[i] == activePage)
            {
                previousOpenPageNumber = i;

                if (previousOpenPageNumber - 1 >= 0)
                {
                    activePage.SetActive(false);
                    activePage = manualPages[previousOpenPageNumber - 1];
                    activePage.SetActive(true);
                }
                else if (actualPage == 0)
                {
                    activePage.SetActive(false);
                    activePage = manualPages[manualPages.Length - 1];
                    activePage.SetActive(true);
                }
                break;
            }
        }   
    }

    private void TrackActualPage()
    {
        for (int i = 0; i < manualPages.Length; i++)
        {
            if (manualPages[i] == activePage)
            {
                actualPage = i;
                break;
            }
        }
    }

    IEnumerator SlideBookDown()
    { 
        isSlidingDown = true;
        while (isSlidingDown)
        {
            time += Time.deltaTime;
            float tCurve = animCurve.Evaluate(time);
            path = new Vector2(Mathf.Lerp(startPos.x, startPos.x, tCurve), Mathf.Lerp(startPos.y, startPos.y - 400, tCurve));

            rt.position = new Vector2(path.x, path.y);

            if (rt.position.y == startPos.y - 400)
            {
                isSlidingDown = false;
                stopPos = rt.position;
            }
            yield return null;

        }
        time = 0;
        yield return null;
    }

    IEnumerator SlideBookUp()
    {
        isSlidingUp = true;
        while (isSlidingUp)
        {
            time += Time.deltaTime;
            float tCurve = animCurve.Evaluate(time);
            path = new Vector2(Mathf.Lerp(stopPos.x, stopPos.x, tCurve), Mathf.Lerp(stopPos.y, stopPos.y + 400, tCurve));

            rt.position = new Vector2(path.x, path.y);

            if (rt.position.y == stopPos.y + 400)
            {
                isSlidingUp = false;
                startPos = rt.position;
            }
            yield return null;
        }
        time = 0;
        yield return null;
    }
}

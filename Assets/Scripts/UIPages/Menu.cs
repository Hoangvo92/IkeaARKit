using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button loadMenu1;

    public GameObject menuPage;
    public GameObject listPage;
    public GameObject itemPage;

    public GameObject InputManager;
    public GameObject DataManager;
    public GameObject Marker;
    //public GameObject XRinteraction;
    public GameObject parentObj;

    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        
        itemPage.SetActive(false);
        listPage.SetActive(false);
        InputManager.SetActive(false);
        DataManager.SetActive(false);
        Marker.SetActive(false);
       // XRinteraction.SetActive(false);
        parentObj.SetActive(false);

        loadMenu1.onClick.AddListener(menu);

    }

    // Update is called once per frame
    void Update()
    {

        //loadMenu1.onClick.AddListener(menu);
    }

    public void menu()
    {
        counter++;
        if ((counter % 2) == 1 )
        {
            menuPage.SetActive(true);
            loadMenu1.GetComponentInChildren<Text>().text = "End";
            //counter = 0;
        }
        else
        {
            menuPage.SetActive(false);

            itemPage.SetActive(false);
            listPage.SetActive(false);
            InputManager.SetActive(false);
            DataManager.SetActive(false);
            Marker.SetActive(false);
            //XRinteraction.SetActive(false);
            parentObj.SetActive(false);
            //   counter = 1;
            loadMenu1.GetComponentInChildren<Text>().text = "Begin";

        }

    }

}

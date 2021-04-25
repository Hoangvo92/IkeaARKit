using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICategory : MonoBehaviour
{
    string label;
    public Button ChairB;
    public Button TableB;
    public Button BedB;
    public Button DecorationB;
    public GameObject listPage;
    public GameObject CategoryPage;
    public GameObject DataManager;
    public GameObject InputManager;
//    public Button categoryButton;

    //private static UICategory instance;
    //public static UICategory Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = FindObjectOfType<UICategory>();
    //        }

    //        return instance;
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        ChairB.onClick.AddListener(chooseChair);
        TableB.onClick.AddListener(chooseTable);
        BedB.onClick.AddListener(chooseBed);
        DecorationB.onClick.AddListener(chooseDecoration);

     //   DataHandler.Instance.SetLabel(label);
    }
    public void chooseChair()
    {
        label = "chair";
       
        CategoryPage.SetActive(false);
        listPage.SetActive(true);
        DataManager.SetActive(true);
        InputManager.SetActive(true);
        DataHandler.Instance.SetLabel(label);
        //categoryButton.SetActive(false);


    }

    public void chooseTable()
    {
        label = "table";
        
        CategoryPage.SetActive(false);
        listPage.SetActive(true);
        DataManager.SetActive(true);
        InputManager.SetActive(true);
        DataHandler.Instance.SetLabel(label);


    }

    public void chooseBed()
    {
        label = "bed";
       
        CategoryPage.SetActive(false);
        listPage.SetActive(true);
        DataManager.SetActive(true);
        InputManager.SetActive(true);
        DataHandler.Instance.SetLabel(label);

    }


    public void chooseDecoration()
    {
        label = "decoration";
        
        CategoryPage.SetActive(false);
        listPage.SetActive(true);
        DataManager.SetActive(true);
        InputManager.SetActive(true);
        DataHandler.Instance.SetLabel(label);


    }
    // public string setLabel()
    //{
    //    return label;
    //}

    // Update is called once per frame
    void Update()
    {
        ChairB.onClick.AddListener(chooseChair);
        TableB.onClick.AddListener(chooseTable);
        BedB.onClick.AddListener(chooseBed);
        DecorationB.onClick.AddListener(chooseDecoration);
     //   DataHandler.Instance.SetLabel(label);
    }
}

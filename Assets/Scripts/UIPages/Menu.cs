using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button loadMenu1;
    public Button loadList;
    public Button loadItem;
    public GameObject menuPage;
    public GameObject listPage;
    public GameObject itemPage;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        loadMenu1.onClick.AddListener(menu);
        loadList.onClick.AddListener(itemList);
        loadItem.onClick.AddListener(itemDetail);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void menu()
    {
        counter++;
        if (counter % 2 == 1)
        {
            menuPage.SetActive(true);
        }
        else
        {
            menuPage.SetActive(false);
        }

    }

    public void itemList()
    {
        menuPage.SetActive(false);
        listPage.SetActive(true);

    }

    public void itemDetail()
    {
        listPage.SetActive(false);
        itemPage.SetActive(true);

    }
}

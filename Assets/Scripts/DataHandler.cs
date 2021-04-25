using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;
    private Item itemChosen;

    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items;

    [SerializeField] private string label;

    private int current_id = 0;

    public GameObject listPage;
    public GameObject detailPage;
    public GameObject inputManager;
    public GameObject marker;
    public GameObject XRinteractionManager;
    public GameObject parentObject;

    private static DataHandler instance;

    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }

            return instance;
        }
    }

    private async void Start()
    {
        items = new List<Item>();
        //    LoadItems();
        //label = UICategory.Instance.setLabel();
        //if (label == null || label == "furniture")
        //{
        //    label = UICategory.Instance.setLabel();
        //    if (label == null)
        //    {
        //        label = "furniture";
        //    }
           Debug.Log(label);
        //}
    
       
        await Get(label);
        CreateButtons();

    }

    //void LoadItems()
    //{
    //    var items_obj = Resources.LoadAll("Items", typeof(Item));
    //    foreach (var item in items_obj)
    //    {
    //        items.Add(item as Item); // or items.Add((Item) item);
    //    }

    //}

    void CreateButtons()
    {
        foreach (var i in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = current_id;
            b.ButtonTexture = i.itemImage;
           // b.Description = i.description;
            //b.Price = i.price;
            //b.ButtonName = i.nameItem;
            current_id++;
        }
    }

    public void SetFurniture(int id)
    {
        furniture = items[id].itemPrefab;
        itemChosen = items[id];

        listPage.SetActive(false);
        detailPage.SetActive(true);
        inputManager.SetActive(true);
        marker.SetActive(true);
       // XRinteractionManager.SetActive(true);
        parentObject.SetActive(true);
}

    public void SetLabel(string l)
    {
        label = l;
        Debug.Log(label);
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }

    public Item GetItemDetail()
    {
        return itemChosen;
    }


    public async Task Get(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        foreach (var location in locations)
        {
            var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
            items.Add(obj);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIdetail : MonoBehaviour

{

    public Text nameitem;
    public Text description;
    public Text price;
    public Image itemImage;
    // Start is called before the first frame update
    void Start()
    {



    Item itemS = new Item();
    itemS = DataHandler.Instance.GetItemDetail();
    nameitem.text = itemS.nameItem;
    description.text = itemS.description;
    price.text = "$ " + string.Format("{0:N2}", itemS.price);
    itemImage.sprite = itemS.itemImage;
}

    // Update is called once per frame
    void Update()
    {
        Item itemS = new Item();
        itemS = DataHandler.Instance.GetItemDetail();
        nameitem.text = itemS.nameItem;
        description.text = itemS.description;
        price.text = "$ " + string.Format("{0:N2}", itemS.price);
        itemImage.sprite = itemS.itemImage;
    }
}

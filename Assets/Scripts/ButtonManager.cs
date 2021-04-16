using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{

    private Button btn;
    [SerializeField] private RawImage buttonImage;

  //  public GameObject furniture;

    private int _itemId;
    private Sprite _buttonTexture;
    public Sprite ButtonTexture
    {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }

    public int ItemId
    {
        set{  _itemId = value;}
    }

    public
    //public
//pass the list of links in here, choose number, and instantiate the furniture via asset bundle

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.2f);
           // transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.2f);
            //  transform.localScale = Vector3.one;
        }
    }

    void SelectObject()
    {
        // DataHandler.Instance.furniture = furniture;
        DataHandler.Instance.SetFurniture(_itemId);
    }
}

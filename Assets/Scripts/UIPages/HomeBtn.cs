using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HomeBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;
    public Sprite one;
    public Sprite two;
    private int counter = 0;

    void Start()
    {
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeButton()
    {
        counter++;
        if(counter%2==0)
        {
            btn.image.overrideSprite = one;
        }
        else{
            btn.image.overrideSprite = two;
        }
    }
}

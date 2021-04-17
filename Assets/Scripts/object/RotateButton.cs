using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour
{
    bool isPressed;
    public float rotateSpeed = 180f;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            OnClickLeft();
        }
    }
    //public void TogglePressed(bool value)
    //{
       
    //    isPressed = value;
    //}
    public void clickButton()
    {
        if (isPressed)
        {
            isPressed = false;
        } else
        {
            isPressed = true;
        }
    }
    public void OnClickLeft()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}

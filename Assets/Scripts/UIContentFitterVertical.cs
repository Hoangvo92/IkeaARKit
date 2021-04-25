using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContentFitterVertical : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VerticalLayoutGroup vg = GetComponent<VerticalLayoutGroup>();
        int childCount = transform.childCount - 1;
        float childHeight = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        float height = vg.spacing * childCount + childCount * childHeight + vg.padding.top;

        GetComponent<RectTransform>().sizeDelta = new Vector2( 1000, height);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

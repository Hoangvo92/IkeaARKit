using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.XR.ARSubsystems;

public class InputManager : ARBaseGestureInteractable
{
    //[SerializeField] private GameObject arObj;
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Touch touch;

    public GameObject placedObj;
    public GameObject parentObj;
    public GameObject anchorObject;



    [SerializeField]private GameObject crossHair;
    private Pose pose;
    private Pose secondPose;
   // private RaycastCommand hit;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
       if(gesture.TargetObject == null) { return true; }
       return false;
    }

    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (gesture.WasCancelled) { return; }
        if (gesture.TargetObject != null || IsPointerOverUI(gesture))
        {
            return;
        }
        if(GestureTransformationUtility.Raycast(gesture.startPosition, _hits,
               TrackableType.PlaneWithinPolygon))
        {
            secondPose = pose;
            //if (placedObj != null) { Destroy(placedObj); }
            //// GameObject placedObj = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation) as GameObject;
            //placedObj = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation) as GameObject;
            //parentObj.transform.position = pose.position;
            //parentObj.transform.rotation = pose.rotation;
            //placedObj.transform.parent = parentObj.transform;//to control the created prefab

            //var anchorObject = new GameObject("placementAnchor");
            //anchorObject.transform.position = pose.position;
            //anchorObject.transform.rotation = pose.rotation;
            ////placedObj.transform.parent = anchorObject.transform;
            //parentObj.transform.parent = anchorObject.transform;
        }
    }

    public void pressedButton()
    {
        if (secondPose == null) { return; }
        if (placedObj != null) { Destroy(placedObj); }
        if (anchorObject != null) { Destroy(anchorObject); }
        // GameObject placedObj = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation) as GameObject;
        placedObj = Instantiate(DataHandler.Instance.GetFurniture(), secondPose.position, secondPose.rotation) as GameObject;
        parentObj.transform.position = secondPose.position;
        parentObj.transform.rotation = secondPose.rotation;
        placedObj.transform.parent = parentObj.transform;//to control the created prefab

        anchorObject = new GameObject("placementAnchor");
        anchorObject.transform.position = secondPose.position;
        anchorObject.transform.rotation = secondPose.rotation;
        //placedObj.transform.parent = anchorObject.transform;
        parentObj.transform.parent = anchorObject.transform;
    }

    bool IsPointerOverUI(TapGesture touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
    void CrosshairCalculation()
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
     //   Ray ray = arCam.ScreenPointToRay(origin);

        if (GestureTransformationUtility.Raycast(origin, _hits, TrackableType.PlaneWithinPolygon))
        {
            pose = _hits[0].pose;
            crossHair.transform.position = pose.position;
            crossHair.transform.eulerAngles = new Vector3(90, 0, 0);
        }

    }

    //update is called once per frame
     void FixedUpdate()
    {
        CrosshairCalculation();
    }
}


// Update is called once per frame
//void Update()
//{
//    CrosshairCalculation();
//    touch = Input.GetTouch(0);
//    if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
//    {
//        return;
//    }

//    if (IsPointerOverUI(touch)) return;
//    //Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
//    Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
//}
//-------------------------------

// Ray ray = arCam.ScreenPointToRay(touch.position);
//if (_raycastManager.Raycast(ray, _hits))
// {
//     Pose pose = _hits[0].pose;
//   //Instantiate(arObj, pose.position, pose.rotation);
//   Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
//}
//-------------------------------------

//   if (Input.GetMouseButtonDown(0))
//   {
//       Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
//       if (_raycastManager.Raycast(ray, _hits))
//      {
//          Pose pose = _hits[0].pose;
//         //Instantiate(arObj, pose.position, pose.rotation);
//         Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
//     }
//   }
//}

//bool IsPointerOverUI(Touch touch)
//{
//    PointerEventData eventData = new PointerEventData(EventSystem.current);
//    eventData.position = new Vector2(touch.position.x, touch.position.y);
//    List<RaycastResult> results = new List<RaycastResult>();
//    EventSystem.current.RaycastAll(eventData, results);
//    return results.Count > 0;
//}

//void CrosshairCalculation()
//{
//    Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
//    Ray ray = arCam.ScreenPointToRay(origin);

//    if (_raycastManager.Raycast(ray, _hits))
//    {
//         pose = _hits[0].pose;
//        crossHair.transform.position = pose.position;
//        crossHair.transform.eulerAngles = new Vector3(90, 0, 0);
//    }
//    else if (Physics.Raycast(ray, out hit))
//    {
//        crossHair.transform.position = hit.point;
//        crossHair.transform.up = hit.normal;
//    }
//}
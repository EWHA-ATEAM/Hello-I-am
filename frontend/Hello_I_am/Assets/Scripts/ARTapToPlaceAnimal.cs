using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]


public class ARTapToPlaceAnimal : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject AnimalAR;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(_arRaycastManager.Raycast(touchPosition,hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;


            if(AnimalAR == null)
            {
                AnimalAR = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
            }
            /* 이미 화면에 동물 AR이 있는 경우엔 터치하더라도 아무런 일이 일어나지 않음
            else
            {
                AnimalAR.transform.position = hitPose.position;
            }
            */
        }
    }
}

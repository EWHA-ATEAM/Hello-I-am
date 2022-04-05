using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]


public class ARTapToPlaceAnimal : MonoBehaviour
{
    public GameObject[] gameObjectToInstantiate;
    public ARPlaneManager arPlaneManager;
    public GameObject startUI;
    public GameObject basicUI;

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
            var hitRotation = hitPose.rotation.eulerAngles;
            hitRotation.y += 180;

            if (AnimalAR == null)
            {
                AnimalAR = Instantiate(gameObjectToInstantiate[AppManager.instance.animal_index], hitPose.position, Quaternion.Euler(hitRotation));
                startUI.SetActive(false);
                basicUI.SetActive(true);

                arPlaneManager.planePrefab = null; // 새로운 면 안 생김
            }
            /* 이미 화면에 동물 AR이 있는 경우엔 instance 만드는 것을 멈춤 */
            else
            {
                foreach (var plane in arPlaneManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
            }
        }
    }
}

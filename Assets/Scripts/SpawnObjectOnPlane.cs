using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SpawnObjectOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnedObj;

    [SerializeField]
    public GameObject PlaceablePrefab;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public void Awake(){
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition){
        if(Input.touchCount > 0){
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition)){
            return;
        }
        if(raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon)){
            var hitPose = s_Hits[0].pose;
            if(spawnedObj == null){
                spawnedObj = Instantiate(PlaceablePrefab, hitPose.position, hitPose.rotation);
            }
            else{
                spawnedObj.transform.position = hitPose.position;
                spawnedObj.transform.rotation = hitPose.rotation;
            }
        }
        Debug.Log("Coin position --> " +  spawnedObj.transform.position.ToString());
    }
}

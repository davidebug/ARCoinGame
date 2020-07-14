using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ScanAndSpawnHandler : MonoBehaviour
{

    [SerializeField]
    private ARPlaneManager aRPlaneManager;

    private ARRaycastManager raycastManager;
    private GameObject spawnedObj;

    [SerializeField]
    public GameObject PlaceablePrefab;


    void Update()
    {
        Debug.Log("Coin position --> " + spawnedObj.transform.position.ToString());
    }


    void Awake()
    {
        GameStateKeeper.getInstance().setGameState(GameStateKeeper.GameState.Welcome);
        raycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = aRPlaneManager.GetComponent<ARPlaneManager>();
        aRPlaneManager.enabled = false;
    }


    Vector3 CalculateNextPosition()
    {
        List<Vector3> possiblePositions = new List<Vector3>();
        Debug.Log("COIN - Trackable Planes found: " + aRPlaneManager.trackables.count.ToString());
        foreach (ARPlane plane in aRPlaneManager.trackables)
        {
            Debug.Log("COIN - Plane Rand");
            Vector3 min = plane.gameObject.GetComponent<MeshFilter>().mesh.bounds.min;
            Vector3 max = plane.gameObject.GetComponent<MeshFilter>().mesh.bounds.max;
            Debug.Log("COIN - MIN Plane Bound --> " + min.ToString());
            Debug.Log("COIN - MAX Plane Bound --> " + max.ToString());
            Debug.Log(plane.gameObject.transform.position.y);
            Vector3 position = plane.gameObject.transform.position - new Vector3((Random.Range(min.x*0.98f, max.x*0.98f)), plane.gameObject.transform.position.y * 0.02f, (Random.Range(min.z*0.98f, max.z*0.98f)));
            possiblePositions.Add(position);
        }
        if (possiblePositions.Count == 0)
        {
            Debug.Log("COIN - No possible positions found");
            return new Vector3(0, 0, 0);
        }
        int r = Random.Range(0, possiblePositions.Count);
        return possiblePositions[r];

    }


    public void TogglePlaneDetection()
    {
        GameStateKeeper.getInstance().setGameState(GameStateKeeper.GameState.Scanning);
        aRPlaneManager.enabled = !aRPlaneManager.enabled;
        foreach (ARPlane plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive(aRPlaneManager.enabled);
        }

    }

    public void StartPlaying()
    {
        GameStateKeeper.getInstance().setGameState(GameStateKeeper.GameState.Playing);
        spawnedObj = Instantiate(PlaceablePrefab, CalculateNextPosition(), Quaternion.identity);

    }

}

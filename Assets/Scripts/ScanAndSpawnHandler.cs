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
    private Text planeLevel;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    public GameObject PlaceablePrefab;


    void Update()
    {
        if (spawnedObj != null)
            Debug.Log("Coin position --> " + spawnedObj.transform.position.ToString());

        if(GameStateKeeper.getInstance().getGameState() == GameStateKeeper.GameState.Scanning)    
            foreach (ARPlane plane in aRPlaneManager.trackables)
            {

                Vector3 min = plane.gameObject.GetComponent<MeshFilter>().mesh.bounds.min;
                Vector3 max = plane.gameObject.GetComponent<MeshFilter>().mesh.bounds.max;

                if (max.x > 1.8 && max.z > 1.8 && planeLevel.text == "Area Livello 1")
                {
                    planeLevel.text = "Area Livello 2";
                    planeLevel.color = Color.cyan;
                }
                if (max.x > 2.3  && max.z > 2.3 && planeLevel.text == "Area Livello 2")
                {
                    planeLevel.text = "Area Livello 3";
                    planeLevel.color = Color.blue;
                }
                if (max.x > 3 && max.z > 3 && planeLevel.text == "Area Livello 3")
                {
                    planeLevel.text = "Area Livello 4";
                    planeLevel.color = Color.magenta;
                }
                if (max.x > 3.5 && max.z > 3.5 && planeLevel.text == "Area Livello 4")
                {
                    planeLevel.text = "Area Livello 5";
                    planeLevel.color = Color.red;
                }
            }
    }


    void Awake()
    {
        planeLevel.text = "Area Livello 1";
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
            Vector3 position = plane.gameObject.transform.position - new Vector3((Random.Range(min.x * 0.90f, max.x * 0.90f)), plane.gameObject.transform.position.y * 0.02f, (Random.Range(min.z * 0.90f, max.z * 0.90f)));
            if(Vector3.Distance(player.transform.position, position) > 0.1)
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
        if(GameStateKeeper.getInstance().getGameState() != GameStateKeeper.GameState.Scanning)
            GameStateKeeper.getInstance().setGameState(GameStateKeeper.GameState.Scanning);
        else{
             GameStateKeeper.getInstance().setGameState(GameStateKeeper.GameState.Playing);
        }
        aRPlaneManager.enabled = !aRPlaneManager.enabled;
        foreach (ARPlane plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive(aRPlaneManager.enabled);
        }

    }

    public void StartPlaying()
    {
        GameStateKeeper.getInstance().setGameState(GameStateKeeper.GameState.Playing);
        Vector3 position = CalculateNextPosition();
        if (!position.Equals(new Vector3(0, 0, 0)))
        {
            spawnedObj = Instantiate(PlaceablePrefab, position, Quaternion.identity);
            position = CalculateNextPosition();
            spawnedObj = Instantiate(PlaceablePrefab, position, Quaternion.identity);
        }

    }

}

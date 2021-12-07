using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    // Create containers for the dimensions of the Spawner cube
    public Vector3 centre;
    public Vector3 size;
    public GameObject spherePrefab;
    // Create counters for time and number of spheres, as well as initialising a respawn time
    public float timeKeeper = 0.0f;
    private float hazardRespawnTime = 1.0f;
    private int sphereCount = 0;
    public bool hazard;
    public bool spawnerActive;
    private bool hazardOneSpawned;
    private bool hazardTwoSpawned;
    private bool hazardThreeSpawned;
    public bool GameRunning = false;

    //Initialise Onsets and Offsets - Has to be set in the Unity Editor - High values are to stop CheckSpawn() comparing to 0
    [SerializeField] private float hazardOneOnset = 1000000f;
    [SerializeField] private float hazardOneOffset = 1000000f;

    [SerializeField] private float hazardTwoOnset = 1000000f;
    [SerializeField] private float hazardTwoOffset = 1000000f;

    [SerializeField] private float hazardThreeOnset = 1000000f;
    [SerializeField] private float hazardThreeOffset = 1000000f;

    // Start is called before the first frame update
    void Start()
    {
        spawnerActive = false;
        hazard = false;
        hazardOneSpawned = false;
        hazardTwoSpawned = false;
        hazardThreeSpawned = false;
        GameRunning = true;

        //Define Onsets and Offsets here
        /* hazardOneOnset = **;
         hazardOneOffset = **;

         hazardTwoOnset = **;
         hazardTwoOffset = **;

         hazardThreeOnset = **;
         hazardThreeOffset = **;
         */
    }

    // Update is called once per frame
    void Update()
    {
        // Reset the respawn time to a random number within range ( smaller range for hazard spheres to increase spawn rate)
        if (GameRunning == true)
        {
            timeKeeper += Time.deltaTime;
            CheckSpawn();
            CheckHazard();
        }
    }

    public void CheckHazard()
    {
        if (hazard == false)
        {
            if (timeKeeper >= hazardOneOnset && timeKeeper <= hazardOneOffset)
            {
                hazard = true;
            }
            if (timeKeeper >= hazardTwoOnset && timeKeeper <= hazardTwoOffset)
            {
                hazard = true;
            }
            if (timeKeeper >= hazardThreeOnset && timeKeeper <= hazardThreeOffset)
            {
                hazard = true;
            }
        }
        else if (hazard == true)
        {
            if (timeKeeper >= hazardOneOffset && timeKeeper <= hazardTwoOnset)
            {
                hazard = false;
            }
            if (timeKeeper >= hazardTwoOffset && timeKeeper <= hazardThreeOnset)
            {
                hazard = false;
            }
            if (timeKeeper >= hazardThreeOffset)
            {
                hazard = false;
            }
        }
    }



    // Function to check whether the Spawner should be active or not, as well as time windows for when hazard spheres should spawn.

    //Currently hard coded but needs a more elegant solution!!//
    public void CheckSpawn()
    {
        if (spawnerActive == false && hazard == true)
        {
            if (hazardOneSpawned == false)
            {
                if (timeKeeper >= hazardOneOnset && timeKeeper <= hazardOneOffset)
                {
                    spawnerActive = true;
                    hazardStart();
                    hazardOneSpawned = true;
                }
            }
            if (hazardTwoSpawned == false)
            {
                if (timeKeeper >= hazardTwoOnset && timeKeeper <= hazardTwoOffset)
                {
                    spawnerActive = true;
                    hazardStart();
                    hazardTwoSpawned = true;
                }
            }
            if (hazardThreeSpawned == false)
            {
                if (timeKeeper >= hazardThreeOnset && timeKeeper <= hazardThreeOffset)
                {
                    spawnerActive = true;
                    hazardStart();
                    hazardThreeSpawned = true;
                }
            }
        }
        else if (spawnerActive == true)
        {
            if (timeKeeper >= hazardOneOffset)
            {
                spawnerActive = false;
                hazardStop();
            }
            if (timeKeeper >= hazardTwoOffset)
            {
                spawnerActive = false;
                hazardStop();
            }
            if (timeKeeper >= hazardThreeOffset)
            {
                spawnerActive = false;
                hazardStop();
            }
        }
    }

    private void hazardStart()
    {
        StartCoroutine(SpawnHazardSphere(spawnerActive));
    }

    private void hazardStop()
    {
        //Doesn't work with the StopCoroutine function
        //StopCoroutine(SpawnHazardSphere(spawnerActive));
        StopAllCoroutines();
    }

    // Create a Coroutine to create spheres within the spawn area
    private IEnumerator SpawnHazardSphere(bool spawnerActive)
    {
        while (spawnerActive == true)
        //while (enabled) 
        {
            // Create a new Vector 3 position that falls within the confines of the spawn area (Range is double the size of the spawn area, so need to halve it to maintain correct ratios)
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            //Debug.Log(pos);
            // Create an object with these properties
            GameObject alpha = Instantiate(spherePrefab, pos, Quaternion.identity);
            sphereCount++;
            Debug.Log(spherePrefab.ToString() + " spawned: " + sphereCount);
            // Wait for the amount of time within the respawn range
            yield return new WaitForSeconds(hazardRespawnTime);
        }
        if (spawnerActive == false)
        {
            yield return null;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualise the spawn cubes in the Scene when clicked on (Colour and dimensions)
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centre, size);
    }

}

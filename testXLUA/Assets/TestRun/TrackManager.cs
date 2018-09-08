using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour {

	// Use this for initialization

    float timeAccumulated = 0.0f;
    float spawnTimeGap = 3.0f;

    List<Track> trackList = new List<Track>();

    public Transform outBorderPoint;
    public Transform spawnPoint;

    public Track[] track0Prefabs;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeAccumulated += Time.deltaTime;
        if (timeAccumulated >= spawnTimeGap)
        {
            timeAccumulated -= spawnTimeGap;
            this.SpawnTrack();
        }

        this.OutBorderDetect();


	}

    public void OutBorderDetect()
    {
        if(trackList.Count>0&&trackList[0].transform.position.z<outBorderPoint.position.z)
        {
            Destroy(trackList[0].gameObject);
            trackList.RemoveAt(0);
        }

    }



    void SpawnTrack()
    {
        int randomNum=Random.Range(0, track0Prefabs.Length);
        Track trackPrefab = track0Prefabs[randomNum];
        Track trackObj = Instantiate(trackPrefab);

        trackObj.transform.position = spawnPoint.position;

        //trackObj.transform.position -= trackObj.headObj.transform.localPosition;

        Vector3 trackPosition = trackObj.transform.position;
        float y = trackObj.headObj.transform.position.y - trackPosition.y;
        Debug.Log("the y"+y);
        trackPosition.y -= y;

        trackObj.transform.position = trackPosition;

        trackList.Add(trackObj);
    }





}

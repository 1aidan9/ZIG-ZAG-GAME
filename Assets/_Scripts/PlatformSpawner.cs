﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;
    Vector3 lastPosition; 
    float size; 

	
	void Start () {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x; 	

        for (int i = 0; i < 20; i++) 
            SpawnPlatform();
	}
	
	
	void Update () {
        if (GameManager.instance.gameOver)
            CancelInvoke("SpawnPlatform");
        
	}
    
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f); 
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6); 
        if (rand < 3)
            SpawnX();
        else if (rand >= 3)
            SpawnZ();
    }

    void SpawnX() 
    {
        Vector3 pos = lastPosition;
        pos.x += size; 
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;

        SpawnDiamond(pos);
    }

    void SpawnZ() 
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;

        SpawnDiamond(pos);
    }

    public void SpawnDiamond(Vector3 pos)
    {
        int rand = Random.Range(0, 4);

        if (rand < 1)
        {
            GameObject spawnDiamond = Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
            StartCoroutine(RotateDiamond(spawnDiamond));
        }
    }
   

    IEnumerator RotateDiamond(GameObject spawnDiamond)
    {
        while (true)
        {
            spawnDiamond.transform.Rotate(Vector3.one * Time.deltaTime * 50f);
            yield return new WaitForEndOfFrame();
        }

    }
    


}

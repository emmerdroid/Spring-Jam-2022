﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
  
        public GameObject[] wallType;
        GameObject wall;
        public int numofWalls = 0;
        public int maxWalls;
        private float radius = 1f; //Radius of object to spawn

        void Start()
        {
            StartCoroutine(SpawnObjects());
        }


        IEnumerator SpawnObjects()
        {
           while (numofWalls < maxWalls)
            {
            wall = wallType[Random.Range(0, 2)];

            Vector3 spawnPos = new Vector3(Random.Range(0.0f, 5.0f), 1.0f, Random.Range(0.0f, 5.0f));
                //Check collisions
                if (DetectCollisions(spawnPos) > 0)
                    continue;

                Instantiate(wall, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(1.0f);
                numofWalls++;
            }
        }

        private int DetectCollisions(Vector3 pos)
        {
            Collider[] hitColliders = Physics.OverlapSphere(pos, radius);
            return hitColliders.Length;
        }

   
}



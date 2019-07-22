using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGen
{
    public class InteriorSpawner : MonoBehaviour
    {
        private DungeonGenerator dungeon;
        void OnEnable(){

			dungeon = DungeonGenerator.instance;
            EventManager.OnBossPortal+= OnSpawnInterior;
        }
        void OnDisable()
        {
            EventManager.OnBossPortal -= OnSpawnInterior;
        }

        void OnSpawnInterior(){
            Invoke("SpawnInterior", 0.2f);
        }

        void OnTriggerEnter(Collider other){			
			if(other.CompareTag("BossRoom")){
				Destroy(gameObject);
			}
		}
        void SpawnInterior()
        {
            int rand = Random.Range(0, dungeon.interiors.Length);
            GameObject roomToSpawn = dungeon.interiors[rand];
            GameObject spawnedRoom = Instantiate(roomToSpawn, transform.position, Quaternion.identity);
            spawnedRoom.transform.parent = transform.parent;
            Destroy(gameObject, dungeon.waitTime/2);
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGen
{
    public class Playerspawner : MonoBehaviour
    {
        private DungeonGenerator dungeon;
        void OnEnable(){

			dungeon = DungeonGenerator.instance;
            EventManager.OnBossPortal+= OnSpawnPlayer;
        }
        void OnDisable()
        {
            EventManager.OnBossPortal -= OnSpawnPlayer;
        }
        void OnSpawnPlayer(){
            Invoke("SpawnPlayer", 0.2f);
        }

        void SpawnPlayer()
        {
            GameObject playerPrefab = dungeon.playerPrefab;
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject, dungeon.waitTime/2);
        }
    }
 
}


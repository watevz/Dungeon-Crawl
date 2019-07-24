using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGen
{
    public class BossRoomSpawner : MonoBehaviour
    {
         public DungeonGenerator dungeon;
        void Start(){
			dungeon = DungeonGenerator.instance;
            EventManager.OnBossPortal+= OnSpawnBossRoom;
        }
        void OnDisable()
        {
            EventManager.OnBossPortal -= OnSpawnBossRoom;
        }

        void OnSpawnBossRoom(){
            Spawn();
        }

        void Spawn(){
            int rand = Random.Range(0, dungeon.bossRooms.Length);
			GameObject bossRoom = dungeon.bossRooms[rand];
			GameObject roomToAdd = Instantiate(bossRoom, transform.position, bossRoom.transform.rotation);
            //Destroy(gameObject);
        }
    }    
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGen
{
	public class RoomSpawner : MonoBehaviour {
		public DoorDirection openingDoorDirection;
		private DungeonGenerator dungeon;
		private int rand;
		private GameObject randomRoom;
		private GameObject roomToAdd;
		[HideInInspector]
		public bool spawned = false;
		private float waitTime;

		void Start(){
			dungeon = DungeonGenerator.instance;
			waitTime = 5f;
			Destroy(gameObject, waitTime);
			
			if(spawned==false){
				Invoke("Spawn", 0.1f);
			}
			
		}

		 void Spawn(){
			if(dungeon.rooms.Count < dungeon.maxRooms){
				if(spawned == false){
					if(openingDoorDirection == DoorDirection.bottom){
						// Need to spawn a room with a BOTTOM door.
						rand = Random.Range(0, dungeon.upRooms.Length);
						randomRoom = dungeon.upRooms[rand];
						roomToAdd = Instantiate(randomRoom, transform.position, randomRoom.transform.rotation);
						dungeon.rooms.Add(roomToAdd.gameObject);
					} else if(openingDoorDirection == DoorDirection.top){
						// Need to spawn a room with a TOP door.
						rand = Random.Range(0, dungeon.downRooms.Length);
						randomRoom = dungeon.downRooms[rand];
						roomToAdd = Instantiate(randomRoom, transform.position, randomRoom.transform.rotation);
						dungeon.rooms.Add(roomToAdd.gameObject);
					} else if(openingDoorDirection == DoorDirection.left){
						// Need to spawn a room with a LEFT door.
						rand = Random.Range(0, dungeon.rightRooms.Length);
						randomRoom = dungeon.rightRooms[rand];
						roomToAdd = Instantiate(randomRoom, transform.position, randomRoom.transform.rotation);
						dungeon.rooms.Add(roomToAdd.gameObject);
					} else if(openingDoorDirection == DoorDirection.right){
						// Need to spawn a room with a RIGHT door.
						rand = Random.Range(0, dungeon.leftRooms.Length);
						randomRoom = dungeon.leftRooms[rand];
						roomToAdd = Instantiate(randomRoom, transform.position, randomRoom.transform.rotation);
						dungeon.rooms.Add(roomToAdd.gameObject);
					}
					roomToAdd.transform.parent = dungeon.transform;
					spawned = true;
				}
			}
			else
			{
				roomToAdd = Instantiate(dungeon.closedRoom, transform.position, Quaternion.identity);
				roomToAdd.transform.parent = dungeon.transform;
				Destroy(gameObject);
				spawned = true;
			}
		}

		void OnTriggerEnter(Collider other){
			if(other.CompareTag("Room")){
				Destroy(gameObject);
				spawned = true;
			}
			else if(other.CompareTag("RoomSpawnPoint")){
				if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
					spawned = true;
				} 
				
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGen
{
    public class DungeonGenerator : MonoBehaviour
    {
        #region singleton
        public static DungeonGenerator instance;

        void Awake()
        {
            if (instance != null)
                Debug.LogWarning("more than one DungeonGenerator instance");

            instance = this;


        }

        #endregion
        
        //variables
        public GameObject startRoomPrefab;

        public GameObject[] bossRooms;
        public GameObject[] upRooms;
        public GameObject[] downRooms;
        public GameObject[] rightRooms;
        public GameObject[] leftRooms;
        public GameObject closedRoom;
        public GameObject[] interiors;
        public int maxRooms = 5;
        public GameObject bossPortalPrefab;

        public GameObject bossPortalEntrance;    
        public float waitTime;
        public GameObject playerPrefab;

        [HideInInspector]
        public List<GameObject> rooms;


        private bool spawnedBoss;

        //events



        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            Instantiate(startRoomPrefab, transform.position, Quaternion.identity);
        }

        void Update(){

            if(waitTime <= 0 && spawnedBoss == false){
                for (int i = 0; i < rooms.Count; i++) {
                    if(i == rooms.Count-1){
                        GameObject bossPortal = Instantiate(bossPortalPrefab, rooms[i].transform.position, Quaternion.identity);
                        bossPortalEntrance.transform.position = bossPortal.transform.position;
                        spawnedBoss = true;
                        EventManager.OnBossPortalSpawned();
                        NavigationBaker.GenerateNavMesh();
                    }
                }
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }

}

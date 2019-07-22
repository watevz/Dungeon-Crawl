using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
        public delegate void BossPortalSpawnAction();
        public static event BossPortalSpawnAction OnBossPortal;

        public static void OnBossPortalSpawned(){
            OnBossPortal();
        }
}

using UnityEngine;

namespace UntilTheEnd
{
    [System.Serializable]
    public class AvatarModel
    {
        public GameObject avatarModel;
        public GameObject[] clothes;
        public GameObject[] weapons;

        // 각 장비의 현재 인덱스를 저장
        [HideInInspector] public int currentClothesIndex = 0;
        [HideInInspector] public int currentWeaponsIndex = 0;
    }
}
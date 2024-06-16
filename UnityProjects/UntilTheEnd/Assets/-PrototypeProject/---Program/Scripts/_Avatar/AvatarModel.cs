using UnityEngine;

namespace UntilTheEnd
{
    [System.Serializable]
    public class AvatarModel
    {
        public GameObject avatarModel;
        public GameObject[] clothes;
        public GameObject[] weapons;

        // �� ����� ���� �ε����� ����
        [HideInInspector] public int currentClothesIndex = 0;
        [HideInInspector] public int currentWeaponsIndex = 0;
    }
}
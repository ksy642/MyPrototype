using UnityEngine;

namespace UntilTheEnd
{
    public class UIAvatar : MonoBehaviour
    {
        public AvatarModel[] avatarModels;

        private int _currentCharacterIndex = 0;

        public void StartAvatarCostume() // ù��° ���� ���� ����Ǹ鼭 ������ �����
        {
            avatarModels[0].avatarModel.SetActive(true);
        }

        #region ��ưŬ��
        public void OnClickChange_Character(bool isForward)
        {
            // 1. ���� ���� ��Ȱ��ȭ
            avatarModels[_currentCharacterIndex].avatarModel.SetActive(false);

            // 2. ���� �𵨷� ����
            _currentCharacterIndex = isForward
                ? (_currentCharacterIndex + 1) % avatarModels.Length
                : (_currentCharacterIndex - 1 + avatarModels.Length) % avatarModels.Length;

            // 3. ���ο� ���� Ȱ��ȭ
            avatarModels[_currentCharacterIndex].avatarModel.SetActive(true);
        }

        public void OnClickChange_Cloth(bool isForward)
        {
            int currentIndex = avatarModels[_currentCharacterIndex].currentClothesIndex;

            if (isForward)
            {
                currentIndex = (currentIndex + 1) % avatarModels[_currentCharacterIndex].clothes.Length;
            }
            else
            {
                currentIndex = (currentIndex - 1 + avatarModels[_currentCharacterIndex].clothes.Length) % avatarModels[_currentCharacterIndex].clothes.Length;
            }

            _ChangeAccessory(avatarModels[_currentCharacterIndex].clothes, ref avatarModels[_currentCharacterIndex].currentClothesIndex, isForward);
        }

        public void OnClickChange_Weapon(bool isForward)
        {
            int currentIndex = avatarModels[_currentCharacterIndex].currentWeaponsIndex;

            if (isForward)
            {
                currentIndex = (currentIndex + 1) % avatarModels[_currentCharacterIndex].weapons.Length;
            }
            else
            {
                currentIndex = (currentIndex - 1 + avatarModels[_currentCharacterIndex].weapons.Length) % avatarModels[_currentCharacterIndex].weapons.Length;
            }

            _ChangeAccessory(avatarModels[_currentCharacterIndex].weapons, ref avatarModels[_currentCharacterIndex].currentWeaponsIndex, isForward);
        }

        private void _ChangeAccessory(GameObject[] accessories, ref int currentIndex, bool isForward)
        {
            // ���� ���� ��Ȱ��ȭ
            if (accessories == null || accessories.Length == 0)
            {
                Debug.Log("�Ǽ������� �����ϴ�...");
                return;
            }

            // ���� �Ǽ����� ��Ȱ��ȭ
            if (currentIndex >= 0 && currentIndex < accessories.Length)
            {
                accessories[currentIndex].SetActive(false);
            }

            // ���� �ε��� ������Ʈ
            currentIndex = isForward
                ? (currentIndex + 1) % accessories.Length
                : (currentIndex - 1 + accessories.Length) % accessories.Length;

            accessories[currentIndex].SetActive(true); // ���� �Ǽ����� Ȱ��ȭ
        }

        // DataManager�� �����ؼ� �ΰ������� �Ѱ��ָ� �ɵ��ѵ�?
        public void OnClickSaveCharacterInformation()
        {
            AvatarModel currentAvatar = avatarModels[_currentCharacterIndex];

            int Index_clothes = currentAvatar.currentClothesIndex;
            int Index_weapons = currentAvatar.currentWeaponsIndex;

            Debug.Log("��ȣ�� �����ּ��� :: " + currentAvatar.avatarModel.name + Index_clothes + Index_weapons);


            // �ش� ���� �����ϰ� �� �Ѿ�� �����ϴ°�
            LoadingSceneScript.LoadScene(StringValues.Scene.login);
        }
        #endregion
    }
}

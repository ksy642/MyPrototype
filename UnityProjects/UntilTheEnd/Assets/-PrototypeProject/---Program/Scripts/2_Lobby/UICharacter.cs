using UnityEngine;

namespace UntilTheEnd
{
    public class UICharacter : MonoBehaviour
    {
        public CharacterModel[] characterModels;

        private int _currentCharacterIndex = 0;

        public void StartAvatarCostume() // ù��° ���� ���� ����Ǹ鼭 ������ �����
        {
            characterModels[0].model.SetActive(true);
        }

        #region ��ưŬ��
        public void OnClickChange_Character(bool isForward)
        {
            // 1. ���� ���� ��Ȱ��ȭ
            characterModels[_currentCharacterIndex].model.SetActive(false);

            // 2. ���� �𵨷� ����
            _currentCharacterIndex = isForward
                ? (_currentCharacterIndex + 1) % characterModels.Length
                : (_currentCharacterIndex - 1 + characterModels.Length) % characterModels.Length;

            // 3. ���ο� ���� Ȱ��ȭ
            characterModels[_currentCharacterIndex].model.SetActive(true);
        }

        public void OnClickChange_Hat(bool isForward)
        {
            int currentIndex = characterModels[_currentCharacterIndex].currentHatsIndex;

            if (isForward)
            {
                currentIndex = (currentIndex + 1) % characterModels[_currentCharacterIndex].hats.Length;
            }
            else
            {
                currentIndex = (currentIndex - 1 + characterModels[_currentCharacterIndex].hats.Length) % characterModels[_currentCharacterIndex].hats.Length;
            }

            _ChangeAccessory(characterModels[_currentCharacterIndex].hats, ref characterModels[_currentCharacterIndex].currentHatsIndex, isForward);
        }

        public void OnClickChange_Cloth(bool isForward)
        {
            int currentIndex = characterModels[_currentCharacterIndex].currentclothesIndex;

            if (isForward)
            {
                currentIndex = (currentIndex + 1) % characterModels[_currentCharacterIndex].clothes.Length;
            }
            else
            {
                currentIndex = (currentIndex - 1 + characterModels[_currentCharacterIndex].clothes.Length) % characterModels[_currentCharacterIndex].clothes.Length;
            }

            _ChangeAccessory(characterModels[_currentCharacterIndex].clothes, ref characterModels[_currentCharacterIndex].currentclothesIndex, isForward);
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
            CharacterModel currentAvatar = characterModels[_currentCharacterIndex];

            int Index_hats = currentAvatar.currentHatsIndex;
            int Index_clothes = currentAvatar.currentclothesIndex;

            Debug.Log("��ȣ�� �����ּ��� :: " + currentAvatar.model.name + Index_hats + Index_clothes);


            // �ش� ���� �����ϰ� �� �Ѿ�� �����ϴ°�
            Loading.LoadScene(StringValues.Scene.login);
        }
    }
    #endregion
}


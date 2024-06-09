using UnityEngine;

namespace UntilTheEnd
{
    public class UICharacter : MonoBehaviour
    {
        public CharacterModel[] characterModels;

        private int _currentCharacterIndex = 0;

        public void StartAvatarCostume() // 첫번째 모델은 씬이 실행되면서 켜지게 만들기
        {
            characterModels[0].model.SetActive(true);
        }

        #region 버튼클릭
        public void OnClickChange_Character(bool isForward)
        {
            // 1. 현재 모델을 비활성화
            characterModels[_currentCharacterIndex].model.SetActive(false);

            // 2. 다음 모델로 변경
            _currentCharacterIndex = isForward
                ? (_currentCharacterIndex + 1) % characterModels.Length
                : (_currentCharacterIndex - 1 + characterModels.Length) % characterModels.Length;

            // 3. 새로운 모델을 활성화
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
            // 현재 가방 비활성화
            if (accessories == null || accessories.Length == 0)
            {
                Debug.Log("악세서리가 없습니다...");
                return;
            }

            // 현재 악세서리 비활성화
            if (currentIndex >= 0 && currentIndex < accessories.Length)
            {
                accessories[currentIndex].SetActive(false);
            }

            // 다음 인덱스 업데이트
            currentIndex = isForward
                ? (currentIndex + 1) % accessories.Length
                : (currentIndex - 1 + accessories.Length) % accessories.Length;

            accessories[currentIndex].SetActive(true); // 다음 악세서리 활성화
        }

        // DataManager에 저장해서 인게임으로 넘겨주면 될듯한데?
        public void OnClickSaveCharacterInformation()
        {
            CharacterModel currentAvatar = characterModels[_currentCharacterIndex];

            int Index_hats = currentAvatar.currentHatsIndex;
            int Index_clothes = currentAvatar.currentclothesIndex;

            Debug.Log("번호를 적어주세요 :: " + currentAvatar.model.name + Index_hats + Index_clothes);


            // 해당 정보 저장하고 씬 넘어가게 설정하는곳
            Loading.LoadScene(StringValues.Scene.login);
        }
    }
    #endregion
}


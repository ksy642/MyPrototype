using UnityEngine;

namespace UntilTheEnd
{
    public class UIAvatar : MonoBehaviour
    {
        public AvatarModel[] avatarModels;

        private int _currentCharacterIndex = 0;

        public void StartAvatarCostume() // 첫번째 모델은 씬이 실행되면서 켜지게 만들기
        {
            avatarModels[0].avatarModel.SetActive(true);
        }

        #region 버튼클릭
        public void OnClickChange_Character(bool isForward)
        {
            // 1. 현재 모델을 비활성화
            avatarModels[_currentCharacterIndex].avatarModel.SetActive(false);

            // 2. 다음 모델로 변경
            _currentCharacterIndex = isForward
                ? (_currentCharacterIndex + 1) % avatarModels.Length
                : (_currentCharacterIndex - 1 + avatarModels.Length) % avatarModels.Length;

            // 3. 새로운 모델을 활성화
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
            AvatarModel currentAvatar = avatarModels[_currentCharacterIndex];

            int Index_clothes = currentAvatar.currentClothesIndex;
            int Index_weapons = currentAvatar.currentWeaponsIndex;

            Debug.Log("번호를 적어주세요 :: " + currentAvatar.avatarModel.name + Index_clothes + Index_weapons);


            // 해당 정보 저장하고 씬 넘어가게 설정하는곳
            LoadingSceneScript.LoadScene(StringValues.Scene.login);
        }
        #endregion
    }
}

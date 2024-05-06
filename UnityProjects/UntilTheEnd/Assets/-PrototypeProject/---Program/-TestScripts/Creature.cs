using UnityEngine;

namespace UntilTheEnd
{
    // 크리처 안에 들어있는 오브젝트
    // 크리처들 소환은 DreamManager에서 하는건가?
    public class Creature : MonoBehaviour
    {
        void Start()
        {

        }

        // Update함수에서 작동시킬껀 아님...일단 테스트용
        void Update()
        {
            if (DreamManager.instance.playerCamera.gameObject.layer == LayerMask.NameToLayer("Dream"))
            {
                // 플레이어 타겟으로 추적
            }
            else if (DreamManager.instance.playerCamera.gameObject.layer == LayerMask.NameToLayer("Awake"))
            {
                // 디스트로이 말고 애니메이션으로 타들어가서 잿더미 되는 식으로 구현 ok
                // 마지막에 잿더미 다 되면 어떻게 제거할지 고민도 해야함 = Destroy ?? 
                Destroy(gameObject);
            }
        }
    }
}
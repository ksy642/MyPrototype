using UnityEngine;

namespace UntilTheEnd
{
    // ũ��ó �ȿ� ����ִ� ������Ʈ
    // ũ��ó�� ��ȯ�� DreamManager���� �ϴ°ǰ�?
    public class Creature : MonoBehaviour
    {
        void Start()
        {

        }

        // Update�Լ����� �۵���ų�� �ƴ�...�ϴ� �׽�Ʈ��
        void Update()
        {
            if (DreamManager.instance.playerCamera.gameObject.layer == LayerMask.NameToLayer("Dream"))
            {
                // �÷��̾� Ÿ������ ����
            }
            else if (DreamManager.instance.playerCamera.gameObject.layer == LayerMask.NameToLayer("Awake"))
            {
                // ��Ʈ���� ���� �ִϸ��̼����� Ÿ���� ����� �Ǵ� ������ ���� ok
                // �������� ����� �� �Ǹ� ��� �������� ��ε� �ؾ��� = Destroy ?? 
                Destroy(gameObject);
            }
        }
    }
}
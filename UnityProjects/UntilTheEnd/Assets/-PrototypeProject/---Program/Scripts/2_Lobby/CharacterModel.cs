using UnityEngine;

[System.Serializable]
public class CharacterModel
{
    public GameObject model;
    public GameObject[] hats;        // ����
    public GameObject[] clothes;  // ���۶�

    // �� ����� ���� �ε����� ����
    [HideInInspector] public int currentHatsIndex = 0;
    [HideInInspector] public int currentclothesIndex = 0;
}

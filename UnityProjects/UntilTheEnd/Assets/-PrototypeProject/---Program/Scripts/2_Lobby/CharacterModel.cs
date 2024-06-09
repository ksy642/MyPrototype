using UnityEngine;

[System.Serializable]
public class CharacterModel
{
    public GameObject model;
    public GameObject[] hats;        // 모자
    public GameObject[] clothes;  // 선글라스

    // 각 장비의 현재 인덱스를 저장
    [HideInInspector] public int currentHatsIndex = 0;
    [HideInInspector] public int currentclothesIndex = 0;
}

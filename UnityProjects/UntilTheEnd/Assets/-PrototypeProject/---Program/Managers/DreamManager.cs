using System.Collections;
using TMPro;
using UnityEngine;

public class DreamManager : Singleton<DreamManager>
{
    public bool dreaming = false; // 꿈 관련된 중요한 bool 변수

    public GameObject playerCamera = null;
    public GameObject totem; // 토템 : 자신이 꿈인지 아닌지 확인가능하게 해줌
    public Material skybox_Awake;
    public Material skybox_Dream;

    [Header("----Timer----")]
    public float timer = 10; // 제한 시간 ..테스트용으로 10초라 해둠
    public TMP_Text[] timeText;

    // Dreaming
    private float _fogTime = 4.0f;    // 안개 차오르는 시간 = 아드레날린 주사기 작동 시작시간
    private float _fogDensity = 0.013f; // 안개 밀도

    void Start()
    {
        timeText[0].text = null;
    }

    public void Update()
    {
        if (playerCamera == null)
        {
            playerCamera = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                // F2는 소수점 둘째자리까지 표기
                timeText[0].text = 0.ToString("F2");
                timer = 0;
                DreamLayer();
            }
            else
            {
                timeText[0].text = timer.ToString("F2");
            }
        }


        if (playerCamera != null)
        {
            if (playerCamera.gameObject.layer == LayerMask.NameToLayer("Dream"))
            {
                playerCamera.gameObject.layer = LayerMask.NameToLayer("Dream");
            }
            else if (playerCamera.gameObject.layer == LayerMask.NameToLayer("Awake"))
            {
                playerCamera.gameObject.layer = LayerMask.NameToLayer("Awake");
            }
        }
    }

    public void DreamLayer()
    {
        dreaming = true;
        Dreaming();
    }

    public void AwakeLayer()
    {
        dreaming = false;
        Awaking();
    }

    #region in a Dream
    void Dreaming()
    {
        StartCoroutine(FogOn(_fogDensity));
    }

    IEnumerator FogOn(float fogDensity)
    {
        float theTime = 0f;
        float startDensity = RenderSettings.fogDensity; // 시작밀도

        if (dreaming)
        {
            while (theTime < _fogTime)
            {
                theTime += Time.deltaTime;
                RenderSettings.fogDensity = Mathf.Lerp(startDensity, fogDensity, theTime / _fogTime);
                yield return null;
            }

            // 전환 완료 후 안개 밀도를 최종 목표 값으로 설정합니다.
            RenderSettings.fogDensity = fogDensity;
            RenderSettings.skybox = skybox_Dream;
            playerCamera.gameObject.layer = LayerMask.NameToLayer("Dream");

            totem.gameObject.SetActive(true);
            Creatures();
        }
    }
    #endregion

    #region Awaking
    public void Awaking()
    {
        if (!dreaming)
        {
            StartCoroutine(FogOff(0.001f));
        }
    }

    IEnumerator FogOff(float fogDensity)
    {
        yield return new WaitForSeconds(_fogTime); // 4초 뒤 Awake

        RenderSettings.fogDensity = fogDensity;
        playerCamera.gameObject.layer = LayerMask.NameToLayer("Awake");
        RenderSettings.skybox = skybox_Awake;

        totem.gameObject.SetActive(false);
    }

    public void ForAdrenaline()
    {
        AwakeLayer();
        timer = 10;
    }
    #endregion

    [Header("----Creatures----")]
    public GameObject creaturePrefab;
    public GameObject spawnedCreature = null;
    
    public Transform allCreatures;
    public Transform[] randomSummonLocations; // 3곳

    public float spawnRangeX = 1f;
    public float spawnRangeZ = 1f;

    // 크리처 소환
    public void Creatures()
    {

        if (spawnedCreature == null)
        {
            int randomIndex = Random.Range(0, randomSummonLocations.Length);
            Transform randomSpawnLocation = randomSummonLocations[randomIndex];
         
            //spawnedCreature = Instantiate(creaturePrefab, randomSpawnLocation.position, Quaternion.identity);


            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);


            Vector3 randomSpawnPosition = new Vector3(
                randomSpawnLocation.position.x + randomX,
                randomSpawnLocation.position.y,
                randomSpawnLocation.position.z + randomZ
                );

            spawnedCreature = Instantiate(creaturePrefab, randomSpawnPosition, Quaternion.identity);

            // 생성된 크리처를 Creatures 오브젝트의 자식으로 설정
            spawnedCreature.transform.parent = allCreatures.transform;



            // 생성된 크리처를 Creatures 오브젝트의 자식으로 설정
            //spawnedCreature.transform.parent = allCreatures.transform;
        }
    }
}
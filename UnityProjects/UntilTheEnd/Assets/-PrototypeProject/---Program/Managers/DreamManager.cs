using System.Collections;
using TMPro;
using UnityEngine;

public class DreamManager : Singleton<DreamManager>
{
    public bool dreaming = false; // �� ���õ� �߿��� bool ����

    public GameObject playerCamera = null;
    public GameObject totem; // ���� : �ڽ��� ������ �ƴ��� Ȯ�ΰ����ϰ� ����
    public Material skybox_Awake;
    public Material skybox_Dream;

    [Header("----Timer----")]
    public float timer = 10; // ���� �ð� ..�׽�Ʈ������ 10�ʶ� �ص�
    public TMP_Text[] timeText;

    // Dreaming
    private float _fogTime = 4.0f;    // �Ȱ� �������� �ð� = �Ƶ巹���� �ֻ�� �۵� ���۽ð�
    private float _fogDensity = 0.013f; // �Ȱ� �е�

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
                // F2�� �Ҽ��� ��°�ڸ����� ǥ��
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
        float startDensity = RenderSettings.fogDensity; // ���۹е�

        if (dreaming)
        {
            while (theTime < _fogTime)
            {
                theTime += Time.deltaTime;
                RenderSettings.fogDensity = Mathf.Lerp(startDensity, fogDensity, theTime / _fogTime);
                yield return null;
            }

            // ��ȯ �Ϸ� �� �Ȱ� �е��� ���� ��ǥ ������ �����մϴ�.
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
        yield return new WaitForSeconds(_fogTime); // 4�� �� Awake

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
    public Transform[] randomSummonLocations; // 3��

    public float spawnRangeX = 1f;
    public float spawnRangeZ = 1f;

    // ũ��ó ��ȯ
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

            // ������ ũ��ó�� Creatures ������Ʈ�� �ڽ����� ����
            spawnedCreature.transform.parent = allCreatures.transform;



            // ������ ũ��ó�� Creatures ������Ʈ�� �ڽ����� ����
            //spawnedCreature.transform.parent = allCreatures.transform;
        }
    }
}
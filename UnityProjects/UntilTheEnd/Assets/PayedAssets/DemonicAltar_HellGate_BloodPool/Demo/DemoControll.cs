using UnityEngine;

public class DemoControll : MonoBehaviour {

    [SerializeField] private GameObject altarObj, gateObj, poolObj, camAltar, camGate, camPool;
    [SerializeField] private Light mainLight;
    [SerializeField] private DemonicAltar_Controller altarScript;
    [SerializeField] private HellGate_Controller hellGateScript;
    [SerializeField] private BloodPool_Controller bloodPoolScript;

    private Transform camBaseTF;
    public int propNR = 0;
    private float lightMaxIntens, lightTargetIntens;
    private bool rotateCam;

	// Use this for initialization
	void Start () {
            lightMaxIntens = mainLight.intensity;
            mainLight.intensity = 0;
            
            gateObj.SetActive(false);
            poolObj.SetActive(false);
            altarObj.SetActive(true);
            
            camGate.SetActive(false);
            camPool.SetActive(false);
            camAltar.SetActive(true);
            
            camBaseTF = camAltar.transform;
            
            ButtonCycleProps();
        }
	
	// Update is called once per frame
	void Update () {

        if(rotateCam)
            camBaseTF.Rotate(Vector3.up, -10 * Time.deltaTime);
       
        if (mainLight.intensity != lightTargetIntens)
            mainLight.intensity = Mathf.MoveTowards(mainLight.intensity, lightTargetIntens, Time.deltaTime * 0.3f);
       
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void ButtonCycleProps()
    {
        altarObj.SetActive(false);
        gateObj.SetActive(false);
        poolObj.SetActive(false);

        camAltar.SetActive(false);
        camGate.SetActive(false);
        camPool.SetActive(false);

        lightTargetIntens = 0;
        mainLight.intensity = 0;

        propNR += 1;
        if (propNR >= 3)
            propNR = 0;

        switch (propNR)
        {
            case 0:
                camAltar.SetActive(true);
                camBaseTF = camAltar.transform;
                altarObj.SetActive(true);
                break;
            case 1:
                camGate.SetActive(true);
                camBaseTF = camGate.transform;
                gateObj.SetActive(true);
                break;
            case 2:
                camPool.SetActive(true);
                camBaseTF = camPool.transform;
                poolObj.SetActive(true);
                break;
        }
    }

    private void ButtonToggleProp()
    {
        switch (propNR)
        {
            case 0:
                altarScript.ToggleDemonicAltar();
                break;
            case 1:
                hellGateScript.ToggleHellGate();
                break;
            case 2:
                bloodPoolScript.F_ToggleBloodPool();
                break;
        }
    }

    private void ButtonToggleLight()
    {
        if (lightTargetIntens != 0)
            lightTargetIntens = 0;
        else lightTargetIntens = lightMaxIntens;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 60), "Light On/Off"))
            ButtonToggleLight();
    
        if (GUI.Button(new Rect(10, 65, 100, 60), "Rotate Camera"))
            rotateCam = !rotateCam;
    
        if (GUI.Button(new Rect(110, 10, 100, 60), "Change Prop"))
            ButtonCycleProps();
    
        if (GUI.Button(new Rect(110, 65, 100, 60), "Prop On/Off"))
            ButtonToggleProp();
    }
}

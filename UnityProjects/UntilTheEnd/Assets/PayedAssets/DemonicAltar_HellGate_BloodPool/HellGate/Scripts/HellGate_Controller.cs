using System.Collections;
using UnityEngine;

public class HellGate_Controller : MonoBehaviour
{
    [SerializeField]
    private Gradient emissionColor;
    [SerializeField]
    private ParticleSystem orbParticlesL, orbParticlesR, fireParticles;
    [SerializeField]
    private AudioSource gateAudio, screamAudio, orbLAudio, orbRAudio, fireAudio;
    [SerializeField]
    private Light gateLight;
    [SerializeField]
    private Renderer gateRenderer, gateEffectRenderer;

    private Material gateMaterial, gateEffectMaterial;
    private GameObject gateEffectObj;

    private bool inTransition, hellGateOn;
    private float gateAudioMaxVolume = 0.3f, gateLightMaxIntencity = 5f, fireAudioMaxVolume = 0.6f;

    private void Start()
    {
        gateEffectObj = gateEffectRenderer.gameObject;
        gateEffectMaterial = gateEffectRenderer.material;

        gateMaterial = gateRenderer.material;

        gateEffectObj.SetActive(false);
        gateLight.gameObject.SetActive(false);

        gateEffectMaterial.SetFloat("_Alpha", 0);
        gateMaterial.SetColor("_EmissionColor", emissionColor.Evaluate(0));
        gateLight.intensity = 0;
    }

    public void ToggleHellGate()
    {
        if (inTransition)
            return;

        if (!hellGateOn)
        {
            StartCoroutine(PreActivateGate());
        }
        else
        {
            StartCoroutine(DeactivateGate());
        }

        hellGateOn = !hellGateOn;
    }

    private IEnumerator PreActivateGate()
    {
        inTransition = true;

        float transitionTimer = 0;
        float rand1 = Random.Range(0.2f, 0.8f);
        float rand2 = Random.Range(0.2f, 0.8f);

        while (transitionTimer < 1f)
        {
            transitionTimer += Time.deltaTime * 0.5f;
           
            if (transitionTimer >= rand1 && !orbParticlesL.isPlaying)
            {
                orbParticlesL.Play();
                orbLAudio.Play();
            }

            if (transitionTimer >= rand2 && !orbParticlesR.isPlaying)
            {
                orbParticlesR.Play();
                orbRAudio.Play();
            }

            gateMaterial.SetColor("_EmissionColor", emissionColor.Evaluate(transitionTimer));

            yield return null;
        }

        gateMaterial.SetColor("_EmissionColor", emissionColor.Evaluate(1f));

        StartCoroutine(ActivateGate());
    }

    private IEnumerator ActivateGate()
    {
        float transitionTimer = 0;

        gateEffectObj.SetActive(true);
        gateLight.gameObject.SetActive(true);

        fireParticles.Play();
        fireAudio.volume = fireAudioMaxVolume;
        fireAudio.Play();
        screamAudio.Play();
        gateAudio.Play();

        while (transitionTimer < 1f)
        {
            transitionTimer += Time.deltaTime * 0.21f;

            gateEffectMaterial.SetFloat("_Alpha", 1f - transitionTimer * 0.75f);

            gateLight.intensity = transitionTimer * gateLightMaxIntencity;
            gateAudio.volume = transitionTimer * gateAudioMaxVolume;

            yield return null;
        }

        gateEffectMaterial.SetFloat("_Alpha", 0f);
        gateLight.intensity = gateLightMaxIntencity;
        gateAudio.volume = gateAudioMaxVolume;
        inTransition = false;
    }

    private IEnumerator DeactivateGate()
    {
        inTransition = true;

        float transitionTimer = 1;

        orbParticlesL.Stop();
        orbParticlesR.Stop();


        while (transitionTimer > 0)
        {
            transitionTimer -= Time.deltaTime * 0.3f;

            gateMaterial.SetColor("_EmissionColor", emissionColor.Evaluate(transitionTimer));

            gateEffectMaterial.SetFloat("_Alpha", 1f - transitionTimer);
            gateLight.intensity = transitionTimer * gateLightMaxIntencity;
            gateAudio.volume = transitionTimer * gateAudioMaxVolume;
            fireAudio.volume = transitionTimer * fireAudioMaxVolume;
            yield return null;
        }

        fireParticles.Stop();
        gateMaterial.SetColor("_EmissionColor", emissionColor.Evaluate(0f));
        gateEffectObj.SetActive(false);
        gateLight.gameObject.SetActive(false);
        gateAudio.Stop();
        fireAudio.Stop();

        inTransition = false;
    }
}

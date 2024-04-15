using System.Collections;
using UnityEngine;
using PaulosDemonicAltar;

public class DemonicAltar_Controller : MonoBehaviour
{
    [SerializeField] private EnabledState lightningEffects;
    [Space(10)]

    [SerializeField] private Gradient emissionColor;
    [SerializeField] private Renderer altarRend;
    [SerializeField] private GameObject runeCircleParticlesObj, runeExplosionObj;
    [SerializeField] private ParticleSystem portalParticles, lightningParticles, sparksParticles;
    [SerializeField] private Light portalLight, lightningLight;
    [SerializeField] private AudioSource chantingAudio, portalAudio, lightningAudio;

    private Vector3 runeCircleStartPosition = new Vector3(0.18f, 1.2f, 0), runeCircleEndPosition = new Vector3(0.18f, 6.5f, 0);
    private bool inTransition, altarOn;
    private float portalLightMaxIntensity = 7, portalAudioMaxVolume = 0.8f;
    private Material altarMat;
    private Transform runeCircleTF;
    private Coroutine lightningCor;
    private bool lightningCorRunning;

    private void Start()
    {
        runeCircleTF = runeCircleParticlesObj.transform;
        runeCircleTF.gameObject.SetActive(false);

        runeExplosionObj.SetActive(false);

        altarMat = altarRend.material;
        altarMat.SetColor("_EmissionColor", emissionColor.Evaluate(0));
    }

    public void ToggleDemonicAltar()
    {
        if (inTransition)
            return;

        if (!altarOn)
        {
            StartCoroutine(ActivateAltar());
        }
        else
        {
            StartCoroutine(DeactivateAltar());
        }

        altarOn = !altarOn;
    }

    private IEnumerator ActivateAltar()
    {
        inTransition = true;

        float runeCircleSpeed = 0f, colorEval = 0f;

        runeCircleTF.localPosition = runeCircleStartPosition;
        runeCircleTF.gameObject.SetActive(true);
        chantingAudio.Play();

        while (runeCircleTF.localPosition.y < runeCircleEndPosition.y)
        {
            runeCircleSpeed += 0.4f * Time.deltaTime;

            runeCircleTF.localPosition = Vector3.MoveTowards(runeCircleTF.localPosition, runeCircleEndPosition, Time.deltaTime * runeCircleSpeed);
            runeCircleTF.Rotate(runeCircleTF.up, (runeCircleSpeed * 205) * Time.deltaTime);

            colorEval += Time.deltaTime * 0.2f;
            altarMat.SetColor("_EmissionColor", emissionColor.Evaluate(colorEval));

            yield return null;
        }

        runeCircleTF.gameObject.SetActive(false);

        runeExplosionObj.SetActive(true);

        yield return new WaitForSeconds(0.6f);

        portalAudio.volume = portalAudioMaxVolume;
        portalParticles.Play();
        portalAudio.Play();
        portalLight.intensity = portalLightMaxIntensity;

        if (lightningEffects == EnabledState.on && !lightningCorRunning)
        {
            lightningCor = StartCoroutine(LightningRotation());
        }

        inTransition = false;
    }

    private IEnumerator LightningRotation()
    {
        lightningCorRunning = true;

        yield return new WaitForSeconds(Random.Range(4f, 12f));

        while (true)
        {
            StartCoroutine(LightningFlashes());

            lightningParticles.Play();
            sparksParticles.Play();
            lightningAudio.pitch = Random.Range(0.9f, 1.1f);
            lightningAudio.Play();

            yield return new WaitForSeconds(Random.Range(4f, 12f));
        }
    }

    private IEnumerator LightningFlashes()
    {
        int flashes = 4;
        lightningLight.intensity = 8f;

        lightningLight.gameObject.SetActive(true);

        while (flashes >= 0)
        {
            lightningLight.intensity = Random.Range(2, 12);
            flashes -= 1;
            yield return new WaitForSeconds(0.04f);
        }

        lightningLight.gameObject.SetActive(false);
    }

    private IEnumerator DeactivateAltar()
    {
        inTransition = true;

        float transitionTimer = 1;

        if (lightningEffects == EnabledState.on && lightningCorRunning)
        {
            StopCoroutine(lightningCor);
            lightningCorRunning = false;
        }

        portalParticles.Stop();

        while (transitionTimer > 0)
        {
            transitionTimer -= Time.deltaTime * 0.2f;

            portalLight.intensity = transitionTimer * portalLightMaxIntensity;
            portalAudio.volume = transitionTimer * portalAudioMaxVolume;
            altarMat.SetColor("_EmissionColor", emissionColor.Evaluate(transitionTimer));

            yield return null;
        }

        portalAudio.Stop();
        runeExplosionObj.SetActive(false);

        inTransition = false; 
    }
}

namespace PaulosDemonicAltar
{
    public enum EnabledState { on, off };
}

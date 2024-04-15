using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPool_Controller : MonoBehaviour
{
    [SerializeField] private Gradient emissionColor;
    [SerializeField] private ParticleSystem[] poolParticles = new ParticleSystem[8];
    [SerializeField] private Light[] fireLights = new Light[2];
    [SerializeField] private AudioSource[] poolAudios = new AudioSource[3];
    [SerializeField] private Renderer poolRenderer;

    private float transitionFloat, transitionSpeed = 0.8f, maxLightIntencity, fireAudioVolumeMax, bubblesAudioVolumeMax;
    private bool transitionRunning, activatePool;
    private Material poolMaterial;
    private Coroutine lichtFlickerCor;

    private void Start()
    {
        poolMaterial = poolRenderer.material;
        maxLightIntencity = fireLights[0].intensity;
        fireAudioVolumeMax = poolAudios[1].volume;
        bubblesAudioVolumeMax = poolAudios[2].volume;

        poolMaterial.SetColor("_EmissionColor", emissionColor.Evaluate(0));

        foreach (Light lgt in fireLights)
            lgt.intensity = 0;

        poolAudios[1].volume = 0f;
        poolAudios[2].volume = 0f;
    }

    public void F_ToggleBloodPool()
    {
        if (!transitionRunning)
        {
            activatePool = !activatePool;
            StartCoroutine(TransitionRoutine());
        }
    }

    private IEnumerator TransitionRoutine()
    {
        transitionRunning = true;

        if (activatePool)
        {
            foreach (ParticleSystem part in poolParticles)
                part.Play();

            foreach (Light lgt in fireLights)
                lgt.intensity = maxLightIntencity;

            foreach (AudioSource audC in poolAudios)
                audC.Play();

            yield return new WaitForSeconds(0.5f);

            while (transitionFloat < 1f )//Fade in
            {
                transitionFloat = Mathf.MoveTowards(transitionFloat, 1f, Time.deltaTime * transitionSpeed);

                poolMaterial.SetColor("_EmissionColor", emissionColor.Evaluate(transitionFloat));
                poolAudios[1].volume = transitionFloat * fireAudioVolumeMax;
                poolAudios[2].volume = transitionFloat * bubblesAudioVolumeMax;

                yield return new WaitForSeconds(Time.deltaTime);
            }

            lichtFlickerCor = StartCoroutine(FlickerLights());
        }
        else if (!activatePool)
        {
            foreach (ParticleSystem part in poolParticles)
                part.Stop();

            StopCoroutine(lichtFlickerCor);

            while (transitionFloat > 0f)//Fade out
            {
                transitionFloat = Mathf.MoveTowards(transitionFloat, 0f, Time.deltaTime * transitionSpeed);

                poolMaterial.SetColor("_EmissionColor", emissionColor.Evaluate(transitionFloat));
                poolAudios[1].volume = transitionFloat * fireAudioVolumeMax;
                poolAudios[2].volume = transitionFloat * bubblesAudioVolumeMax;

                foreach (Light lgt in fireLights)
                    lgt.intensity = transitionFloat * maxLightIntencity;

                yield return new WaitForSeconds(Time.deltaTime);
            }

            foreach (AudioSource audC in poolAudios)
                audC.Stop();
        }

        transitionRunning = false;
    }

    private IEnumerator FlickerLights()
    {
        while (true)
        {
            float randIntencity = Random.Range(maxLightIntencity - 0.1f, maxLightIntencity);

            foreach (Light lgt in fireLights)
                lgt.intensity = randIntencity;

            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        }
    }
}

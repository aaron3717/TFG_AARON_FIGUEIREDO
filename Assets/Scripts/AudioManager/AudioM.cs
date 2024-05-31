using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] EfectosSonido;
    public AudioSource musicaDeFondo;
    private float volumenGeneral = 1f; // Volumen general del juego

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(int sonidoaponer)
    {
        if (sonidoaponer >= 0 && sonidoaponer < EfectosSonido.Length)
        {
            if (EfectosSonido[sonidoaponer] != null)
            {
                EfectosSonido[sonidoaponer].Stop();
                EfectosSonido[sonidoaponer].Play();
            }
            else
            {
                Debug.LogWarning("AudioSource en �ndice " + sonidoaponer + " es null.");
            }
        }
        else
        {
            Debug.LogWarning("�ndice de efecto de sonido fuera de rango: " + sonidoaponer);
        }
    }

    public void PlayMusic(AudioClip musicClip)
    {
        if (musicaDeFondo.clip != musicClip)
        {
            musicaDeFondo.clip = musicClip;
            musicaDeFondo.Play();
        }
    }

    public void StopMusic()
    {
        musicaDeFondo.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicaDeFondo.volume = volume;
    }

    // Establece el volumen del juego (m�sica y efectos de sonido)
    public void SetVolume(float volume)
    {
        volumenGeneral = Mathf.Clamp01(volume); // Asegurar que el volumen est� en el rango [0,1]

        // Ajustar el volumen de la m�sica de fondo
        musicaDeFondo.volume = volumenGeneral;

        // Ajustar el volumen de los efectos de sonido
        foreach (AudioSource sfxSource in EfectosSonido)
        {
            sfxSource.volume = volumenGeneral;
        }
    }

    // Getter para el volumen general
    public float GetVolume()
    {
        return volumenGeneral;
    }
}

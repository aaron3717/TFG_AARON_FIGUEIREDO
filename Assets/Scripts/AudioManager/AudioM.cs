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
                Debug.LogWarning("AudioSource en índice " + sonidoaponer + " es null.");
            }
        }
        else
        {
            Debug.LogWarning("Índice de efecto de sonido fuera de rango: " + sonidoaponer);
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

    // Establece el volumen del juego (música y efectos de sonido)
    public void SetVolume(float volume)
    {
        volumenGeneral = Mathf.Clamp01(volume); // Asegurar que el volumen esté en el rango [0,1]

        // Ajustar el volumen de la música de fondo
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

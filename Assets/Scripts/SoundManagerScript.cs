using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip mitsudesu;
    public static AudioClip sugoiyo;
    public static AudioClip kinkyujitaisengen;
    public static AudioClip damedesuyo;
    public static AudioClip supidokan;
    public static AudioClip shokuryohin;
    public static AudioClip arigatogozaimasu;
    public static AudioClip kiken;
    static AudioSource audioSrc;

    void Start()
    {
        mitsudesu = Resources.Load<AudioClip>("Mitsudesu");
        sugoiyo = Resources.Load<AudioClip>("Sugoiyo");
        kinkyujitaisengen = Resources.Load<AudioClip>("Kinkyujitaisengen");
        damedesuyo = Resources.Load<AudioClip>("Damedesuyo");
        supidokan = Resources.Load<AudioClip>("Supidokan");
        shokuryohin = Resources.Load<AudioClip>("Shokuryohin");
        arigatogozaimasu = Resources.Load<AudioClip>("Arigatogozaimasu");
        kiken = Resources.Load<AudioClip>("Kiken");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Mitsudesu":
                audioSrc.PlayOneShot(mitsudesu);
                break;
            case "Sugoiyo":
                audioSrc.PlayOneShot(sugoiyo);
                break;
            case "Kinkyujitaisengen":
                audioSrc.PlayOneShot(kinkyujitaisengen);
                break;
            case "Damedesuyo":
                audioSrc.PlayOneShot(damedesuyo);
                break;
            case "Supidokan":
                audioSrc.PlayOneShot(supidokan);
                break;
            case "Shokuryohin":
                audioSrc.PlayOneShot(shokuryohin);
                break;
            case "Arigatogozaimasu":
                audioSrc.PlayOneShot(arigatogozaimasu);
                break;
            case "Kiken":
                audioSrc.PlayOneShot(kiken);
                break;
        }
    }
}

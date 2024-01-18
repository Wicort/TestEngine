using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicLoader : MonoBehaviour
{
    [SerializeField] private Sprite _musicOn;
    [SerializeField] private Sprite _musicOff;

    [SerializeField] private Button _musicButton;

    private AudioClip[] _themes;
    private int _isMusicOn;
    private AudioSource musicSource;

    public static MusicLoader Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _musicButton = GameObject.Find("MusicButton").GetComponent<Button>();
        } else
        {
            Destroy(gameObject);
            Instance._musicButton = GameObject.Find("MusicButton").GetComponent<Button>();
            return;
        }

        musicSource = GetComponent<AudioSource>();
        _isMusicOn = PlayerPrefs.GetInt("IsMusicOn", 1);

        DontDestroyOnLoad(this);
        _themes = Resources.LoadAll<AudioClip>("Music");

        musicSource.clip = _themes[Random.Range(0, _themes.Length)];
        musicSource.loop = true;
        setIsMusicOn(_isMusicOn);
        musicSource.Play();
    }

    public void OnChangeMusicOnClicked()
    {

        _isMusicOn = _isMusicOn == 1 ? 0 : 1;
        setIsMusicOn(_isMusicOn);
        PlayerPrefs.SetInt("IsMusicOn", _isMusicOn);
    }

    private void setIsMusicOn(int value)
    {
        if (value == 0)
        {
            Instance._musicButton.image.sprite = _musicOff;
            Instance.musicSource.volume = 0f;
        }
        else
        {
            Instance._musicButton.image.sprite = _musicOn;
            Instance.musicSource.volume = 0.5f;
        }
    }

}

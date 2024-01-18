using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtLoader : MonoBehaviour
{
    [SerializeField] private Image _artImage;
    private Sprite[] _sprites;
    private Sprite _activeSprite;
    public static ArtLoader Instance;
        

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        _artImage.gameObject.SetActive(true);
    }

    private void Start()
    {
        _sprites = Resources.LoadAll<Sprite>("Art");
        SetNextSprite();
        StartCoroutine("PrintNextSprite");
    }

    private void SetNextSprite()
    {
        if (_sprites.Length > 0)
        {
            int spriteIndex = Random.Range(0, _sprites.Length);
            _activeSprite = _sprites[spriteIndex];
            _artImage.sprite = _activeSprite;
        }
    }

    private IEnumerator PrintNextSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            SetNextSprite();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite _defaultSprite;
    public Sprite _pressedSprite;

    public KeyCode _keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(_keyToPress))
        {
            _spriteRenderer.sprite = _pressedSprite;
        }

        if(Input.GetKeyUp(_keyToPress))
        {
            _spriteRenderer.sprite = _defaultSprite;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Testing
    public Side side;

    private SpriteRenderer _spriteRenderer;
    protected GameManager _gameManager;

    // Start is called before the first frame update
    void Awake()
    {




    }

    void Start()
    {
        _gameManager = GameManager.instance;

        _gameManager.RegisterAtGM(gameObject);

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        UpdateSide(side);

        if (side == null)
        {
            Debug.Log("NO SIDE SPECIFIED!");
        }
        Debug.Log("AI online");
    }

    public void UpdateSide(Side newSide)
    {
        side = newSide;
        if (_spriteRenderer != null)
            _spriteRenderer.color = side.Color;
        else
            gameObject.GetComponent<SpriteRenderer>().color = side.Color;
    }
}

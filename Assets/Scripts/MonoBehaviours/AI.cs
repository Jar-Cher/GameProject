using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Side side;

    private SpriteRenderer _spriteRenderer;
    protected GameManager _gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        if (side == null)
        {
            Debug.Log("NO SIDE SPECIFIED!");
        }
        Debug.Log("AI online");

        _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        registerAtGM();

        updateSide(side);
    }

    void updateSide(Side newSide)
    {
        _spriteRenderer.color = side.Color;

    }

    public void registerAtGM()
    {
        _gameManager.actors.Add(this.gameObject);
    }

    public void unregisterAtGM()
    {
        _gameManager.actors.Remove(this.gameObject);
    }
}

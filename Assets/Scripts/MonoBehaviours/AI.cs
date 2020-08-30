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
        _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        updateSide(side);

        if (side == null)
        {
            Debug.Log("NO SIDE SPECIFIED!");
        }
        Debug.Log("AI online");

        _gameManager = GameManager.instance;
    }

    virtual public void Start()
    {
        GameManager.instance.actors.Add(this.gameObject);
    }

    public void updateSide(Side newSide)
    {
        side = newSide;
        _spriteRenderer.color = side.Color;
    }

    public void unregisterAtGM()
    {
        _gameManager.actors.Remove(this.gameObject);
    }
}

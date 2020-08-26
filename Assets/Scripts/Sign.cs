using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public SignSystem signSystem;

    public GameObject[] adjSigns;

    public GameObject nextSign;

    public bool isChosen = false;

    private GameObject indicator;

    private Side side;

    void Start()
    {
        signSystem = transform.parent.GetComponent<SignSystem>();
        side = signSystem.side;

        indicator = this.transform.GetChild(0).gameObject;

        if (nextSign == null)
        {
            nextSign = this.gameObject;
        }

        if (!side.IsPlayerControlled)
            this.GetComponent<SpriteRenderer>().sprite = null;
    }

    void OnMouseDown()
    {

        Debug.Log("Clicked on " + this.gameObject);
        if (indicator.activeSelf)
        {
            GameObject chosen = null;
            foreach (Transform child in transform.parent)
            {
                if (child.GetComponent<Sign>().isChosen)
                {
                    chosen = child.gameObject;
                }
            }

            Debug.Log(chosen);

            chosen.GetComponent<Sign>().nextSign = this.gameObject;
            signSystem.unChoseAll();

            chosen.transform.right = transform.position - chosen.transform.position;
        }
        else
        {
            Debug.Log("Chosing");
            Chose();
        }
    }

    void Chose()
    {
        signSystem.unChoseAll();
        isChosen = true;
        foreach (GameObject neighbor in adjSigns)
        {
            neighbor.GetComponent<Sign>().setPossible();
        }

    }

    public void setImpossible()
    {
        indicator.SetActive(false);
    }

    public void setPossible()
    {
        indicator.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            if (side == collision.GetComponent<AI>().side)
            {
                CPMover mover = collision.GetComponent<CPMover>();
                if (mover != null)
                    mover.setTarget(nextSign);
            }
        }
    }
}

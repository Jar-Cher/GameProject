using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Если нужно сериализовать то лучше использовать аттрибут [SerializeField], бесячие варнинги от c# можно подавить (так еще будет выделяться блок сериализованных данных)
    // Публичное поле выглядит как будто его могут изменить из вне, это пугает или путает (в зависимости от того могут или нет)
    /*
#pragma warning disable CS0649
    [SerializeField]
    Side side;
#pragma warning restore CS0649
    */
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
        // Find("GameManager") дорогая и не надежная штука.
        // Тут поможет фабрика объектов. Некий спавнер создает юнитов в нужном месте и инициализирует их нужными значениями. Таким образом он может задавать им сторону, передавать указатель на хранителя поля и тд
        // Так же он может эти объекты зарегистрировать в GM
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        registerAtGM();

        updateSide(side);
    }

    // В языке C# методы/функции принято называть с большой буквы камелкейсом. Лучше использовать стандарты того языка который используется (в js методы с маленькой буквы)
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

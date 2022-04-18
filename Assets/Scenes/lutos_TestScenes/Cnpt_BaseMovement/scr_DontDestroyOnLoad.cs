using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DontDestroyOnLoad : MonoBehaviour
{
    public static GameObject instance = null; // Ёкземпл€р объекта

    // ћетод, выполн€емый при старте игры
    void Start()
    {
        // “еперь, провер€ем существование экземпл€ра
        if (instance == null)
        { // Ёкземпл€р менеджера был найден
            instance = this.gameObject; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance == this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }

        // “еперь нам нужно указать, чтобы объект не уничтожалс€
        // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);

        // » запускаем собственно инициализатор
        InitializeManager();
    }

    // ћетод инициализации менеджера
    private void InitializeManager()
    {
        /* TODO: «десь мы будем проводить инициализацию */
    }

}

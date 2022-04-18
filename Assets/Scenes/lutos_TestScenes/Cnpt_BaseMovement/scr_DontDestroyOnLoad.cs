using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DontDestroyOnLoad : MonoBehaviour
{
    public static GameObject instance = null; // ��������� �������

    // �����, ����������� ��� ������ ����
    void Start()
    {
        // ������, ��������� ������������� ����������
        if (instance == null)
        { // ��������� ��������� ��� ������
            instance = this.gameObject; // ������ ������ �� ��������� �������
        }
        else if (instance == this)
        { // ��������� ������� ��� ���������� �� �����
            Destroy(gameObject); // ������� ������
        }

        // ������ ��� ����� �������, ����� ������ �� �����������
        // ��� �������� �� ������ ����� ����
        DontDestroyOnLoad(gameObject);

        // � ��������� ���������� �������������
        InitializeManager();
    }

    // ����� ������������� ���������
    private void InitializeManager()
    {
        /* TODO: ����� �� ����� ��������� ������������� */
    }

}

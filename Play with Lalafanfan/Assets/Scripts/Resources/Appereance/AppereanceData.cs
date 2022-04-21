using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AppereanceData : ResourceData, IResource
{
    [NonSerialized]
    public static Dictionary<AppearanceType, string> AppearanceTypeTranslate = new Dictionary<AppearanceType, string> { { AppearanceType.Hairstyle, "��������"},
        { AppearanceType.Clothes, "������"}, {AppearanceType.Eyecolor, "���� ����"}};

    [SerializeField] private AppearanceType _appereanceType;

    public AppereanceData(string name, int price, string iconResourceName) : base(name, price, iconResourceName) {}

    public AppearanceType Type => _appereanceType;
}

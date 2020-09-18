﻿[System.Serializable]
// Помещаем пары из класса LocalizationItem и записываем в массив items
public class LocalizationData
{
    public LocalizationItem[] Items;
}
[System.Serializable]
// Получаем key-value пары из Json файла
public class LocalizationItem
{
    public string key;
    public string value;
}

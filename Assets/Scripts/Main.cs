using UnityEngine;
using UnityEngine.UI;
using System;

public class Main : MonoBehaviour
{
    // Тексты
    [SerializeField] private Text time;
    [SerializeField] private Text data;
    [SerializeField] private Text percentage;
    // Текущая дата
    DateTime date;
    void Update()
    {
        // Текущая дата и время системы
        date = DateTime.Now;

        // Форматированный вывод всех данных
        time.text = FormatTime();
        data.text = FormatMonth();
        percentage.text = FormatPercentage();
    
    }
    string GetRussianDayOfWeek(DayOfWeek day)
    {
        // Узнаем день недели
        switch (day)
        {
            case DayOfWeek.Monday: return "понедельник";
            case DayOfWeek.Tuesday: return "вторник";
            case DayOfWeek.Wednesday: return "среда";
            case DayOfWeek.Thursday: return "четверг";
            case DayOfWeek.Friday: return "пятница";
            case DayOfWeek.Saturday: return "суббота";
            case DayOfWeek.Sunday: return "воскресенье";
            default: return null;
        }
    }
    string GetBatteryStatus(BatteryStatus batteryStatus)
    {
        // Узнаем статус батареи
        switch (batteryStatus)
        {
            case BatteryStatus.Charging: return "Заряжается";
            case BatteryStatus.Discharging: return "Разряжается";
            case BatteryStatus.NotCharging: return "Не заряжается";
            case BatteryStatus.Full: return "Заряжено";
            case BatteryStatus.Unknown: return "Неизвестно";
            default: return null;
        }
    }
    string FormatMonth()
    {
        // Форматируем данные месяца
        return $"{GetRussianDayOfWeek(date.DayOfWeek)}, {date.Day} {date.ToString("MMMM").Replace("ь", "я")}";
    }
    string FormatTime()
    {
        // Форматируем данные времени
        return date.ToString("HH:mm:ss");
    }
    string FormatPercentage()
    {
        // Форматируем данные батареи
        return $"Батарея: {SystemInfo.batteryLevel * 100}% / Статус: {GetBatteryStatus(SystemInfo.batteryStatus)}";
    }
}
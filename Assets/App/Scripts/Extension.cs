using System;
using UnityEngine;

public static class Extension
{
    public static string ConvertCountText(float value, string format = "")
    {
        if (Math.Abs(value) < 1000)
        {
            string newValue = value.ToString(format);
            if (newValue[newValue.Length - 1] == '0')
            {
                newValue = value.ToString("F0");
            }
            return newValue;
        }

        else if (Math.Abs(value) < 1000000)
        {
            float newValue = value / 1000 * 100;
            newValue = Mathf.Floor(newValue);
            newValue /= 100;
            return newValue.ToString() + "k";
        }
        else
        {
            float newValue = value / 1000000 * 100;
            newValue = Mathf.Floor(newValue);
            newValue /= 100;
            return newValue.ToString() + "m";
        }
    }
}

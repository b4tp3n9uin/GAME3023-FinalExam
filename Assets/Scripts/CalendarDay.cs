using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for highlighting the day red on the calendar if it is the exact correct date.
public class CalendarDay : MonoBehaviour
{
    public TMPro.TextMeshProUGUI DayNumber;
    public int number;
    public CanvasRenderer cvsRen;

    // Start is called before the first frame update
    void Start()
    {
        DayNumber.text = number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRightDate();
    }

    void CheckRightDate()
    {
        if (number == TimeDate.days) // Highlight the day on the calendar when it is the exact day.
        {
            cvsRen.SetColor(Color.red);
        }
        else
        {
            cvsRen.SetColor(Color.white);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for the Event Manager and manages the special events for the day.
public class EventsManager : MonoBehaviour
{
    // List of special days you can list out.
    public SetSpecialDates[] specialDays;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetSpecial();
    }
    
    // Goes through each special days in the list to check if it is the date.
    void SetSpecial()
    {
        foreach (SetSpecialDates s in specialDays)
        {
            // check if it is the day for the event.
            s.CheckIfDate();
        }
    }
}

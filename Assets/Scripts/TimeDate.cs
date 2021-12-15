using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum for the Seasons.
public enum Seasons
{
    Winter = 0,
    Spring = 1, 
    Summer = 2,
    Fall = 3
};

// Class that keeps track of the time, date and calendar.
public class TimeDate : MonoBehaviour
{
    Seasons season;

    public float year = 2000;

    [Range(5.0f, 60.0f)]
    public float minutesInHour;

    [Range(4.0f, 24.0f)]
    public float hoursInDay;

    float minutes, hours;

    // Other classes have access to this variable, so it knows the exact day.
    public static int days;

    // Text that prints out the current season
    string ssn_text;

    public TMPro.TextMeshProUGUI timeTxt;
    public TMPro.TextMeshProUGUI date;

    // Those Game Objects are for the particle effects for the seasons.
    [Header("Particle Effects")]
    public GameObject snow;
    public GameObject rain;
    public GameObject summerLeaves;
    public GameObject leaves;
    

    // Start is called before the first frame update
    void Start()
    {
        days = 1;
        minutes = 0;
        hours = 0;

        minutesInHour = minutesInHour - 1;
        hoursInDay = hoursInDay - 1;

        season = Seasons.Winter;
    }

    // Update is called once per frame
    void Update()
    {
        checkSeason();
        Counter();
    }

    void Counter()
    {
        // Time tracker to change the day.
        if (hours > hoursInDay)
        {
            hours = 0;
            days++;

            ResetSeason();
        }

        // Time tracker for the hours.
        if (minutes > minutesInHour)
        {
            minutes = 0;
            hours++;
        }

        minutes += Time.deltaTime;
        DisplayTimeNDate();
    }

    // Function that will modify the time, and date text according to the in-game time n date.
    void DisplayTimeNDate()
    {
        timeTxt.text = "Time: " +Mathf.Round(hours).ToString() + ":" + Mathf.Round(minutes).ToString();
        date.text = "Day: " + days + ", " + year + "\t\tSeason: " + ssn_text;
    }

    void ResetSeason()
    {
        // After day 28, it is the New Year!
        if (days > 28)
        {
            days = 1;
            year++;
        }

        int d = days - 1;
        
        // After a week has passed, there is a new season
        if (d % 7 == 0)
            season++;

        if (season > Seasons.Fall)
            season = Seasons.Winter;
    }

    // Activates the particle effects for the right season. 
    void checkSeason()
    {
        switch (season)
        {
            case Seasons.Winter:
                snow.SetActive(true);
                rain.SetActive(false);
                summerLeaves.SetActive(false);
                leaves.SetActive(false);
                ssn_text = "Winter";
                break;
            case Seasons.Spring:
                snow.SetActive(false);
                rain.SetActive(true);
                summerLeaves.SetActive(false);
                leaves.SetActive(false);
                ssn_text = "Spring";
                break;
            case Seasons.Summer:
                snow.SetActive(false);
                rain.SetActive(false);
                summerLeaves.SetActive(true);
                leaves.SetActive(false);
                ssn_text = "Summer";
                break;
            case Seasons.Fall:
                snow.SetActive(false);
                rain.SetActive(false);
                summerLeaves.SetActive(false);
                leaves.SetActive(true);
                ssn_text = "Fall";
                break;
        }
    }
}

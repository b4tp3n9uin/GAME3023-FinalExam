using UnityEngine;

// Class that you can create to setup the special day.
[System.Serializable]
public class SetSpecialDates : MonoBehaviour
{
    public string name;
    public int date;

    // Game Object for the special things that happen on the special day.
    public GameObject SpecialEvent;

    // Start is called before the first frame update
    void Start()
    {
        SpecialEvent.SetActive(false);
    }

    public void CheckIfDate()
    {
        // If it is the special event date, activate the game object for that one day.
        if (date == TimeDate.days)
            SpecialEvent.SetActive(true);
        else
            SpecialEvent.SetActive(false);
    }
}

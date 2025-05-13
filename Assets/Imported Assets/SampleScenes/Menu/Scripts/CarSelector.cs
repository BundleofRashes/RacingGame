using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public GameObject continueButton; // drag the button here in Unity

    public void SelectCar(int carIndex)
    {
        PlayerPrefs.SetInt("SelectedCar", carIndex);
        Debug.Log("Car selected: " + carIndex);

        if (continueButton != null)
            continueButton.SetActive(true); // show the button
    }
}

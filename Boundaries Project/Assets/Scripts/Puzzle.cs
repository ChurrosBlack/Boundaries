using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour
{
    public Button[] buttons;
    public Barrier[] barriers;
    void Start()
    {

    }

    void Update()
    {
        if (CheckBarriersOpened() && CheckButtonsActivated())
        {
            return;
        }

        print("Buttons: " + CheckButtonsActivated() + "Barriers " + CheckButtonsActivated());

        if (CheckButtonsActivated())
        {
            if (!CheckBarriersOpened())
            {
                ResetAll();
            }
        }
       
    }

    bool CheckButtonsActivated()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (!buttons[i].activated)
            {
                return false;
            }
        }

        return true;
    }

    bool CheckBarriersOpened()
    {
        for (int i = 0; i < barriers.Length; i++)
        {
            if (!barriers[i].open)
            {
                return false;
            }
        }
        return true;
    }

    void ResetAll()
    {
        print("Called reset all");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].activated = false;
        }

        for (int i = 0; i < barriers.Length; i++)
        {
            barriers[i].actualPower = 0;
        }
    }

    void Finish()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].OnPuzzle = false;
        }
    }

}


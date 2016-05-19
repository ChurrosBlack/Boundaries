using UnityEngine;
using System.Collections;

public class MovingNeedlePuzzle : MonoBehaviour
{
    /// <summary>
    /// Script para Puzzle de agulhas que se movem nas plataformas
    /// segundo documentação LD
    /// </summary>
    public MovingNeedleButton[] buttons;
    bool finished = false;


    void Update()
    {
        int id = FirstButtonId();
        if (ButtonsActivated() >= 3)
        {
            DeactivateFirstButton(id);
        }
    }

    int FirstButtonId()
    {
        int id = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].activated)
            {
                id = buttons[i].id;
                return id;
            }
        }

        return id;
    }

    int ButtonsActivated()
    {
        int number = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].activated)
            {
                number++;
            }
        }

        return number;
    }

    void DeactivateFirstButton(int id)
    {
        buttons[id].activated = false;
        buttons[id].ActivateObjectsAttached(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutPanelScript : MonoBehaviour
{
    public GameObject panel,
                      panel1,
                      panel2,
                      panel3,
                      panel4,
                      panel5,
                      panel6,
                      Opanel1,
                      Opanel2;
    
    public void openPanel1()
    {
        if (panel1 != null)
        {
            panel.SetActive(false);
            panel1.SetActive(true);
        }
    }

    public void openPanel2()
    {
        if (panel2 != null)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
    }

    public void openPanel3()
    {
        if (panel3 != null)
        {
            panel2.SetActive(false);
            panel3.SetActive(true);
        }
    }

    public void openPanel4()
    {
        if (panel4 != null)
        {
            panel3.SetActive(false);
            panel4.SetActive(true);
        }
    }

    public void openPanel5()
    {
        if (panel5 != null)
        {
            panel4.SetActive(false);
            panel5.SetActive(true);
        }
    }

    public void openPanel6()
    {
        if (panel6 != null)
        {
            panel5.SetActive(false);
            panel6.SetActive(true);
        }
    }

    public void openSimulan1()
    {
        if (Opanel1 != null)
        {
            Opanel2.SetActive(false);
            Opanel1.SetActive(true);
        }
    }

    public void openSimulan2()
    {
        if (Opanel2 != null)
        {
            Opanel2.SetActive(true);
            Opanel1.SetActive(false);
        }
    }
}

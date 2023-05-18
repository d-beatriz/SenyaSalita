using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomImage : MonoBehaviour
{
    public GameObject image1,
                      image2,
                      image3,
                      image4,
                      image5;

    public void zoomImage1()
    {
        if (image1.activeInHierarchy == true)
        {
            image1.SetActive(false);
        }
        else
        {
            image1.SetActive(true);
        }
    }

    public void zoomImage2()
    {
        if (image2.activeInHierarchy == true)
        {
            image2.SetActive(false);
        }
        else
        {
            image2.SetActive(true);
        }
    }

    public void zoomImage3()
    {
        if (image3.activeInHierarchy == true)
        {
            image3.SetActive(false);
        }
        else
        {
            image3.SetActive(true);
        }
    }

    public void zoomImage4()
    {
        if (image4.activeInHierarchy == true)
        {
            image4.SetActive(false);
        }
        else
        {
            image4.SetActive(true);
        }
    }

    public void zoomImage5()
    {
        if (image5.activeInHierarchy == true)
        {
            image5.SetActive(false);
        }
        else
        {
            image5.SetActive(true);
        }
    }
}

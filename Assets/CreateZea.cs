using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZea : MonoBehaviour
{
    public int minRows;
    public int maxRows;
    public int minLines;
    public int maxLines;

    public GameObject kernel;
    public GameObject deadKernel;

    public GameObject self;

    public Material material1;
    public Material material2;
    public Material material3;

    private System.Random random = new System.Random();

     void OnEnable()
    {
        int rows = random.Next(minRows, maxRows);
        int lines = random.Next(minLines, maxLines);
        double radius = (double) lines / Math.PI / 2;
        double angle = Math.PI * 2 / (double) lines;

        int colorType = random.Next(0, 6);

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < lines; j++)
            {
                float xTemp = (float) (Math.Cos(angle * j) * radius);
                float yTemp = (float) (i - (rows / 2)) * 0.6F;
                float zTemp = (float) (Math.Sin(angle * j) * radius);

                float xScale = (float) random.Next(950, 1050) / 1000.0F;
                float yScale = (float) random.Next(950, 1050) / 1000.0F;
                float zScale = (float) random.Next(950, 1050) / 1000.0F;

                Vector3 pos = new Vector3(xTemp, yTemp, zTemp);
                Vector3 rot = new Vector3(0, (float) (angle * 180.0D * j / Math.PI), 90);
                Vector3 scale = new Vector3(xScale, yScale, zScale);

                GameObject generated = Instantiate(kernel);

                generated.transform.position = pos;
                generated.transform.rotation = Quaternion.Euler(rot);
                generated.transform.parent = self.transform;
                generated.transform.localScale = scale;

                int color = randomColor(colorType);

                switch(color)
                {
                    case 1:
                        generated.GetComponent<Renderer>().material = material1;
                        break;
                    case 2:
                        generated.GetComponent<Renderer>().material = material2;
                        break;
                    case 3:
                        generated.GetComponent<Renderer>().material = material3;
                        break;
                }
            }
        }
    }

    int randomColor(int colorType)
    {
        switch(colorType)
        {
            case 0:
                return randomDoubleColor(1, 3);
            case 1:
                return randomDoubleColor(7, 9);
            case 2:
                return randomDoubleColor(1, 15);
            case 3:
                return randomDoubleColor(13, 3);
            case 4:
                return randomTripleColor(1, 6, 9);
            case 5:
                return randomTripleColor(4, 3, 9);
            default:
                return 0;
        }
    }

    int randomDoubleColor(int v1, int v2)
    {
        int temp = random.Next(0, v1 + v2);

        if(temp < v1)
            return 1;
        else
            return 2;
    }

    int randomTripleColor(int v1, int v2, int v3)
    {
        int temp = random.Next(0, v1 + v2 + v3);

        if (temp < v1)
            return 1;
        else if(temp < v2)
            return 2;
        else
            return 3;
    }
}

using UnityEngine;
using System.Collections;
using System;


public class Graph : MonoBehaviour
{
   
    public float graphHeight = 2;
    public float graphWidth = 2;
    public float yDivider = 1;
    public float max = 3;
    public Color[] colors;

    public float[] borders = new float[5];


    public int resolution = 300;


    public float graphLenght = 1;
    

    private ParticleSystem.Particle[] points;

    void Start()
    {
        CreatePoints();
    }

    private void CreatePoints()
    {
        points = new ParticleSystem.Particle[resolution];

        float incrementScreen = graphWidth / (resolution - 1); //1/299
        float incrementFunction = graphLenght / (resolution - 1); //1/299
        CalculateYDivider();
        
        float x1,x, y, y1;

        for (int i = 0; i < resolution; ++i)
            {
                //prepared variables: x1 is variable destribing position x of point, x2 is variable used in function of point y position
                x1 = i * incrementScreen;
                x = i * incrementFunction;

                y = 5 * (Mathf.Sin(x));
                y1 = y/ yDivider;

                //Here is function - z is coordinate = f(x)!
                //Function have to be divide by yDivider to scale it to graphHeight
                points[i].position = new Vector3(x1 , 0f, y1);

            CalculateColor(i, y);

            points[i].size = 0.1f;
            }
    }

    void CalculateColor(int i, float y)
    {
        //i is a number of point in points
           for (int k = 0; k < borders.Length; ++k)
            {
                if(y<=borders[k])
                {
                    points[i].color = colors[k];
                    break;
                }
                else
                {
                    points[i].color = colors[5];
                }
            }
    }

    void Update()
    {
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }

    void CalculateMax()
    {
        //Function calculating maximum of function
        //Daniel's map will be necesery
    }

    void CalculateYDivider()
    {
        yDivider = max / graphHeight;
    }
}

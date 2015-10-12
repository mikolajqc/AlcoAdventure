using UnityEngine;
using System.Collections;
using System;


public class Graph : MonoBehaviour
{
   
    public float graphHeight = 2;
    public float graphWidth = 2;
    public float yDivider = 1;
    public float max = 3;


    public float[] actualColorRGB = new float[3];
    public int resolution = 300;

    //this variable is connect with sober time +10% *h 
    public float graphLenght = 1;
    

    private ParticleSystem.Particle[] points;

    void Start()
    {
        CreatePoints();
    }

    private void CreatePoints()
    {
        points = new ParticleSystem.Particle[resolution];

        float incrementX = graphWidth / (resolution - 1); //1/299
        float incrementY = graphLenght / (resolution - 1); //1/299
        CalculateYDivider();
        

        float x1,x2;

        for (int i = 0; i < resolution; ++i)
            {
                //prepared variables: x1 is variable destribing position x of point, x2 is variable used in function of point y position
                x1 = i * incrementX;
                x2 = i * incrementY;

                //Here is function - z is coordinate = f(x)!
                points[i].position = new Vector3((x1 ), 0f,(Mathf.Ceil(x2))/yDivider);

                //Changing color of graph:
                points[i].color = new Color(x1, 255-x1, 0);
                
                //Size of graph:
                points[i].size = 0.1f;
            }
    }

    void CalculateColor()
    {

    }

    void Update()
    {
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
        print(graphWidth);
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

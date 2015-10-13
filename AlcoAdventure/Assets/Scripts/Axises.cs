using UnityEngine;
using System.Collections;

public class Axises : MonoBehaviour {

    //zrob getcomponenty !
    public float graphHeight = 1;
    public float graphWidth = 3;
    public float yDivider = 1;
    public float max = 3;
   // public Color[] colors;

   // public float[] borders = new float[5];


    //public float[] actualColorRGB = new float[3];
    public int resolution = 300;

    //this variable is connect with sober time +10% *h 
    public float graphLenght = 1;

    private ParticleSystem.Particle[] points;
    // Use this for initialization
    void Start () {
        //   graphHeight +=

        CreatePoints();
	}
	


    private void CreatePoints()
    {
        points = new ParticleSystem.Particle[resolution];

        float incrementX = graphWidth / (resolution - 1);
        float incrementY = graphHeight / (resolution - 1);
    //    graphHeight = GetComponent<Graph>().graphHeight;
    //    graphWidth = gameObject.GetComponent<Graph>().graphWidth;

        for (int i = 0; i < resolution; ++i)
        {
            if (i%2==0)
            {
                points[i].position = new Vector3(gameObject.transform.position.x, 0f, i * incrementY);

                //Changing color of graph:
                points[i].color = new Color(255, 255, 255);
                //Size of graph:
                points[i].size = 0.05f;
            }
            else
            {
                points[i].position = new Vector3((i - 1) * incrementX, 0f, gameObject.transform.position.x);

                //Changing color of graph:
                points[i].color = new Color(255, 255, 255);
                //Size of graph:
                points[i].size = 0.05f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDist : MonoBehaviour
{
    // source: https://www.alanzucconi.com/2015/09/16/how-to-sample-from-a-gaussian-distribution/
    public float StandardNormalDistribution(float mean = 0, float standardDeviation = 1, float min = -3, float max = 3)
    {
        float x;

        do
        {
            x = mean + NextGaussian() * standardDeviation;
        } while ((x < min || x > max));

        return x;
    }


    private float NextGaussian()
    {
        float v1, v2, s;

        do
        {
            v1 = 2.0f * Random.Range(0f, 1f) - 1f;
            v2 = 2.0f * Random.Range(0f, 1f) - 1f;
            s = v1 * v1 + v2 * v2;
        } while (s >= 1.0f || s == 0f);

        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);


        return v1 * s;
    }
}

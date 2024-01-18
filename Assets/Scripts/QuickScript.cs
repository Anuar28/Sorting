using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickScript : MonoBehaviour

{
    GameObject[] balls;

    void Start()
    {
        balls = new GameObject[10];

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = Instantiate(Resources.Load("Ball")) as GameObject;

            Transform ballTransform = balls[i].GetComponent<Transform>();

            Renderer ballRenderer = balls[i].GetComponent<Renderer>();

            float size = Random.Range(0.5f, 2f);

            Color color = Random.ColorHSV();

            ballTransform.localScale = new Vector3(size, size, size);

            ballRenderer.material.color = color;

            ballTransform.position = new Vector3(0, size, 0);
        }

        QuickSort(balls, 0, balls.Length - 1);

        Visualize(balls);
    }

    void QuickSort(GameObject[] array, int low, int high)
    {
        if (low < high)
        {
            GameObject pivot = array[high];

            float pivotSize = pivot.GetComponent<Transform>().localScale.x;

            int i = low - 1;

            GameObject temp;

            for (int j = low; j < high; j++)
            {
                float size = array[j].GetComponent<Transform>().localScale.x;

                if (size <= pivotSize)
                {
                    i++;

                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;

            int pivotIndex = i + 1;

            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    void Visualize(GameObject[] array)
    {
        float x = -10f;

        for (int i = 0; i < array.Length; i++)
        {
            Transform ballTransform = array[i].GetComponent<Transform>();

            ballTransform.position = new Vector3(x, ballTransform.position.y, 0);

            x += 1f;
        }
    }
}


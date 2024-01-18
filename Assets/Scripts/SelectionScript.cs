using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
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

        SelectionSort(balls);

        Visualize(balls);
    }

    void SelectionSort(GameObject[] array)
    {
        int minIndex;

        GameObject temp;

        float size;

        for (int i = 0; i < array.Length - 1; i++)
        {
            minIndex = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                size = array[j].GetComponent<Transform>().localScale.x;

                if (size < array[minIndex].GetComponent<Transform>().localScale.x)
                {
                    minIndex = j;
                }
            }

            temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    void Visualize(GameObject[] array)
    {
        float x = -20f;

        for (int i = 0; i < array.Length; i++)
        {
            Transform ballTransform = array[i].GetComponent<Transform>();

            ballTransform.position = new Vector3(x, ballTransform.position.y, 0);

            x += 1f;
        }
    }
}

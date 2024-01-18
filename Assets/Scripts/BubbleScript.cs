using UnityEngine;

public class BubbleScript : MonoBehaviour
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

        BubbleSort(balls);

        Visualize(balls);
    }

    void BubbleSort(GameObject[] array)
    {
        GameObject temp;

        float size;

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                size = array[j].GetComponent<Transform>().localScale.x;

                if (size > array[j + 1].GetComponent<Transform>().localScale.x)
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    void Visualize(GameObject[] array)
    {
        float x = 0f;

        for (int i = 0; i < array.Length; i++)
        {
            Transform ballTransform = array[i].GetComponent<Transform>();

            ballTransform.position = new Vector3(x, ballTransform.position.y, 0);

            x += 1f;
        }
    }
}


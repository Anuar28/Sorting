using UnityEngine;

public class InsertionScript : MonoBehaviour

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

        InsertionSort(balls);

        Visualize(balls);
    }

    void InsertionSort(GameObject[] array)
    {
        GameObject current;

        float size;

        for (int i = 1; i < array.Length; i++)
        {
            current = array[i];

            size = current.GetComponent<Transform>().localScale.x;

            int j = i - 1;
            while (j >= 0 && array[j].GetComponent<Transform>().localScale.x > size)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = current;
        }
    }

    void Visualize(GameObject[] array)
    {
        float x = -30f;

        for (int i = 0; i < array.Length; i++)
        {
            Transform ballTransform = array[i].GetComponent<Transform>();

            ballTransform.position = new Vector3(x, ballTransform.position.y, 0);

            x += 1f;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongButton : MonoBehaviour
{
    MeshRenderer mr;

    float timer;
    public float goodTimeRange;
    public float excellentTimeRange;
    public float perfectTimeRange;

    public enum State { good, excellent, perfect }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer < goodTimeRange)
        {
            state = State.good;
            mr.material.color = Color.green;
        }

        if (timer >= goodTimeRange && timer < goodTimeRange + excellentTimeRange)
        {
            state = State.excellent;
            mr.material.color = Color.yellow;
        }

        if (timer >= goodTimeRange + excellentTimeRange && timer < goodTimeRange + excellentTimeRange + 2 * perfectTimeRange)
        {
            state = State.perfect;
            mr.material.color = Color.red;
        }

        if (timer >= goodTimeRange + excellentTimeRange + 2 * perfectTimeRange && timer < goodTimeRange + 2 * excellentTimeRange + 2 * perfectTimeRange)
        {
            state = State.excellent;
            mr.material.color = Color.yellow;
        }

        if (timer >= goodTimeRange + 2 * excellentTimeRange + 2 * perfectTimeRange && timer < 2 * goodTimeRange + 2 * excellentTimeRange + 2 * perfectTimeRange)
        {
            state = State.good;
            mr.material.color = Color.green;
        }

        if (timer >= (goodTimeRange + excellentTimeRange + perfectTimeRange) * 2)
        {
            Debug.Log("Missed!");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (state)
            {
                case State.good:
                    Debug.Log("Good!");
                    break;
                case State.excellent:
                    Debug.Log("Excellent!");
                    break;
                case State.perfect:
                    Debug.Log("Perfect!");
                    break;
            }
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;

public class Radio : MonoBehaviour 
{
    string content = "hello world, how's it going. something about a secret message is being displayed";
    public Text display;

    StringBuilder builder;

    int[] scrambler;

    void Start ()
	{
        builder = new StringBuilder();

        scrambler = Scramble(content);
        StartCoroutine(FillTextRoutine(content));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < builder.Length; i++)
            {
                builder[i] = Offset(builder[i], scrambler[i]);
            }
        }
		else if (Input.GetKeyDown(KeyCode.S))
        {
			for (int i = 0; i < builder.Length; i++)
            {
                builder[i] = Offset(builder[i], -scrambler[i]);
            }
        }

        display.text = builder.ToString();
    }

    IEnumerator FillTextRoutine(string fill)
    {
        for (int i = 0; i < fill.Length; i++)
		{
			builder.Append(fill[i]);

			yield return new WaitForSeconds(0.1f);
		}
    }

    char Offset(char c, int offset)
    {
        return (Char)(Convert.ToUInt16(c) + offset);
    }

    int[] Scramble(string fill)
    {
		int[] scramble = new int[fill.Length];
        for (int i = 0; i < fill.Length; i++)
        {
            scramble[i] = UnityEngine.Random.Range(0, 25);
        }

        return scramble;
    }
}
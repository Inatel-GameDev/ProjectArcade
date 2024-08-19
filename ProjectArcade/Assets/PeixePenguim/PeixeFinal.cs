using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeFinal : Nadador
{
    [SerializeField] GameManager gameManager;

    void Update()
    {
        {
            if (!pescado)
            {
                if (subindo)
                {
                    rb.velocity = new Vector2(speedH, speedV);
                }
                else
                {
                    rb.velocity = new Vector2(speedH, -speedV);
                }

                if (subindo && rb.transform.position.y > maxHeight)
                {
                    subindo = false;
                }

                if (!subindo && rb.transform.position.y < minHeight)
                {
                    subindo = true;
                }
            }
            else
            {
                float y = camera.ScreenToWorldPoint(Input.mousePosition).y;
                if (y > 13f)
                {
                    y = 13f;
                }
                else if (y < 5.5f)
                {
                    y = 5.5f;
                }

                transform.position = new Vector3(13.6f, y, 0);
            }

            if (rb.transform.position.x > 19)
            {
                gameManager.Ganhou();
                Destroy(gameObject);
            }

        }
    }
}

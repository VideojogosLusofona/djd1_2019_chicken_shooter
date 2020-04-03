using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time;

    // 3. TIMER CRESCENTE
    //float startTime;

    // 4. TIMER DECRESCENTE
    //float timer;

    // Start is called before the first frame update
    void Start()
    {
        // 1. DESTRUIR O OBJECTO PASSADO ALGUM TEMPO
        Destroy(gameObject, time);

        // 2. CHAMAR UMA FUNÇÃO PASSADO ALGUM TEMPO
        //Invoke("DestroySelf", time);


        // 3. FAZ O SETUP DE UM TIMER CRESCENTE
        //startTime = Time.time;

        // 4. FAZ O SETUP DE UM TIMER DECRESCENTE
        //timer = time;

        // 5. USAR UMA COROUTINA
        //StartCoroutine(DestroyInABit(time));
    }

    // Update is called once per frame
    void Update()
    {
        // 3. SE JÁ SE PASSOU TEMPO SUFICIENTE, DESTROI O OBJECTO
        /*float elapsedTime = Time.time - startTime;

        if (elapsedTime > (time / 2))
        {
            float r = Random.Range(4.0f, 6.0f);

            transform.localScale = new Vector3(r, r, r);
        }

        if (elapsedTime > time)
        {
            Destroy(gameObject);
        }*/

        // 4. DECREMENTAMOS O TIMER E VEMOS SE O SEU VALOR É MAIOR QUE 0
        /*timer = timer - Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(gameObject);
        }*/
    }

    void DestroySelf()
    {
        // 2. FUNÇÃO DESTROI O OBJECTO
        Destroy(gameObject);
    }

    IEnumerator DestroyInABit(float time)
    {
        // 5a. CHANGE COLOR 16 TIMES BEFORE DESTROYING THE OBJECT
        /*for (int i = 0; i < 16; i++)
        {
            Color c = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1.0f, 0.75f);

            GetComponent<SpriteRenderer>().color = c;

            yield return null;
        }*/

        // 5b. JUST WAIT FOR SOME TIME BEFORE DESTROYING THE OBJECT
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}

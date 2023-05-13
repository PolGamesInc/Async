using System;
using System.Threading.Tasks;

using UnityEngine;

public class Example : MonoBehaviour
{
   [SerializeField] private Transform[] cubes;
   
   private void Start()
   {
       //StartCoroutine(LifeCorutine());
       lifeasync();
   }
   
   /*private IEnumerator LifeCorutine()
   {
       for (int i = 0; i < cubes.Length; i++)
       {
           yield return StartCoroutine(RotateCorutine(cubes[i]));
       }
   }

   private IEnumerator RotateCorutine(Transform o)
   {
       float time = 0;
       
       while (time < 3)
       {
           time = Math.Min(time + Time.deltaTime, 3);
           o.Rotate(Vector3.up, 2);
       }

       return null;
   }*/

   private async void lifeasync()
   {
       for (int i = 0; i < cubes.Length; i++)
       {
          await rotateAsync(cubes[i]);
       }
   }

   private async Task rotateAsync(Transform o)
   {
       float time = 0;
       
       while (time < 3)
       {
           time = Math.Min(time + Time.deltaTime, 3);
           o.Rotate(Vector3.up, 0.5f);
           await Task.Yield();
       }
   }
}

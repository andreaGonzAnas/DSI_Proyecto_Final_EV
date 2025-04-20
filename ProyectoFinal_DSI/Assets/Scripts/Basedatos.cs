using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;


namespace Final_namespace
{
    public class Basedatos
    {
        public static List<Individuo> getData(List<Individuo> jsonId)
        {
            List<Individuo> datos = new List<Individuo>();

            Individuo c1 = new Individuo(

                Resources.Load<Sprite>("mizi")

             );

            Individuo c2 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c3 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c4 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c5 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c6 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c7 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c8 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c9 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c10 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c11 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c12 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c13 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c14 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
            Individuo c15 = new Individuo(

               Resources.Load<Sprite>("mizi")

            );
         
            datos.Add(c1);
            datos.Add(c2);
            datos.Add(c3);
            datos.Add(c4);
            datos.Add(c5);
            datos.Add(c6);
            datos.Add(c7);
            datos.Add(c8);
            datos.Add(c9);
            datos.Add(c10);
            datos.Add(c11);
            datos.Add(c12);
            datos.Add(c13);
            datos.Add(c14);
            datos.Add(c15);

            //List<Individuo> datos = jsonId;
            return datos;
        }
    }
}
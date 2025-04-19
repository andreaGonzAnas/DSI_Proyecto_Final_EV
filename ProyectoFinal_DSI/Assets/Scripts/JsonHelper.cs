using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Final_namespace
{


    [SerializeField]
    public static class JsonHelper
    {

        [SerializeField]
        public static List<Individuo> FromJson<Individuo>(string json)
        {
            ListaIndividuo<Individuo> listaIndividuo = JsonUtility.FromJson<ListaIndividuo<Individuo>>(json);
            return listaIndividuo.individuos;
        }

        [SerializeField]
        public static string ToJSon<Individuo>(List<Individuo> lista)
        {
            ListaIndividuo<Individuo> listaIndividuo = new ListaIndividuo<Individuo>();
            listaIndividuo.individuos = lista;
            return JsonUtility.ToJson(listaIndividuo);
        }

        [SerializeField]
        public static string ToJSon<IndividuoType>(List<IndividuoType> lista, bool prettyPrint)
        {
            ListaIndividuo<IndividuoType> listaIndividuo = new ListaIndividuo<IndividuoType>();
            listaIndividuo.individuos = lista;
            return JsonUtility.ToJson(listaIndividuo,prettyPrint);
        }

        [Serializable]
        private class ListaIndividuo<Individuo>
        {
            [SerializeField] public List<Individuo> individuos;
        }
    }

}
using UnityEngine.UIElements;
using UnityEngine;
using System;
using static Unity.VisualScripting.LudiqRootObjectEditor;


namespace Final_namespace
{
    public class Card
    {
        Individuo miIndividuo;

        VisualElement tarjetaRoot;

        VisualElement imagen;

        public Card(VisualElement tarjetaRoot, Individuo individuo)
        {
            Debug.Log("Crea carta");

            Debug.Log("root: " + tarjetaRoot + "individuo: " + individuo);
            this.tarjetaRoot = tarjetaRoot;
            this.miIndividuo = individuo;

            imagen = tarjetaRoot.Q<VisualElement>("Image");
            tarjetaRoot.userData = miIndividuo;


            tarjetaRoot
                .Query(className: "Card")
                .Descendents<VisualElement>()
                .ForEach(elem => elem.pickingMode = PickingMode.Ignore);

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }

        void UpdateUI()
        {

            if (miIndividuo.Image != null)
            {
                imagen.style.backgroundImage = new StyleBackground(miIndividuo.Image);
            }


        }
    }

}

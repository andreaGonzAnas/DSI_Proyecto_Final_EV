using UnityEngine.UIElements;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using static Unity.VisualScripting.LudiqRootObjectEditor;
using static UnityEngine.GraphicsBuffer;


namespace Final_namespace
{


    public class Final : MonoBehaviour
    {
        VisualElement botonCrear;
        VisualElement botonGuardar;
        VisualElement botonCargar;
        //Toggle toggleModificar;
        VisualElement contenedor_menu;
        VisualElement content;
        VisualElement characters;

        VisualElement chart;
        VisualElement l1;
        VisualElement l2;
        VisualElement l3;
        VisualElement l4;

        List<Individuo> individuos = new List<Individuo>();

        Individuo selecIndividuo;

        VisualElement card1;
        VisualElement card2;
        VisualElement card3;
        VisualElement card4;
        VisualElement card5;
        VisualElement card6;
        VisualElement card7;
        VisualElement card8;
        VisualElement card9;
        VisualElement card10;
        VisualElement card11;
        VisualElement card12;
        VisualElement card13;
        VisualElement card14;
        VisualElement card15;
        

        TextField input_nombre;
        TextField input_apellido;

        VisualElement img1;
        VisualElement img2;
        VisualElement img3;
        VisualElement img4;

        Sprite imagen1;
        Sprite imagen2;
        Sprite imagen3;
        Sprite imagen4;



        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            Debug.Log("root: " + root);

            contenedor_menu = root.Q<VisualElement>("Menu");
           
            Debug.Log("contenedor_menu: " + contenedor_menu);

            //botonGuardar = root.Q<Button>("BotonGuardar");
            //botonCargar = root.Q<Button>("BotonCargar");
            //toggleModificar = root.Q<Toggle>("ToggleModificar");


            //vamos a intentarlo

            content = contenedor_menu.Q<VisualElement>("Content");
            characters = contenedor_menu.Q<VisualElement>("character");

            //vamos a intentarl p2

            chart = root.Q<VisualElement>("Chart");
            l1 = chart.Q<VisualElement>("1");
            l2 = chart.Q<VisualElement>("2");
            l3 = chart.Q<VisualElement>("3");
            l4 = chart.Q<VisualElement>("4");

            //llorando

            Debug.Log("l1: " + l1);
            Debug.Log("l2: " + l2);
            Debug.Log("l3: " + l3);
            Debug.Log("l4: " + l4);


            card1 = l4.Q("C1");
            card2 = l4.Q("C2");
            card3 = l4.Q("C3");
            card4 = l4.Q("C4");
            card5 = l4.Q("C5");
            card6 = l4.Q("C6");
            card7 = l4.Q("C7");
            card8 = l4.Q("C8");

            card9 = l3.Q("C9");
            card10 = l3.Q("C10");
            card11 = l3.Q("C11");
            card12 = l3.Q("C12");

            card13 = l2.Q("C13");
            card14 = l2.Q("C14");

            card15 = l1.Q("C15");
            

            imagen1 = Resources.Load<Sprite>("mizi");
            imagen2 = Resources.Load<Sprite>("sua");
            imagen3 = Resources.Load<Sprite>("till");
            imagen4 = Resources.Load<Sprite>("ivan");


            img1 = root.Q<VisualElement>("Mizi");
            img2 = root.Q<VisualElement>("Sua");
            img3 = root.Q<VisualElement>("Till");
            img4 = root.Q<VisualElement>("Ivan");


            

            VisualElement selec1 = chart.Q("1");
            VisualElement selec2 = chart.Q("2");
            VisualElement selec3 = chart.Q("3");
            VisualElement selec4 = chart.Q("4");

            selec1.RegisterCallback<ClickEvent>(seleccionTarjeta);
            selec2.RegisterCallback<ClickEvent>(seleccionTarjeta);
            selec3.RegisterCallback<ClickEvent>(seleccionTarjeta);
            selec4.RegisterCallback<ClickEvent>(seleccionTarjeta);

            img1.RegisterCallback<ClickEvent>(e => CambioImagen(imagen1));
            img2.RegisterCallback<ClickEvent>(e => CambioImagen(imagen2));
            img3.RegisterCallback<ClickEvent>(e => CambioImagen(imagen3));
            img4.RegisterCallback<ClickEvent>(e => CambioImagen(imagen4));

            characters.RegisterCallback<ClickEvent>(seleccionTarjeta);


            //botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
            //botonGuardar.RegisterCallback<ClickEvent>(GuardarJson);
            //botonCargar.RegisterCallback<ClickEvent>(CargarJson);
            //input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            //input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

            individuos = Basedatos.getData(individuos);

            InitializeUI();
        }

        

        void CambioImagen(Sprite imagen)
        {
            Debug.Log("Entro imagen");

            Debug.Log(selecIndividuo);
            if (selecIndividuo != null)
            {
                Debug.Log(imagen);
                selecIndividuo.Image = imagen;
            }

        }

        void seleccionTarjeta(ClickEvent e)
        {
            VisualElement tarjeta = e.target as VisualElement;
            Debug.Log(tarjeta);
            selecIndividuo = tarjeta.userData as Individuo;
            Debug.Log(selecIndividuo);



        }

        void InitializeUI()
        {

            Debug.Log("card1: "+ card1);
            Card c1 = new Card(card1, individuos[0]);
            Card c2 = new Card(card2, individuos[1]);
            Card c3 = new Card(card3, individuos[2]);
            Card c4 = new Card(card4, individuos[3]);
            Card c5 = new Card(card5, individuos[4]);
            Card c6 = new Card(card6, individuos[5]);
            Card c7 = new Card(card7, individuos[6]);
            Card c8 = new Card(card8, individuos[7]);
            Card c9 = new Card(card9, individuos[8]);
            Card c10 = new Card(card10, individuos[9]);
            Card c11 = new Card(card11, individuos[10]);
            Card c12 = new Card(card12, individuos[11]);
            Card c13 = new Card(card13, individuos[12]);
            Card c14 = new Card(card14, individuos[13]);
            Card c15 = new Card(card15, individuos[14]);

            

        }

        /*void NuevaTarjeta(ClickEvent evt)
        {
            if (!toggleModificar.value)
            {
                VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
                VisualElement tarjetaPlantilla = plantilla.Instantiate();

                contenedor_dcha.Add(tarjetaPlantilla);
                tarjetas_borde_negro();
                tarjetas_borde_blanco(tarjetaPlantilla);

                Individuo individuo = new Individuo(input_nombre.value, input_apellido.value, imagen1);
                Card tarjeta = new Card(tarjetaPlantilla, individuo);
                selecIndividuo = individuo;

                Debug.Log(individuos);
                individuos.Add(individuo);
                individuos.ForEach(elem => Debug.Log(elem.Nombre + " " + elem.Apellido));
            }
        }

        void tarjetas_borde_negro()
        {
            List<VisualElement> list = contenedor_dcha.Children().ToList();
            list.ForEach(elem =>
            {
                VisualElement tarjeta = elem.Q("Tarjeta");

                tarjeta.style.borderBottomColor = Color.black;
                tarjeta.style.borderRightColor = Color.black;
                tarjeta.style.borderTopColor = Color.black;
                tarjeta.style.borderLeftColor = Color.black;

            });

        }

        void tarjetas_borde_blanco(VisualElement tar)
        {

            VisualElement tarjeta = tar.Q("Tarjeta");

            tarjeta.style.borderBottomColor = Color.white;
            tarjeta.style.borderRightColor = Color.white;
            tarjeta.style.borderTopColor = Color.white;
            tarjeta.style.borderLeftColor = Color.white;



        }

        private void GuardarJson(ClickEvent evt)
        {
            string rutaArchivo = Application.persistentDataPath + "/individuos.json"; //Guardamos la ruta del Json
            string listaToJson = JsonHelper.ToJSon(individuos, true); // Convierte la lista a JSON
            File.WriteAllText(rutaArchivo, listaToJson); // Guarda el JSON en un archivo
            Debug.Log("Archivo JSON guardado en: " + rutaArchivo);
        }

        private void CargarJson(ClickEvent evt)
        {
            string rutaArchivo = Application.persistentDataPath + "/individuos.json";
            if (File.Exists(rutaArchivo)) // Verifica si el archivo existe
            {
                string jsonDesdeArchivo = File.ReadAllText(rutaArchivo); // Lee el contenido del archivo
                List<Individuo> jsonToLista = JsonHelper.FromJson<Individuo>(jsonDesdeArchivo); // Convierte el JSON en lista
                individuos = Basedatos.getData(jsonToLista);
                Debug.Log(individuos);

                individuos.ForEach(elem =>
                {
                    Debug.Log(elem.Nombre + " " + elem.Apellido + " " + elem.Image.name);

                    // Recrea las tarjetas visuales al cargar
                    VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
                    VisualElement tarjetaPlantilla = plantilla.Instantiate();
                    contenedor_dcha.Add(tarjetaPlantilla);

                    Card tarjeta = new Card(tarjetaPlantilla, elem);
                });

                Debug.Log("Datos cargados desde el archivo JSON.");
            }
        }*/


    }
}

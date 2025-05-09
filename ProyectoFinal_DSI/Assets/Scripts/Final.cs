using UnityEngine.UIElements;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using static Unity.VisualScripting.LudiqRootObjectEditor;
using static UnityEngine.GraphicsBuffer;
using UnityEditor.U2D;


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
        VisualElement tabs;

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
        VisualElement img5;
        VisualElement img6;

        Sprite imagen1;
        Sprite imagen2;
        Sprite imagen3;
        Sprite imagen4;
        Sprite imagen5;
        Sprite imagen6;

        bool changeImage = false;

        Hearts hearts;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            contenedor_menu = root.Q<VisualElement>("Menu");
           
            //vamos a intentarlo
            
            content = contenedor_menu.Q<VisualElement>("Content");
            characters = contenedor_menu.Q<VisualElement>("character");
            
            VisualElement saveLoad = content.Q<VisualElement>("save");

            botonGuardar = saveLoad.Q<Button>("Save");
            botonCargar = saveLoad.Q<Button>("Load");

            chart = root.Q<VisualElement>("Chart");

            l1 = chart.Q<VisualElement>("1");
            l2 = chart.Q<VisualElement>("2");
            l3 = chart.Q<VisualElement>("3");
            l4 = chart.Q<VisualElement>("4");


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
            imagen5 = Resources.Load<Sprite>("luka");
            imagen6 = Resources.Load<Sprite>("ImagenVacia");


            img1 = root.Q<VisualElement>("Mizi");
            img2 = root.Q<VisualElement>("Sua");
            img3 = root.Q<VisualElement>("Till");
            img4 = root.Q<VisualElement>("Ivan");
            img5 = root.Q<VisualElement>("Luka");
            img6 = root.Q<VisualElement>("Reset");


            VisualElement selec4 = chart.Q("4");
 
            VisualElement pass4 = chart.Q("4");
            VisualElement pass3 = chart.Q("3");
            VisualElement pass2 = chart.Q("2");

            
            selec4.RegisterCallback<ClickEvent>(seleccionTarjeta);

            pass4.RegisterCallback<ClickEvent>(Pass);
            pass3.RegisterCallback<ClickEvent>(Pass);
            pass2.RegisterCallback<ClickEvent>(Pass);

            img1.RegisterCallback<ClickEvent>(e => CambioImagen(imagen1));
            img2.RegisterCallback<ClickEvent>(e => CambioImagen(imagen2));
            img3.RegisterCallback<ClickEvent>(e => CambioImagen(imagen3));
            img4.RegisterCallback<ClickEvent>(e => CambioImagen(imagen4));
            img5.RegisterCallback<ClickEvent>(e => CambioImagen(imagen5));
            img6.RegisterCallback<ClickEvent>(e => CambioImagen(imagen6));

            characters.RegisterCallback<ClickEvent>(seleccionTarjeta);

            

            
            botonGuardar.RegisterCallback<ClickEvent>(GuardarJson);
            botonCargar.RegisterCallback<ClickEvent>(CargarJson);
            

            individuos = Basedatos.getData();

            InitializeUI();

            setHearts();
        }

        
        void Pass(ClickEvent e)
        {
            VisualElement tarjeta = e.target as VisualElement;
            selecIndividuo = tarjeta.userData as Individuo;
           
            if (selecIndividuo != null)
            {
                // PAR 0 y 1 -> destino 8
                if (individuos[0] == selecIndividuo || individuos[1] == selecIndividuo)
                {
                    int selectedIndex = individuos[0] == selecIndividuo ? 0 : 1;
                    int otherIndex = selectedIndex == 0 ? 1 : 0;

                    string selectedName = individuos[selectedIndex].Image.name;
                    bool isSelectedRed = selectedName.EndsWith("R");

                    if (selecIndividuo.Image.name != "ImagenVacia" && selecIndividuo.Image.name != "ImagenVaciaR")
                    {
                        if (isSelectedRed)
                        {
                            string newSelectedName = selectedName.Substring(0, selectedName.Length - 1);
                            Sprite selectedSprite = Resources.Load<Sprite>(newSelectedName);
                            individuos[selectedIndex].Image = selectedSprite;

                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                        else
                        {
                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                    }
                    else
                    {
                        string otherName = individuos[otherIndex].Image.name;
                        if (otherName.EndsWith("R"))
                        {
                            string newOtherName = otherName.Substring(0, otherName.Length - 1);
                            Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                            individuos[otherIndex].Image = otherSprite;
                        }
                    }

                    individuos[8].Image = individuos[selectedIndex].Image;
                }

                // PAR 2 y 3 -> destino 9
                if (individuos[2] == selecIndividuo || individuos[3] == selecIndividuo)
                {
                    int selectedIndex = individuos[2] == selecIndividuo ? 2 : 3;
                    int otherIndex = selectedIndex == 2 ? 3 : 2;

                    string selectedName = individuos[selectedIndex].Image.name;
                    bool isSelectedRed = selectedName.EndsWith("R");

                    if (selecIndividuo.Image.name != "ImagenVacia" && selecIndividuo.Image.name != "ImagenVaciaR")
                    {
                        if (isSelectedRed)
                        {
                            string newSelectedName = selectedName.Substring(0, selectedName.Length - 1);
                            Sprite selectedSprite = Resources.Load<Sprite>(newSelectedName);
                            individuos[selectedIndex].Image = selectedSprite;

                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                        else
                        {
                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                    }
                    else
                    {
                        string otherName = individuos[otherIndex].Image.name;
                        if (otherName.EndsWith("R"))
                        {
                            string newOtherName = otherName.Substring(0, otherName.Length - 1);
                            Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                            individuos[otherIndex].Image = otherSprite;
                        }
                    }

                    individuos[9].Image = individuos[selectedIndex].Image;
                }

                // PAR 4 y 5 -> destino 10
                if (individuos[4] == selecIndividuo || individuos[5] == selecIndividuo)
                {
                    int selectedIndex = individuos[4] == selecIndividuo ? 4 : 5;
                    int otherIndex = selectedIndex == 4 ? 5 : 4;

                    string selectedName = individuos[selectedIndex].Image.name;
                    bool isSelectedRed = selectedName.EndsWith("R");

                    if (selecIndividuo.Image.name != "ImagenVacia" && selecIndividuo.Image.name != "ImagenVaciaR")
                    {
                        if (isSelectedRed)
                        {
                            string newSelectedName = selectedName.Substring(0, selectedName.Length - 1);
                            Sprite selectedSprite = Resources.Load<Sprite>(newSelectedName);
                            individuos[selectedIndex].Image = selectedSprite;

                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                        else
                        {
                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                    }
                    else
                    {
                        string otherName = individuos[otherIndex].Image.name;
                        if (otherName.EndsWith("R"))
                        {
                            string newOtherName = otherName.Substring(0, otherName.Length - 1);
                            Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                            individuos[otherIndex].Image = otherSprite;
                        }
                    }

                    individuos[10].Image = individuos[selectedIndex].Image;
                }

                // PAR 6 y 7 -> destino 11
                if (individuos[6] == selecIndividuo || individuos[7] == selecIndividuo)
                {
                    int selectedIndex = individuos[6] == selecIndividuo ? 6 : 7;
                    int otherIndex = selectedIndex == 6 ? 7 : 6;

                    string selectedName = individuos[selectedIndex].Image.name;
                    bool isSelectedRed = selectedName.EndsWith("R");

                    if (selecIndividuo.Image.name != "ImagenVacia" && selecIndividuo.Image.name != "ImagenVaciaR")
                    {
                        if (isSelectedRed)
                        {
                            string newSelectedName = selectedName.Substring(0, selectedName.Length - 1);
                            Sprite selectedSprite = Resources.Load<Sprite>(newSelectedName);
                            individuos[selectedIndex].Image = selectedSprite;

                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                        else
                        {
                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                    }
                    else
                    {
                        string otherName = individuos[otherIndex].Image.name;
                        if (otherName.EndsWith("R"))
                        {
                            string newOtherName = otherName.Substring(0, otherName.Length - 1);
                            Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                            individuos[otherIndex].Image = otherSprite;
                        }
                    }

                    individuos[11].Image = individuos[selectedIndex].Image;
                }

                // PAR 8 y 9 -> destino 12
                if (individuos[8] == selecIndividuo || individuos[9] == selecIndividuo)
                {
                    int selectedIndex = individuos[8] == selecIndividuo ? 8 : 9;
                    int otherIndex = selectedIndex == 8 ? 9 : 8;

                    string selectedName = individuos[selectedIndex].Image.name;
                    bool isSelectedRed = selectedName.EndsWith("R");

                    if (selecIndividuo.Image.name != "ImagenVacia" && selecIndividuo.Image.name != "ImagenVaciaR")
                    {
                        if (isSelectedRed)
                        {
                            string newSelectedName = selectedName.Substring(0, selectedName.Length - 1);
                            Sprite selectedSprite = Resources.Load<Sprite>(newSelectedName);
                            individuos[selectedIndex].Image = selectedSprite;

                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                        else
                        {
                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                    }
                    else
                    {
                        string otherName = individuos[otherIndex].Image.name;
                        if (otherName.EndsWith("R"))
                        {
                            string newOtherName = otherName.Substring(0, otherName.Length - 1);
                            Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                            individuos[otherIndex].Image = otherSprite;
                        }
                    }

                    individuos[12].Image = individuos[selectedIndex].Image;
                }

                // PAR 10 y 11 -> destino 13
                if (individuos[10] == selecIndividuo || individuos[11] == selecIndividuo)
                {
                    int selectedIndex = individuos[10] == selecIndividuo ? 10 : 11;
                    int otherIndex = selectedIndex == 10 ? 11 : 10;

                    string selectedName = individuos[selectedIndex].Image.name;
                    bool isSelectedRed = selectedName.EndsWith("R");

                    if (selecIndividuo.Image.name != "ImagenVacia" && selecIndividuo.Image.name != "ImagenVaciaR")
                    {
                        if (isSelectedRed)
                        {
                            string newSelectedName = selectedName.Substring(0, selectedName.Length - 1);
                            Sprite selectedSprite = Resources.Load<Sprite>(newSelectedName);
                            individuos[selectedIndex].Image = selectedSprite;

                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                        else
                        {
                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                    }
                    else
                    {
                        string otherName = individuos[otherIndex].Image.name;
                        if (otherName.EndsWith("R"))
                        {
                            string newOtherName = otherName.Substring(0, otherName.Length - 1);
                            Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                            individuos[otherIndex].Image = otherSprite;
                        }
                    }

                    individuos[13].Image = individuos[selectedIndex].Image;
                }

                // PAR 12 y 13 -> destino 14
                if (individuos[12] == selecIndividuo || individuos[13] == selecIndividuo)
                {
                    int selectedIndex = individuos[12] == selecIndividuo ? 12 : 13;
                    int otherIndex = selectedIndex == 12 ? 13 : 12;

                    string selectedName = individuos[selectedIndex].Image.name;
                    bool isSelectedRed = selectedName.EndsWith("R");

                    if (selecIndividuo.Image.name != "ImagenVacia" && selecIndividuo.Image.name != "ImagenVaciaR")
                    {
                        if (isSelectedRed)
                        {
                            string newSelectedName = selectedName.Substring(0, selectedName.Length - 1);
                            Sprite selectedSprite = Resources.Load<Sprite>(newSelectedName);
                            individuos[selectedIndex].Image = selectedSprite;

                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                        else
                        {
                            string otherName = individuos[otherIndex].Image.name;
                            if (!otherName.EndsWith("R"))
                            {
                                string newOtherName = otherName + "R";
                                Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                                individuos[otherIndex].Image = otherSprite;
                            }
                        }
                    }
                    else
                    {
                        string otherName = individuos[otherIndex].Image.name;
                        if (otherName.EndsWith("R"))
                        {
                            string newOtherName = otherName.Substring(0, otherName.Length - 1);
                            Sprite otherSprite = Resources.Load<Sprite>(newOtherName);
                            individuos[otherIndex].Image = otherSprite;
                        }
                    }

                    individuos[14].Image = individuos[selectedIndex].Image;
                }

            }

            setHearts();
        }
        void setHearts()
        {
            VisualElement heartsV = chart.Q<VisualElement>("Hearts");
            hearts = heartsV.Q<Hearts>("HeartsCustom");
            hearts.Estado = 0;

            //recorrer las cartas
            if (card9 != null)
            {
                if (individuos[8].Image == Resources.Load<Sprite>("ImagenVacia"))
                {
                    hearts.Estado++;
                }
            }

            if (card10 != null)
            {
                if (individuos[9].Image == Resources.Load<Sprite>("ImagenVacia"))
                {
                    hearts.Estado++;
                }
            }

            if (card11 != null)
            {
                if (individuos[10].Image == Resources.Load<Sprite>("ImagenVacia"))
                {
                    hearts.Estado++;
                }
            }

            if (card12 != null)
            {
                if (individuos[11].Image == Resources.Load<Sprite>("ImagenVacia"))
                {
                    hearts.Estado++;
                }
            }

            if (card13 != null)
            {
                if (individuos[12].Image == Resources.Load<Sprite>("ImagenVacia"))
                {
                    hearts.Estado++;
                }
            }

            if (card14 != null)
            {
                if (individuos[13].Image == Resources.Load<Sprite>("ImagenVacia"))
                {
                    hearts.Estado++;
                }
            }

            if (card15 != null)
            {
                if (individuos[14].Image == Resources.Load<Sprite>("ImagenVacia"))
                {
                    hearts.Estado++;
                    
                }
            }

            hearts.Estado++;

        }

        void CambioImagen(Sprite imagen)
        {
            if (selecIndividuo != null && changeImage)
            {
                selecIndividuo.Image = imagen;
            }

        }

        void seleccionTarjeta(ClickEvent e)
        {
            changeImage = true;
            VisualElement tarjeta = e.target as VisualElement;
            selecIndividuo = tarjeta.userData as Individuo;
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

       

        private void GuardarJson(ClickEvent evt)
        {
            string rutaArchivo = Application.persistentDataPath + "/individuos.json"; //Guardamos la ruta del Json
            string listaToJson = JsonHelper.ToJSon(individuos, true); // Convierte la lista a JSON
            File.WriteAllText(rutaArchivo, listaToJson); // Guarda el JSON en un archivo
        }

        private void CargarJson(ClickEvent evt)
        {
            string rutaArchivo = Application.persistentDataPath + "/individuos.json";

            // Verifica si el archivo existe
            if (File.Exists(rutaArchivo))
            {
                // Leer el contenido del archivo JSON
                string jsonContent = File.ReadAllText(rutaArchivo);

                // Deserializar el JSON en la lista de Individuos
                List<Individuo> jsonToLista = JsonHelper.FromJson<Individuo>(jsonContent);

                individuos = Basedatos.getDataJson(jsonToLista);

                InitializeUI();
                setHearts();
                
            }
            else
            {
                Debug.LogError("No se encontr� el archivo JSON en la ruta: " + rutaArchivo);
            }
        }

        private void AsignarImagenesACartas()
        {
            // Aseg�rate de que la lista de individuos tiene el tama�o correcto
            if (individuos.Count >= 15)
            {
                // Asigna las im�genes a las cartas
                card1.style.backgroundImage = new StyleBackground(individuos[0].Image);
                card2.style.backgroundImage = new StyleBackground(individuos[1].Image);
                card3.style.backgroundImage = new StyleBackground(individuos[2].Image);
                card4.style.backgroundImage = new StyleBackground(individuos[3].Image);
                card5.style.backgroundImage = new StyleBackground(individuos[4].Image);
                card6.style.backgroundImage = new StyleBackground(individuos[5].Image);
                card7.style.backgroundImage = new StyleBackground(individuos[6].Image);
                card8.style.backgroundImage = new StyleBackground(individuos[7].Image);
                card9.style.backgroundImage = new StyleBackground(individuos[8].Image);
                card10.style.backgroundImage = new StyleBackground(individuos[9].Image);
                card11.style.backgroundImage = new StyleBackground(individuos[10].Image);
                card12.style.backgroundImage = new StyleBackground(individuos[11].Image);
                card13.style.backgroundImage = new StyleBackground(individuos[12].Image);
                card14.style.backgroundImage = new StyleBackground(individuos[13].Image);
                card15.style.backgroundImage = new StyleBackground(individuos[14].Image);

                
            }
            else
            {
                Debug.LogError("La lista de individuos cargada no tiene suficientes elementos.");
            }
        }


    }
}

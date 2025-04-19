using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hearts : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    //crear 5 elementos
    VisualElement stat1 = new VisualElement();
    VisualElement stat2 = new VisualElement();
    VisualElement stat3 = new VisualElement();
    VisualElement stat4 = new VisualElement();
    VisualElement stat5 = new VisualElement();
    VisualElement stat6 = new VisualElement();
    VisualElement stat7 = new VisualElement();
    VisualElement stat8 = new VisualElement();


    int estado;
    public int Estado
    {
        get => estado;
        set
        {
            estado = value;
            encenderColor();
        }
    }

    string nameStat;
    public string NameStat
    {
        get => nameStat;
        set
        {
            nameStat = value;
            cambiarImagen();
        }
    }

    void encenderColor()
    {
        stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
        stat2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
        stat3.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
        stat4.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
        stat5.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
        stat6.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
        stat7.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
        stat8.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);


        if (Estado == 1)
        {
            stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        }
        if (Estado == 2)
        {
            stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        }
        if (Estado == 3)
        {
            stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat3.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        }
        if (Estado == 4)
        {
            stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat3.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat4.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        }
        if (Estado >= 5)
        {
            stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat3.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat4.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat5.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        }
        if (Estado >= 6)
        {
            stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat3.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat4.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat5.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat6.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        }
        if (Estado >= 7)
        {
            stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat3.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat4.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat5.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat6.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat7.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        }
        if (Estado >= 8)
        {
            stat1.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat3.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat4.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat5.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat6.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat7.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            stat8.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        }

    }

    void cambiarImagen()
    {
        string file = nameStat;
        Sprite nuevaImagen = Resources.Load<Sprite>(file);

        stat1.style.backgroundImage = new StyleBackground(nuevaImagen);
        stat2.style.backgroundImage = new StyleBackground(nuevaImagen);
        stat3.style.backgroundImage = new StyleBackground(nuevaImagen);
        stat4.style.backgroundImage = new StyleBackground(nuevaImagen);
        stat5.style.backgroundImage = new StyleBackground(nuevaImagen);
        stat6.style.backgroundImage = new StyleBackground(nuevaImagen);
        stat7.style.backgroundImage = new StyleBackground(nuevaImagen);
        stat8.style.backgroundImage = new StyleBackground(nuevaImagen);

    }

    public new class UxmlFactory : UxmlFactory<Hearts, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myEstado = new UxmlIntAttributeDescription { name = "estado", defaultValue = 0 };
        UxmlStringAttributeDescription myNameStat = new UxmlStringAttributeDescription { name = "nameStat", defaultValue = "oso" };


        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var semaforo = ve as Hearts;

            semaforo.Estado = myEstado.GetValueFromBag(bag, cc);
            semaforo.NameStat = myNameStat.GetValueFromBag(bag, cc);

        }

    }

    public Hearts()
    {
        cambiarImagen();

        // Configurar el tamaño del contenedor principal para ocupar todo el espacio
        style.flexGrow = 1;
        style.width = Length.Percent(100);
        style.height = Length.Percent(100);

        // Asegurar que los paneles ocupen el mismo espacio dentro de la fila
        stat1.style.flexGrow = 1;
        stat2.style.flexGrow = 1;
        stat3.style.flexGrow = 1;
        stat4.style.flexGrow = 1;
        stat5.style.flexGrow = 1;
        stat6.style.flexGrow = 1;
        stat7.style.flexGrow = 1;
        stat8.style.flexGrow = 1;

        styleSheets.Add(Resources.Load<StyleSheet>("ProyectoFinal"));

        stat2.AddToClassList("panel_round");
        stat1.AddToClassList("panel_round");
        stat3.AddToClassList("panel_round");
        stat4.AddToClassList("panel_round");
        stat5.AddToClassList("panel_round");
        stat6.AddToClassList("panel_round");
        stat7.AddToClassList("panel_round");
        stat8.AddToClassList("panel_round");

        style.flexDirection = FlexDirection.Row;


        // Añadir los elementos de stats al contenedor de estadísticas
        hierarchy.Add(stat1);
        hierarchy.Add(stat2);
        hierarchy.Add(stat3);
        hierarchy.Add(stat4);
        hierarchy.Add(stat5);
        hierarchy.Add(stat6);
        hierarchy.Add(stat7);
        hierarchy.Add(stat8);

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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

    List<VisualElement> stats;


    //texturas hearts
    Sprite aliveHeart = Resources.Load<Sprite>("heart");
    Sprite deadHeart = Resources.Load<Sprite>("dead");

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

    void initializeStats()
    {
        stats = new List<VisualElement> { stat1, stat2, stat3, stat4, stat5, stat6, stat7, stat8 };
    }

    void encenderColor()
    {
        for (int i = 0; i < stats.Count; i++)
        {
            if (i < Estado)
            {
                stats[i].style.backgroundImage = new StyleBackground(aliveHeart);
            }
            else
            {
                stats[i].style.backgroundImage = new StyleBackground(deadHeart);
            }
        }


    }


    public new class UxmlFactory : UxmlFactory<Hearts, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myEstado = new UxmlIntAttributeDescription { name = "estado", defaultValue = 0 };
        

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var semaforo = ve as Hearts;

            semaforo.Estado = myEstado.GetValueFromBag(bag, cc);

        }

    }

    public Hearts()
    {
        initializeStats();

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    VisualElement save_content;
    VisualElement character_content;

    VisualElement save_button;
    VisualElement character_button;

    private void NoContenido()
    {
        save_content.style.display = DisplayStyle.None;
        character_content.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        VisualElement content = rootve.Q("Content");
        VisualElement tabs = rootve.Q("Tabs");

        save_button = tabs.Q("saveButton");
        character_button = tabs.Q("characterButton");

        save_content = content.Q("save");
        character_content = content.Q("character");

        save_button.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("Pestaña azul");
            NoContenido();
            save_content.style.display = DisplayStyle.Flex;
        });

        character_button.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("Pestaña verde");
            NoContenido();
            character_content.style.display = DisplayStyle.Flex;
        });
    }
}

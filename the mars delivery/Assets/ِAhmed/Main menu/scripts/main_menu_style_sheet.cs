using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class main_menu_style_sheet : MonoBehaviour
{
    private UIDocument _document;
    private Label _label , _label1 , _label2;
    private Button _button , _button1 , _button2 , _button3, _button4, _button5, _button6, _button7 , _button8 , _button9, _button10, _button11;
    private List<Button> main_menu_buttons = new List<Button>();
    private AudioSource _audio;
    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _button = _document.rootVisualElement.Q("start") as Button;
        _button.RegisterCallback<ClickEvent>(on_play);
        _button1 = _document.rootVisualElement.Q("options") as Button;
        _button1.RegisterCallback<ClickEvent>(on_play1);
        _button2 = _document.rootVisualElement.Q("exit") as Button;
        _button2.RegisterCallback<ClickEvent>(on_play2);
        _button3 = _document.rootVisualElement.Q("level1") as Button;
        _button3.RegisterCallback<ClickEvent>(on_play3);
        _button4 = _document.rootVisualElement.Q("level2") as Button;
        _button4.RegisterCallback<ClickEvent>(on_play4);
        _button5 = _document.rootVisualElement.Q("level3") as Button;
        _button5.RegisterCallback<ClickEvent>(on_play5);
        _button6 = _document.rootVisualElement.Q("level4") as Button;
        _button6.RegisterCallback<ClickEvent>(on_play6);
        _button7 = _document.rootVisualElement.Q("level5") as Button;
        _button7.RegisterCallback<ClickEvent>(on_play7);
        _button8 = _document.rootVisualElement.Q("back") as Button;
        _button8.RegisterCallback<ClickEvent>(on_play8);
        _button9 = _document.rootVisualElement.Q("back1") as Button;
        _button9.RegisterCallback<ClickEvent>(on_play9);
        _button10 = _document.rootVisualElement.Q("music") as Button;
        _button10.RegisterCallback<ClickEvent>(on_play10);
        _button11 = _document.rootVisualElement.Q("sounds") as Button;
        _button11.RegisterCallback<ClickEvent>(on_play11);
        _label = _document.rootVisualElement.Q("main_menu") as Label;
        _label1 = _document.rootVisualElement.Q("levels") as Label;
        _label2 = _document.rootVisualElement.Q("options_label") as Label;
        _button3.style.display = DisplayStyle.None;
        _button4.style.display = DisplayStyle.None;
        _button5.style.display = DisplayStyle.None;
        _button6.style.display = DisplayStyle.None;
        _button7.style.display = DisplayStyle.None;
        _button8.style.display = DisplayStyle.None;
        _button9.style.display = DisplayStyle.None;
        _button10.style.display = DisplayStyle.None;
        _button11.style.display = DisplayStyle.None;
        _label1.style.display = DisplayStyle.None;
        _label2.style.display = DisplayStyle.None;
        _audio = GetComponent<AudioSource>();
        main_menu_buttons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < main_menu_buttons.Count; i++)
        {
            main_menu_buttons[i].RegisterCallback<ClickEvent>(on_all_button_click);
        }
    }
    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(on_play);
        _button1.UnregisterCallback<ClickEvent>(on_play1);
        _button2.UnregisterCallback<ClickEvent>(on_play2);
        _button3.UnregisterCallback<ClickEvent>(on_play3);
        _button4.UnregisterCallback<ClickEvent>(on_play4);
        _button5.UnregisterCallback<ClickEvent>(on_play5);
        _button6.UnregisterCallback<ClickEvent>(on_play6);
        _button7.UnregisterCallback<ClickEvent>(on_play7);
        _button8.UnregisterCallback<ClickEvent>(on_play8);
        _button9.UnregisterCallback<ClickEvent>(on_play9);
        _button10.UnregisterCallback<ClickEvent>(on_play10);
        _button11.UnregisterCallback<ClickEvent>(on_play11);
        for (int i = 0; i < main_menu_buttons.Count; i++)
        {
            main_menu_buttons[i].UnregisterCallback<ClickEvent>(on_all_button_click);
        }
    }
    private void on_play(ClickEvent click)
    {
        _button.style.display = DisplayStyle.None;
        _button1.style.display = DisplayStyle.None;
        _button2.style.display = DisplayStyle.None;
        _button3.style.display = DisplayStyle.Flex;
        _button4.style.display = DisplayStyle.Flex;
        _button5.style.display = DisplayStyle.Flex;
        _button6.style.display = DisplayStyle.Flex;
        _button7.style.display = DisplayStyle.Flex;
        _button8.style.display = DisplayStyle.Flex;
        _label.style.display = DisplayStyle.None;
        _label1.style.display = DisplayStyle.Flex;
        _label2.style.display = DisplayStyle.None;
    }
    private void on_play1(ClickEvent click)
    {
        _button.style.display = DisplayStyle.None;
        _button1.style.display = DisplayStyle.None;
        _button2.style.display = DisplayStyle.None;
        _button9.style.display = DisplayStyle.Flex;
        _button10.style.display = DisplayStyle.Flex;
        _button11.style.display = DisplayStyle.Flex;
        _label.style.display = DisplayStyle.None;
        _label1.style.display = DisplayStyle.None;
        _label2.style.display = DisplayStyle.Flex;
    }
    private void on_play2(ClickEvent click)
    {
        Debug.Log("you clicked exit button");
    }
    private void on_play3(ClickEvent click)
    {
        Debug.Log("you clicked exit button");
    }
    private void on_play4(ClickEvent click)
    {
        Debug.Log("you clicked exit button");
    }
    private void on_play5(ClickEvent click)
    {
        Debug.Log("you clicked exit button");
    }
    private void on_play6(ClickEvent click)
    {
        Debug.Log("you clicked exit button");
    }
    private void on_play7(ClickEvent click)
    {
        Debug.Log("you clicked exit button");
    }
    private void on_play8(ClickEvent click)
    {
        _button.style.display = DisplayStyle.Flex;
        _button1.style.display = DisplayStyle.Flex;
        _button2.style.display = DisplayStyle.Flex;
        _button3.style.display = DisplayStyle.None;
        _button4.style.display = DisplayStyle.None;
        _button5.style.display = DisplayStyle.None;
        _button6.style.display = DisplayStyle.None;
        _button7.style.display = DisplayStyle.None;
        _button8.style.display = DisplayStyle.None;
        _label.style.display = DisplayStyle.Flex;
        _label1.style.display = DisplayStyle.None;
        _label2.style.display = DisplayStyle.None;
    }
    private void on_play9(ClickEvent click)
    {
        _button.style.display = DisplayStyle.Flex;
        _button1.style.display = DisplayStyle.Flex;
        _button2.style.display = DisplayStyle.Flex;
        _button9.style.display = DisplayStyle.None;
        _button10.style.display = DisplayStyle.None;
        _button11.style.display = DisplayStyle.None;
        _label.style.display = DisplayStyle.Flex;
        _label1.style.display = DisplayStyle.None;
        _label2.style.display = DisplayStyle.None;
    }
    private void on_play10(ClickEvent click)
    {
        Debug.Log("you clicked exit button");
    }
    private void on_play11(ClickEvent click)
    {
        Debug.Log("you clicked exit button");
    }
    private void on_all_button_click(ClickEvent click)
    {
        _audio.Play();
    }
}

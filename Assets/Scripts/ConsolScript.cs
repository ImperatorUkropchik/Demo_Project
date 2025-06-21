using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Command
{
    public string Name;
    public string Description;

    public Command(string name, string description)
    {
        Name = name.ToLower(); // приведение к нижнему регистру
        Description = description;
    }
}

public class ConsolScript : MonoBehaviour
{
    public bool isConsolOpen = true;
    [SerializeField] private string inputText;
    public TMP_InputField inputField;
    private string trimmed;

    public TMP_Text outputText;
    public ScrollRect scrollRect;



    private List<Command> commands = new List<Command>()
{
    new Command("help", "Показать все доступные команды"),
    new Command("godmode", "Включает неуязвимость"),
    new Command("noclip", "Позволяет проходить сквозь стены"),
    new Command("clear", "Очищает консоль"),
    new Command("exit", "Выход из игры"),
    //new Command("save", "Сохраняет игру"),
    //new Command("load", "Загружает сохранение"),
    new Command("restart", "Перезапускает уровень"),
    //new Command("kill", "Самоубийство игрока"),
    new Command("volume", "Изменяет громкость (от 0 до 1). Пример: volume 0.3"),
    new Command("add_bullets", "Добавляет пули патроны. Пример: add_bullets 5")
};
    // Start is called before the first frame update
    void Start()
    {
        inputField.ActivateInputField();
    }
    public void takeInputText(string input)
    {
        string[] parts = input.Trim().ToLower().Split(' ');
        string commandName = parts[0];
        string argument = parts.Length > 1 ? parts[1] : null;

        if (input == string.Empty) return;
        trimmed = input.Trim().ToLower();
        if (trimmed == "help")
        {
            AppendToConsole("<color=lime>Список доступных команд:</color>");
            foreach (var cmd in commands)
            {
                AppendToConsole($"<color=orange>{cmd.Name}</color>: {cmd.Description}");
                inputField.text = "";
            }
            return;
        }
        if (commandName == "volume")
        {
            if (argument != null && float.TryParse(argument, out float volume))
            {
                volume = Mathf.Clamp01(volume); // Ограничим от 0 до 1
                GameObject GAS = GameObject.Find("GameController");
                AudioSource AS = GAS.GetComponent<AudioSource>();
                AS.volume = volume;
                AppendToConsole($"Громкость установлена на: {volume}");
                ReactionToInput();
            }
            else
            {
                AppendToConsole("Команда volume требует аргумент от 0 до 1. Пример: volume 0,5");
            }

            return;
        }
        if (commandName == "add_bullets")
        {
            if (argument != null && float.TryParse(argument, out float bul))
            {
                bul = Mathf.FloorToInt(bul); //
                AppendToConsole($"Добавленно патронов: {bul}");
                GameObject GO = GameObject.Find("Avto");
                Shoot SH = GO.GetComponent<Shoot>();
                SH.bulAmount += bul;
                SH.Obnovka();
                ReactionToInput();
            }
            else
            {
                AppendToConsole("Команда add_bullets требует целые числа от 0. Пример: add_bullets 3");
            }

            return;
        }
        if (commandName == "godmode")
        {
            if (argument != null && float.TryParse(argument, out float can))
            {
                AppendToConsole($"Значение godmode: {can}");
                GameObject GO = GameObject.Find("Priga");
                EnemyAIContr EAIC = GO.GetComponent<EnemyAIContr>();
                if(can == 0) EAIC.canHitPlayer = true;
                else if (can == 1) EAIC.canHitPlayer = false;
                else AppendToConsole("Команда godmode принимает только числа 0 и 1(1-вкл, 0-выкл). Пример: godmode 1");
                ReactionToInput();
            }
            else AppendToConsole("Команда godmode принимает только числа 0 и 1(1-вкл, 0-выкл). Пример: godmode 1");
            return;
        }

        if (commands.Exists(c => c.Name == trimmed))
        {
            checkCommands(trimmed);
        }
        else AppendToConsole($"<color=red> Command {trimmed} do not executed:</color>");
        inputText = input;
        ReactionToInput();
    }
    private void ReactionToInput()
    {
        Debug.Log(inputText);

        inputField.text = "";
        inputField.ActivateInputField();
    }
    private void checkCommands(string command)
    {

        if(command == "exit")
        {
            AppendToConsole($"Command {command} accepted!");
            SceneManager.LoadScene(0);
        }
        if (command == "help")
        {
            AppendToConsole($"Command {command} executed");
        }
        if (command == "clear")
        {
            AppendToConsole($"Command {command} executed");
            outputText.text = "";
        }
        if (command == "restart")
        {
            AppendToConsole($"Command {command} executed");
            SceneManager.LoadScene(1);
        }
    }
    void AppendToConsole(string text)
    {
        outputText.text += $"{text}\n";

        // Прокрутка вниз
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 1f;
    }
    // Update is called once per frame
    void Update()
    {


    }
}

using System;
using System.Collections.Generic;

class Program
{
    static List<Note> notes = new List<Note>();
    static int currentNoteIndex = 0;

    static void Main(string[] args)
    {
        // Создаем заметки со случайными датами 
        Random random = new Random();
        notes.Add(new Note { Name = "Сходить за пивом", Description = "Мне нужно 7 литров пива", Date = new DateTime(2023, 10, 20), Deadline = new DateTime(2023, 10, 22).AddDays(1) });
        notes.Add(new Note { Name = "Купить блок сигарет", Description = "У меня кончились сигареты, бегом восполнять потерю", Date = new DateTime(2023, 10, 22), Deadline = new DateTime(2023, 10, 23).AddDays(1) });
        notes.Add(new Note { Name = "Купить жижу, никобустер и испаритель", Description = "На моей курилке полетел испар и кончилось жижло", Date = new DateTime(2023, 10, 24), Deadline = new DateTime(2023, 10, 25).AddDays(1) });
        notes.Add(new Note { Name = "Сгонять за шайбой снюсика", Description = "Друзья посоветовали новую линейку снюсика, надо попробовать", Date = new DateTime(2023, 10, 26), Deadline = new DateTime(2023, 10, 28).AddDays(1) });
        notes.Add(new Note { Name = "Встретиться с кентафариком", Description = "Давненько не виделись с Бро, надо исправить", Date = new DateTime(2023, 11, 3), Deadline = new DateTime(2023, 11, 7).AddDays(1) });

        // Выводим первоначальное меню с названиями заметок 
        ShowMenu();

        // Ждем ввода пользователя 
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey();

            // При нажатии Enter открываем полную информацию о заметке 
            if (key.Key == ConsoleKey.Enter)
            {
                ShowNoteDetails(currentNoteIndex);
            }

            // Переключаемся между датами по стрелкам вправо-влево 
            if (key.Key == ConsoleKey.LeftArrow)
            {
                ChangeDate(false);
                ShowMenu();
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                ChangeDate(true);
                ShowMenu();
            }

        } while (key.Key != ConsoleKey.Escape);
    }

    static void ShowMenu()
    {
        Console.Clear();

        // Выводим текущую дату 
        Console.WriteLine("Дата: " + notes[currentNoteIndex].Date.ToShortDateString());

        // Выводим названия заметок для текущей даты 
        for (int i = 0; i < notes.Count; i++)
        {
            if (notes[i].Date == notes[currentNoteIndex].Date)
            {
                Console.WriteLine(i + 1 + ". " + notes[i].Name);
            }
        }

        Console.WriteLine("\nИспользуйте стрелки вправо-влево для переключения даты");
        Console.WriteLine("Нажмите Enter для просмотра информации о заметке");
        Console.WriteLine("Нажмите Escape для выхода");
    }

    static void ShowNoteDetails(int index)
    {
        Console.Clear();
        Note note = notes[index];

        Console.WriteLine("Название: " + note.Name);
        Console.WriteLine("Описание: " + note.Description);
        Console.WriteLine("Дата: " + note.Date.ToShortDateString());
        Console.WriteLine("Дедлайн: " + note.Deadline.ToShortDateString());

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню");
        Console.ReadKey();
    }

    static void ChangeDate(bool forward)
    {
        if (forward)
        {
            do
            {
                currentNoteIndex = (currentNoteIndex + 1) % notes.Count;
            } while (notes[currentNoteIndex].Date < notes[currentNoteIndex - 1].Date);
        }
        else
        {
            do
            {
                currentNoteIndex = (currentNoteIndex - 1 + notes.Count) % notes.Count;
            } while (notes[currentNoteIndex].Date > notes[currentNoteIndex + 1].Date);
        }
    }
}

class Note
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime Deadline { get; set; }
}

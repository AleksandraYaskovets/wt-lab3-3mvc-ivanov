using wt_lab3_3mvc_ivanov.Models;
using wt_lab3_3mvc_ivanov.Views;

namespace wt_lab3_3mvc_ivanov.Controllers;

public class TrackController
{
    private readonly List<Track> _tracks;
    private readonly TrackView _view;
    private int _nextId = 4;

    public TrackController()
    {
        // Тестовая коллекция
        _tracks = new List<Track>
        {
            new Track { Id = 1, Title = "Bohemian Rhapsody", ArtistName = "Queen", DurationSeconds = 355 },
            new Track { Id = 2, Title = "Imagine", ArtistName = "John Lennon", DurationSeconds = 183 },
            new Track { Id = 3, Title = "Love of My Life", ArtistName = "Queen", DurationSeconds = 219 }
        };
        _view = new TrackView();
    }

    public void Index()
    {
        _view.ShowTracks(_tracks);
    }

    public void Show(int id)
    {
        var track = _tracks.FirstOrDefault(t => t.Id == id);
        if (track == null)
        {
            _view.ShowMessage("Трек не найден.");
            return;
        }
        _view.ShowTrack(track);
    }

    public void Add(Track track)
    {
        track.Id = _nextId++;
        _tracks.Add(track);
        _view.ShowMessage("Трек успешно добавлен.");
    }

    public void Delete(int id)
    {
        var track = _tracks.FirstOrDefault(t => t.Id == id);
        if (track == null)
        {
            _view.ShowMessage("Трек не найден.");
            return;
        }
        _tracks.Remove(track);
        _view.ShowMessage("Трек успешно удалён.");
    }

    // === Меню для работы с пользователем (Пункт 11) ===
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n___ МЕНЮ ___");
            Console.WriteLine("1. Показать все треки");
            Console.WriteLine("2. Найти трек по ID");
            Console.WriteLine("3. Добавить трек");
            Console.WriteLine("4. Удалить трек");
            Console.WriteLine("5. Поиск по названию (Доп. задание)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Index();
                    break;
                case "2":
                    ShowTrackByUserInput();
                    break;
                case "3":
                    AddTrackByUserInput();
                    break;
                case "4":
                    DeleteTrackByUserInput();
                    break;
                case "5":
                    SearchByTitle();
                    break;
                case "0":
                    return;
                default:
                    _view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    // === Обработка пользовательского ввода ===
    private void ShowTrackByUserInput()
    {
        Console.Write("Введите ID трека: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            _view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void AddTrackByUserInput()
    {
        Console.Write("Введите название трека: ");
        var title = Console.ReadLine() ?? "";
        
        Console.Write("Введите исполнителя: ");
        var artist = Console.ReadLine() ?? "";
        
        Console.Write("Введите длительность в секундах: ");
        if (!int.TryParse(Console.ReadLine(), out int duration))
        {
            _view.ShowMessage("Некорректная длительность.");
            return;
        }

        Add(new Track { Title = title, ArtistName = artist, DurationSeconds = duration });
    }

    private void DeleteTrackByUserInput()
    {
        Console.Write("Введите ID трека для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            _view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }

    // === Дополнительное задание (Пункт 14) ===
    private void SearchByTitle()
    {
        Console.Write("Введите часть названия для поиска: ");
        var text = Console.ReadLine() ?? "";
        
        var result = _tracks
            .Where(t => t.Title.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0)
            _view.ShowMessage("Ничего не найдено.");
        else
            _view.ShowTracks(result);
    }
}
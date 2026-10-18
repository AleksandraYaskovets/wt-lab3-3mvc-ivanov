using wt_lab3_3mvc_ivanov.Models;

namespace wt_lab3_3mvc_ivanov.Views;

public class TrackView
{
    public void ShowTracks(List<Track> tracks)
    {
        Console.WriteLine("___ СПИСОК ТРЕКОВ ___");
        foreach (var track in tracks)
        {
            Console.WriteLine(
                $"{track.Id}. " +
                $"{track.Title} | " +
                $"{track.ArtistName} | " +
                $"{track.DurationSeconds / 60}:{track.DurationSeconds % 60:D2}"
            );
        }
    }

    public void ShowTrack(Track track)
    {
        Console.WriteLine("___ ТРЕК ___");
        Console.WriteLine($"ID: {track.Id}");
        Console.WriteLine($"Название: {track.Title}");
        Console.WriteLine($"Исполнитель: {track.ArtistName}");
        Console.WriteLine($"Длительность: {track.DurationSeconds} сек.");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine($"[Сообщение]: {message}");
    }
}
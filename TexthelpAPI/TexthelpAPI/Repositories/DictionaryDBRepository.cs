using Microsoft.Data.Sqlite;

namespace TexthelpAPI.Repositories;

public class DictionaryDBRepository
{
    private readonly SqliteConnection _sqliteConnection;

    public DictionaryDBRepository()
    {
        var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        var dbFolder = Path.Combine(projectFolder, "TexthelpAPI", "Repositories", "DB");
        var dbPath = Path.Combine(dbFolder, "Dictionary.db");

        _sqliteConnection = new SqliteConnection($"Data Source={dbPath};Mode=ReadOnly");

        try
        {
            _sqliteConnection.Open();
        }
        catch (Exception)
        {
            throw;
        }
    }

    internal List<string> GetMatchingWords(string text)
    {
        var result = new List<string>();
        var word = text.Split(' ').Last();
        if (string.IsNullOrEmpty(word))
        {
            return result;
        }

        SqliteDataReader sqlite_datareader;
        SqliteCommand sqlite_cmd;
        sqlite_cmd = _sqliteConnection.CreateCommand();
        sqlite_cmd.CommandText = $"SELECT Value FROM Words WHERE Value LIKE '{word}%'";

        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while (sqlite_datareader.Read())
        {
            string foundWord = sqlite_datareader.GetString(0);
            result.Add(foundWord);
        }

        _sqliteConnection.Close();
        return result;
    }
}

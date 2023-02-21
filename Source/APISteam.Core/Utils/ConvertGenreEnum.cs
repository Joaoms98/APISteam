namespace APISteam.Core.Utils;

public static class ConvertGenreEnum
{
    static private IDictionary<string, int> Genres = new Dictionary<string, int>()
    {
        ["action"] = 0,
        ["rpg"] = 1,
        ["adult"] = 2,
        ["fps"] = 3,
        ["sandbox"] = 4,
        ["simulator"] = 5,
        ["indie"] = 6,
        ["adventure"] = 7,
        ["horror"] = 8,
    };
    
    public static int EncodeToIntGenreEnum(this string key)
    {
        // if(!Genres.ContainsKey(key))
        // {
        //     throw new KeyNotFoundException("Gênero não encontrado");
        // }

        return Genres.Where(g => g.Key.Contains(key)).FirstOrDefault().Value;
    }

    public static string DecodeToStringGenreEnum(this int value)
    {
        return Genres.FirstOrDefault(g => g.Value == value).Key;
    }
}

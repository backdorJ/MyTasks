using Notes.Enum;

namespace Notes.DictionaryColors;

public static class TakeColor
{
    public static Dictionary<int, string> GetColor = new Dictionary<int, string>()
    {
        [2] = "border-dark",
        [1] = "border-success",
        [0] = "border-danger",
        [3] = "border-warning"
    };
}
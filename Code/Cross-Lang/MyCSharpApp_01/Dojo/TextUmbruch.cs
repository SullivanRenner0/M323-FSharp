using System;
using System.Linq;

namespace MyCSharpApp_01.Dojo;
internal class TextUmbruch
{
    public static string Umbrechen(string text, int maxZeilenLaenge)
    {
        text = text.Replace("\r\n", "\n");
        var words = text.Split([' ', '\n'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        List<string> zeilen = [""];
        for (var i = 0; i < words.Length; i++)
        {
            var last = zeilen[^1];
            var word = words[i];
            if (last != "" && last.Length + word.Length + 1 <= maxZeilenLaenge)
                zeilen[^1] = last + " " + word;
            else
            {
                var chunks = word.Chunk(maxZeilenLaenge)
                    .Select(c => new string(c));

                zeilen.AddRange(chunks);
            }
        }
        return string.Join(Environment.NewLine, zeilen);
    }
}

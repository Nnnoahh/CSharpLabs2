class Program
{
    static void Main(string[] args)
    {
        // Путь к текстовому файлу
        string filePath = "путь_к_файлу.txt";

        // Читаем все строки из файла
        string[] lines = File.ReadAllLines(filePath);

        // Если в файле меньше 3-х строк, выводим ошибку
        if (lines.Length < 3)
        {
            Console.WriteLine("Файл должен содержать минимум 3 строки!");
            return;
        }

        // Создаем список для хранения предложений
        List<string> sentences = new List<string>();

        // Добавляем первые три строки файла в список
        sentences.Add(lines[0]);
        sentences.Add(lines[1]);
        sentences.Add(lines[2]);

        // Выводим предложения в обратном порядке
        for (int i = sentences.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(sentences[i]);
        }
    }
}
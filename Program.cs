class Program
{
    static void Main(string[] args)
    {
        // ���� � ���������� �����
        string filePath = "����_�_�����.txt";

        // ������ ��� ������ �� �����
        string[] lines = File.ReadAllLines(filePath);

        // ���� � ����� ������ 3-� �����, ������� ������
        if (lines.Length < 3)
        {
            Console.WriteLine("���� ������ ��������� ������� 3 ������!");
            return;
        }

        // ������� ������ ��� �������� �����������
        List<string> sentences = new List<string>();

        // ��������� ������ ��� ������ ����� � ������
        sentences.Add(lines[0]);
        sentences.Add(lines[1]);
        sentences.Add(lines[2]);

        // ������� ����������� � �������� �������
        for (int i = sentences.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(sentences[i]);
        }
    }
}
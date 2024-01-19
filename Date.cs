class Date
{
    private int day;
    private int month;
    private int year;

    public Date(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    public static Date operator +(Date date, int days)
    {
        return new Date(date.day + days, date.month, date.year);
    }

    public static Date operator -(Date date, int days)
    {
        return new Date(date.day - days, date.month, date.year);
    }

    public static bool operator ==(Date date1, Date date2)
    {
        return date1.day == date2.day && date1.month == date2.month && date1.year == date2.year;
    }

    public static bool operator !=(Date date1, Date date2)
    {
        return !(date1 == date2);
    }

    public void PrintDate(string format)
    {
        switch (format)
        {
            case "dd-mm-yyyy":
                Console.WriteLine($"{day:D2}-{month:D2}-{year:D4}");
                break;
            case "mm-dd-yyyy":
                Console.WriteLine($"{month:D2}-{day:D2}-{year:D4}");
                break;
            case "yyyy-mm-dd":
                Console.WriteLine($"{year:D4}-{month:D2}-{day:D2}");
                break;
            default:
                Console.WriteLine("Invalid format");
                break;
        }
    }
}

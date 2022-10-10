using System;
using System.Globalization;
using Microsoft.Extensions.Logging;
using StringInterpolationTemplate.Utils;

namespace StringInterpolationTemplate.Services;

public class StringInterpolationService : IStringInterpolationService
{
    private readonly ISystemDate _date;
    private readonly ILogger<IStringInterpolationService> _logger;

    public StringInterpolationService(ISystemDate date, ILogger<IStringInterpolationService> logger)
    {
        _date = date;
        _logger = logger;
        _logger.Log(LogLevel.Information, "Executing the StringInterpolationService");
    }

    //1. January 22, 2019 (right aligned in a 40 character field)
    public string Number01()
    {
        var date = _date.Now.ToString("MMMM dd, yyyy");
        var answer = $"{date,40}";
        Console.WriteLine(answer);

        return answer;
    }

    public string Number02()
    {
        //Console.WriteLine($"{DateTime.Now:yyyy.dd.MM}");

        var date = _date.Now.ToString("yyyy.mm.dd");

        var answer = $"{date}";

        
        Console.WriteLine(answer);
        
        return answer;


    }

    public string Number03()
    {
        //3.Day 22 of January, 2019
        int day = _date.Now.Day;
        var month = _date.Now.ToString("MMMM");
        int year = _date.Now.Year;
        var answer = $"Day {day} of {month}, {year}";
        Console.WriteLine(answer);
        return answer;
    }


    public string Number04()
    {
        int day = _date.Now.Day;
        var month = _date.Now.ToString("MM");
        int year = _date.Now.Year;

        //4.Year: 2019, Month: 01, Day: 22
        return $"Year: {year}, Month: {month}, Day: {day}";
    }

    public string Number05()
    {
        //5.Tuesday(10 spaces total, right aligned)
        string weekDay = _date.Now.DayOfWeek.ToString();
        return String.Format("{0}", weekDay.PadLeft(10));

        }
    public string Number06()
    {
        //6. 11:01 PM Tuesday(10 spaces total for each including the day - of - week, both right - aligned)
        string time = _date.Now.ToShortTimeString();
        string weekDay = _date.Now.DayOfWeek.ToString();
        return String.Format("{0}{1}", time.PadLeft(10), weekDay.PadLeft(10));
    }
    public string Number07()
    {

        //7. h:11, m: 01, s: 27
        var hour = _date.Now.ToString("hh");
        var minute = _date.Now.ToString("mm");
        int second = _date.Now.Second;
        return $"h:{hour}, m:{minute}, s:{second}";
    }


    public string Number08()
    {
        //8. 2019.01.22.11.01.27
        var year = _date.Now.Year;
        var month = _date.Now.ToString("MM");
        var day = _date.Now.ToString("dd");
        var hour = _date.Now.ToString("hh");
        var minute = _date.Now.ToString("mm");
        var second = _date.Now.ToString("ss");

        return $"{year}.{month}.{day}.{hour}.{minute}.{second}";
    }
    public string Number09()
    {
        var pi = Math.PI;
        return $"{pi.ToString("C",new CultureInfo("en-US"))}";
    }

    public string Number10()
    {
        var pi = Math.PI;
        return $"{Math.Round(pi, 3),10}";
    }

    public string Number11()
    {
        return _date.Now.Year.ToString("X");
    }

    //2.2019.01.22
}

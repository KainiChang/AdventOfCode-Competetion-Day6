using System.Text.RegularExpressions;

namespace code;
public class Processor1
{
    public static long Process(string input)
    {
        List<long> counts= new List<long>();
        var timeArray = ReadInput(input);
        var distanceArray = ReadInput2(input);
        for (long index = 0; index < timeArray.Length; index++)
        {
            counts.Add(SingleRaceProcess(timeArray[index], distanceArray[index]));
        }
        // get the product of all counts
        long count = 0;
        foreach (var item in counts)
        {
            count =+ item;
        }
        return count;
    }

    public static long SingleRaceProcess(long time, long hisDistance){
        long count = 0;
        for (int timeBeingHold = 1; timeBeingHold < time; timeBeingHold++)
        {
            long speed =timeBeingHold;
            long restOfRaceTime = time - timeBeingHold;
           long distance = speed * restOfRaceTime;
           if (distance > hisDistance)
           {
               count++;
           }
        }
        return count;
    }
    public static long[] ReadInput(string input)
    {//split input into sections by new line
        var sections = input.Split(new string[] { "\n\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine(sections[0]);

        var timeArray =sections[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(x => long.Parse(x)).ToArray();
        
        foreach (var item in timeArray)
        {
            Console.WriteLine(item);
        }

        return timeArray;
    }
    public static long[] ReadInput2(string input)
    {//split input into sections by new line
        var sections = input.Split(new string[] { "\n\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        //first line
        var distanceString = sections[1].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
        // parse words in the timeString to long array
        var distanceArray = Regex.Split(distanceString, @"\s+").Select(x => long.Parse(x)).ToArray();
        return distanceArray;
    }
}
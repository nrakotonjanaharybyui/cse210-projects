using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Nasa";
        job1._jobTitle = "Astronaut";
        job1._startYear = 2020;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2021;
        job2._endYear = 2024;

        Resune myResume = new Resune();
        myResume._name = "John Doe";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.DisplayResume();
    }
}
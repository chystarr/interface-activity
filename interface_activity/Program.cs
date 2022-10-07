// Intro to APIs Activity 4

using System;

namespace MyNamespace
{
    interface Student
    {
        string Name { get; set; }
        int Id { get; set; }
        float Gpa { get; set; }
    }

    public class CSMajor : Student
    {
        public static string name;
        public static int id;
        public static float gpa;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public float Gpa
        {
            get
            {
                return gpa;
            }
            set
            {
                gpa = value;
            }
        }
    }

    public class CSRegistration
    {
        // declare a delegate
        public delegate void StudentRegisteredEventHandler(object source, EventArgs args);

        // declare the event
        public event StudentRegisteredEventHandler StudentRegistered;

        public void RegisterStudent(CSMajor csMajor)
        {
            Console.WriteLine($"Registering student with ID number {csMajor.Id}...");
            Thread.Sleep(2000);

            OnStudentRegistered();
        }

        // event handler
        protected virtual void OnStudentRegistered()
        {
            if (StudentRegistered != null)
            {
                StudentRegistered(this, null);
            }
        }
    }

    class SampleCollection<T>
    {
        private T[] arr = new T[100];

        public T this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }

    public class AppService
    {
        public void OnStudentRegistered(object source, EventArgs eventArgs)
        {
            Console.WriteLine("AppService: the student was registered.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var student = new CSMajor { Name = "Jane", Id = 1, Gpa = 3.6F };

            var registrationService = new CSRegistration();
            var appService = new AppService();
            // subscribe to the event
            registrationService.StudentRegistered += appService.OnStudentRegistered;
            registrationService.RegisterStudent(student);

            var classRoster = new SampleCollection<Student>();
            classRoster[0] = student;
            Console.WriteLine($"The new student's name is {classRoster[0].Name}.");
            Console.ReadKey();
        }
    }
}

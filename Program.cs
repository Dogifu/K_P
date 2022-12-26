using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

public class Student
{
    public string FIO { get; set; }

    public int Number { get; set; }

    public double SRED { get; set; }

    public List<string> Dis { get; set; }

    public List<int> Oc { get; set; }

    public Student(string FIO, int Number, List<string> Dis, List<int> Oc)
    {
        this.FIO = FIO;

        this.Number = Number;

        this.Dis = Dis;

        this.Oc = Oc;

    }

    public Student()
    {
        
    }
}

class MainClass
{


    public static Task Main()
    {



        static string getString(string ob, string key) // функция, принимающая строку и ключ, котроая возвращает подстроку
        {
            int Num = ob.IndexOf(key);
            if (Num == -1) return "";
            int Num2 = Num + key.Length + 1;
            int Num3 = ob.IndexOf(",", Num2);
            return ob.Substring(Num2, Num3 - Num2);
        }
        static int getInt(string ob, string key) // функция, принимающая строку и ключ, которая возвращает число
        {
            int Num = ob.IndexOf(key);
            if (Num == -1) return 0;
            int Num2 = Num + key.Length + 1;
            int Num3 = ob.IndexOf(",", Num2);
            int rez;
            int.TryParse(ob.Substring(Num2, Num3 - Num2), NumberStyles.Any, CultureInfo.InvariantCulture, out rez);
            return rez;
        }

        var Col = new List<Student>(); // список студентов

        int n = 0, ch = 0, Ind, B, D;

        string str, S, S_I, A, C, str1;

        int c = Col.Count(); // функция подсчета количества студентов

        int Convertation() // функция для конвертации строки в число 
        {

            int a;

            string str;

            str = Console.ReadLine();

            a = Convert.ToInt32(str);

            return a;

        }

        void Console_()
        {
            Console.WriteLine("-------------------------------------------");
        }
        void printy()
        {

            StreamWriter sw = new StreamWriter("/Users/user/Projects/K_P/K_P/Test.txt ");
            foreach (Student student in Col)
            {

               
                sw.Write("FIO:" + student.FIO + ","
               + "Group number:" + student.Number + ",");

                for (int i = 0; i < student.Dis.Count; i++)
                {

                    
                    sw.Write("Discipline №" + (i + 1) + ":" +
                       student.Dis[i] + "," + "Mark №" + (i + 1) + ":" + student.Oc[i] + ",");


                }
                sw.WriteLine();

            }
            sw.Close();

        }
        void print() 
        {
        
            foreach (Student student in Col)
            {

                Console.WriteLine("FIO:  " + student.FIO + " | "
                 + " Group number:  " + student.Number);
              

                for (int i = 0; i < student.Dis.Count; i++)
                {

                    Console.WriteLine("Discipline № " + (i + 1) + " " +
                        student.Dis[i] + " | " + " Mark: " + student.Oc[i]);

                }

            }
        }


        void Sort_By_FIO()
        {

            Col.Sort(delegate (Student x, Student y) { return x.FIO.CompareTo(y.FIO); });
            print();
        }

        void Sort_By_Medium_Mark()
        {
            double k = 0;

            double Count_ = 0;

            double Sred = 0;



            foreach (Student student in Col)
            {
                for (int i = 0; i < student.Oc.Count; i++)
                {

                    Count_ = student.Oc.Count;

                    k += student.Oc[i];

                }

                Sred = k / Count_;

                student.SRED = Sred;

                Sred = 0;

                k = 0;

            }

            Col.Sort(delegate (Student x, Student y) { return x.SRED.CompareTo(y.SRED); });

            foreach (Student student in Col)
            {

                Console.WriteLine("FIO:  " + student.FIO + " | "
                 + " Group number:  " + student.Number + " | " +
                 " Sorted medium mark " + student.SRED);
            }
        }
        
        void Print_Console() // функция вывода из файла на консоль 
        {

            string str = "/Users/user/Projects/K_P/K_P/Test.txt ";

            using (StreamReader s = new StreamReader(str, Encoding.Default))
            {
                string line;
                while ((line = s.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

        }

        void Add_Student() // функция добавления студента 
        {
            for (int i = 0; i < n; i++)

            {
                Console.WriteLine("Student № " + (i + 1));

                Console.Write("FIO: ");

                string I = Console.ReadLine();

                Console.Write("Group number: ");

                int Number = Convertation();

                Console.Write("Number of disciplines:");

                int Kol = Convertation(); // кол - во дисциплин

                var Dis = new List<string>();

                var Oce = new List<int>();

                for (int j = 0; j < Kol; j++)
                {
                    Console.WriteLine("Discipline № " + (j + 1));

                    Dis.Add(Console.ReadLine());

                    Console.Write("Mark:");

                    Oce.Add(Convertation());
                }

                Col.Add(new Student(I, Number, Dis, Oce));
            }
        }

        void Add_New_Student() // функция добавления нового студента в список 
        {
            for (int i = 0; i < ch; i++)
            {
                c++;

                Console.WriteLine("Student № " + (c + 1));

                Console.Write("FIO: ");

                string I = Console.ReadLine();

                Console.Write("Group number :");

                int Number = Convertation();

                Console.Write("Number of disciplines :");

                int Kol = Convertation(); // кол - во дисциплин

                var Dis = new List<string>();

                var Oce = new List<int>();

                for (int j = 0; j < Kol; j++)
                {
                    Console.WriteLine("Discipline № " + (j + 1));

                    Dis.Add(Console.ReadLine());

                    Console.Write("Mark:");

                    Oce.Add(Convertation());
                }

                Col.Add(new Student(I, Number, Dis, Oce));
            }
        }

        str1 = "/Users/user/Projects/K_P/K_P/Test.txt ";

        using (StreamReader s = new StreamReader(str1, Encoding.Default))
        {
            string line;
            if ((line = s.ReadLine()) == null)
            {
                Console.WriteLine("File is empty");
                Console.WriteLine("Program: Student progress report ");

                Console.WriteLine("Add student ");

                Console.WriteLine("Number of students: ");

                try
                {

                    str = Console.ReadLine();

                    n = Convert.ToInt32(str);
                }

                catch

                {

                    Console.WriteLine("Wrong Input put int  ");

                    Console.WriteLine("Number of students: ");

                    str = Console.ReadLine();

                    n = Convert.ToInt32(str);

                }

                Add_Student();

                Console_();

            }
            else
            {
                
                using (StreamReader st = new StreamReader(str1, Encoding.Default))
                {
                    string line1;
                    while ((line1 = st.ReadLine()) != null)
                    {
                        string FIO = getString(line1, "FIO");
                        
                        int Number = getInt(line1, "Group number");
                        
                        int i = 1;
                        var Dis = new List<string>();
                        var Oc = new List<int>();
                        while ((getString(line1, ("Mark №" + i)) != ""))
                        {
                            string ds = getString(line1, ("Discipline №" + i ));


                            
                            Dis.Add(ds);

                            int mark = getInt(line1, ("Mark №" + i ));
                            
                            Oc.Add(mark);
                            ++i;

                           
                           

                        }
                        Col.Add(new Student(FIO, Number, Dis, Oc));
                        
                    }

                    Console.WriteLine("Your list:");
                    Console_();

                     foreach (Student student in Col)
                     {

                         Console.WriteLine("FIO:  " + student.FIO + " | "
                          + " Group number:  " + student.Number);


                         for (int i = 0; i < student.Dis.Count; i++)
                         {

                             Console.WriteLine("Discipline № " + (i + 1) + " " +
                                 student.Dis[i] + " | " + " Mark: " + student.Oc[i]);

                         }

                     } 

                    

                }

              
            }

            while (ch != 12)
            {

                Console_();

                Console.WriteLine("You have many functions: ");

                Console.WriteLine("1. Print list of students to console ");

                Console.WriteLine("2. Add new student ");

                Console.WriteLine("3. Delete student ");

                Console.WriteLine("4. Edit mark ");

                Console.WriteLine("5. Get a list of students from file ");

                Console.WriteLine("6. Sort the list of students by medium mark ");

                Console.WriteLine("7. Sort the list of students by FIO");

                Console.WriteLine("8. Edit group number");

                Console.WriteLine("9. Search the student");

                Console.WriteLine("10. Clear the list");

                Console.WriteLine("11. Print to file");

                Console.WriteLine("12. Exit ");

                try
                {
                    S = Console.ReadLine();

                    ch = Convert.ToInt32(S);
                }

                catch
                {
                    Console.WriteLine("Wrong Input choose function");

                    Console.WriteLine("You have many functions: ");

                    Console.WriteLine("1. Print list of students to console ");

                    Console.WriteLine("2. Add new student ");

                    Console.WriteLine("3. Delete student ");

                    Console.WriteLine("4. Edit mark ");

                    Console.WriteLine("5. Get a list of students from file ");

                    Console.WriteLine("6. Sort the list of students by medium mark ");

                    Console.WriteLine("7. Sort the list of students by FIO");

                    Console.WriteLine("8. Edit group number");

                    Console.WriteLine("9. Search the student");

                    Console.WriteLine("10. Clear the list");

                    Console.WriteLine("11. Print to file");

                    Console.WriteLine("12. Exit ");

                    S = Console.ReadLine();

                    ch = Convert.ToInt32(S);

                }


                if (ch == 2)
                {
                    Console.WriteLine("How much students do you want to add? ");

                    try
                    {
                        S = Console.ReadLine();

                        ch = Convert.ToInt32(S);

                        Add_New_Student();

                        Console_();

                        Console.WriteLine("It is your new list ");

                        print();
                    }

                    catch
                    {
                        Console.WriteLine("Wrong Input put int ");

                        S = Console.ReadLine();

                        ch = Convert.ToInt32(S);

                        Add_New_Student();

                        Console_();

                        Console.WriteLine("It is your new list ");

                        print();
                    }

                }

                else if (ch == 3)
                {
                    try
                    {
                        Console.WriteLine("Which student do you want to remove");

                        S_I = Console.ReadLine();

                        Ind = Convert.ToInt32(S_I);

                        Col.RemoveAt(Ind - 1);

                        Console_();

                        Console.WriteLine("Your new list");

                        print();
                    }

                    catch
                    {
                        Console.WriteLine("Wront Input put int");

                        Console.WriteLine("Which student do you want to remove");

                        S_I = Console.ReadLine();

                        Ind = Convert.ToInt32(S_I);

                        Col.RemoveAt(Ind - 1);

                        Console_();

                        Console.WriteLine("Your new list");

                        print();

                    }
                }

                else if (ch == 1)
                {
                    Console.WriteLine("It is your list ");

                    Console_();

                    print();

                }

                else if (ch == 11)
                {
                    Console.WriteLine("You wrote your list to file");
                    printy();
                }

                else if (ch == 5)
                {
                    Console.WriteLine("You got list from file ");

                    Console_();

                    Print_Console();
                }

                else if (ch == 4)
                {

                    try
                    {

                        Console.WriteLine("Which student do you want to change mark? ");

                        A = Console.ReadLine();

                        B = Convert.ToInt32(A);

                        Student student = Col[(B - 1)];

                        Console.WriteLine("Choose the number of discipline ");

                        C = Console.ReadLine();

                        D = Convert.ToInt32(C);

                        Console.WriteLine("Enter the mark ");

                        student.Oc[(D - 1)] = Convertation();
                    }

                    catch
                    {
                        Console.WriteLine("Wrong Input put Int");

                        Console.WriteLine("Which student do you want to change mark? ");

                        A = Console.ReadLine();

                        B = Convert.ToInt32(A);

                        Student student = Col[(B - 1)];

                        Console.WriteLine("Choose the number of discipline ");

                        C = Console.ReadLine();

                        D = Convert.ToInt32(C);

                        Console.WriteLine("Enter the mark ");

                        student.Oc[(D - 1)] = Convertation();

                    }
                }

                else if (ch == 6)
                {
                    Sort_By_Medium_Mark();
                }

                else if (ch == 7)
                {

                    Sort_By_FIO();

                }

                else if (ch == 8)
                {
                    try
                    {
                        Console.WriteLine("What student do you want to change group");

                        A = Console.ReadLine();

                        B = Convert.ToInt32(A);

                        Student student = Col[B - 1];

                        Console.WriteLine("Edit group ");

                        student.Number = Convertation();


                    }

                    catch
                    {
                        Console.WriteLine("Wrong Input put int");

                        Console.WriteLine("What student do you want to change group");

                        A = Console.ReadLine();

                        B = Convert.ToInt32(A);

                        Student student = Col[B - 1];

                        Console.WriteLine("Edit group ");

                        student.Number = Convertation();

                    }

                }

                else if (ch == 9)
                {

                    Console.WriteLine("What student do you want to find");

                    string NAME;

                    NAME = Console.ReadLine();

                    foreach (Student student in Col)
                    {
                        if (NAME == student.FIO)
                        {
                            Console.WriteLine("You have this student in the list");

                            Console.WriteLine("FIO: " + student.FIO + " Number: " + student.Number);

                            for (int i = 0; i < student.Dis.Count; i++)
                            {

                                Console.WriteLine("Discipline № " + (i + 1) + " " +
                                    student.Dis[i] + " | " + " Mark: " + student.Oc[i]);


                            }

                        }

                    }

                }

                else if (ch == 10)
                {
                    Col.Clear();
                    File.WriteAllText(str1, String.Empty);
                    
                }
            }

            return Task.CompletedTask;

        }
    }
}




                       
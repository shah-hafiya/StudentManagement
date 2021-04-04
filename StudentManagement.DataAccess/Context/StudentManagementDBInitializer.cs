using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using StudentManagement.Api.Entities;

namespace StudentManagement.DataAccess.Context
{
    public class StudentManagementDBInitializer : DropCreateDatabaseAlways<StudentManagementDbContext>
    {
        protected override void Seed(StudentManagementDbContext context)
        {
            var numberOfStudentToGenerate = 100;
            var names = NameGenerator.GetRandomNames(numberOfStudentToGenerate).ToArray();
            var randomGenerator = new Random();

            if (!context.Students.Any())
            {
                DateTime yearDateTime = DateTime.Now;
                for (int i = 0; i < numberOfStudentToGenerate; i++)
                {
                    yearDateTime = DateTime.Now.AddYears(-(randomGenerator.Next(7, 30)));
                    context.Students.Add(new Student
                    {
                        FirstName = names[i]?.First,
                        SurName = names[i]?.Last,
                        Gender = names[i]?.Gender,
                        DOB = new DateTime(yearDateTime.Year, randomGenerator.Next(1, 12), randomGenerator.Next(1, 28)),
                        Password = $"{names[i]?.First}{names[i]?.Last}",
                        Address = new AddressDetails
                        {
                            Line1 = "1428 Elm Street",
                            Line2 = "1428 Elm Street",
                            Line3 = "1428 Elm Street",
                        }
                    });
                }
            }

            if (!context.Courses.Any())
            {
                string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                for (var i = 0; i < 50; i++)
                {
                    var courseStartDay = randomGenerator.Next(2, 31);
                    var courseEndDay = courseStartDay + randomGenerator.Next(7, 31);
                    var randomTeacherName = names[randomGenerator.Next(1, 100)];

                    context.Courses.Add(new Course
                    {
                        CourseCode = Convert.ToString(Guid.NewGuid()).Substring(0, 4),
                        CourseName = $"Course {alphabets[randomGenerator.Next(0, 26)]}",
                        TeacherName = $"{randomTeacherName?.First} {randomTeacherName?.Last}",
                        Space = randomGenerator.Next(1, 100),
                        StartDate = DateTime.Now.AddDays(courseStartDay),
                        EndDate = DateTime.Now.AddDays(courseEndDay),
                    });
                }
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }

    public class Name
    {
        public Name()
        {
            Gender = "M";
        }

        public string First { get; set; }
        public string Last { get; set; }
        public string Gender { get; set; }
    }

    public class NameGenerator
    {
        public static IEnumerable<Name> GetRandomNames(int count)
        {
            var enumerator = RandomNameEnumerator();
            while (count-- > 0)
            {
                enumerator.MoveNext();
                yield return enumerator.Current;
            }
        }

        public static IEnumerator<Name> RandomNameEnumerator()
        {
            var firstNameEnumerator = RandomFirstNameEnumerator();
            var lastNameEnumerator = RandomLastNameEnumerator();
            var genderToggle = true;

            while (true)
            {
                firstNameEnumerator.MoveNext();
                lastNameEnumerator.MoveNext();
                genderToggle = !genderToggle;

                yield return new Name
                {
                    First = firstNameEnumerator.Current,
                    Last = lastNameEnumerator.Current,
                    Gender = genderToggle ? "M" : "F",
                };
            }

        }

        public static IEnumerable<string> GetRandomFirstNames(int count)
        {
            var enumerator = RandomFirstNameEnumerator();

            while (count-- > 0)
            {
                enumerator.MoveNext();
                yield return enumerator.Current;
            }
        }

        public static IEnumerator<string> RandomFirstNameEnumerator()
        {
            int maleMax = MaleFirstNames.Length, femaleMax = FemaleFirstNames.Length;
            var random = new Random();

            while (true)
            {
                yield return FemaleFirstNames[random.Next(0, femaleMax)];
                yield return MaleFirstNames[random.Next(0, maleMax)];
            }
        }

        public static IEnumerable<string> GetRandomLastNames(int count)
        {
            var enumerator = RandomLastNameEnumerator();
            while (count-- > 0)
            {
                enumerator.MoveNext();
                yield return enumerator.Current;
            }
        }

        public static IEnumerator<string> RandomLastNameEnumerator()
        {
            var max = Surnames.Length;
            var rand = new System.Random();

            while (true)
            {
                yield return Surnames[rand.Next(0, max)];
            }
        }

        public static string[] FemaleFirstNames = new[]
        {
            "Isabella",
            "Sophia",
            "Emma",
            "Olivia",
            "Colleen",
            "Emily",
            "Abigail",
            "Madison",
            "Chloe",
            "Mia",
            "Addison",
            "Elizabeth",
            "Ella",
            "Natalie",
            "Samantha",
            "Alexis",
            "Lily",
            "Grace",
            "Hailey",
            "Alyssa",
            "Lillian",
            "Hannah",
            "Avery",
            "Leah",
            "Nevaeh",
            "Sofia",
            "Ashley",
            "Anna",
            "Brianna",
            "Sarah",
            "Zoe",
            "Victoria",
            "Gabriella",
            "Brooklyn",
            "Kaylee",
            "Taylor",
            "Layla",
            "Allison",
            "Evelyn",
            "Riley",
            "Amelia",
            "Khloe",
            "Makayla",
            "Aubrey",
            "Charlotte",
            "Savannah",
            "Zoey",
            "Bella",
            "Kayla",
            "Alexa",
            "Peyton",
            "Audrey",
            "Claire",
            "Arianna",
            "Julia",
            "Haley",
            "Kylie",
            "Lauren",
            "Sophie",
            "Sydney",
            "Camila",
            "Jasmine",
            "Morgan",
            "Alexandra",
            "Jocelyn",
            "Gianna",
            "Maya",
            "Kimberly",
            "Mackenzie",
            "Katherine",
            "Destiny",
            "Brooke",
            "Trinity",
            "Faith",
            "Lucy",
            "Madelyn",
            "Madeline",
            "Bailey",
            "Payton",
            "Andrea",
            "Autumn",
            "Melanie",
            "Ariana",
            "Serenity",
            "Stella",
            "Maria",
            "Molly",
            "Caroline",
            "Genesis",
            "Kaitlyn",
            "Eva",
            "Jessica",
            "Angelina",
            "Valeria",
            "Gabrielle",
            "Naomi",
            "Mariah",
            "Natalia",
            "Paige"
        };

        public static string[] MaleFirstNames = new[]
        {
            "Jacob",
            "Ethan",
            "Michael",
            "Jayden",
            "William",
            "Alexander",
            "Noah",
            "Daniel",
            "Aiden",
            "Anthony",
            "Joshua",
            "Mason",
            "Christopher",
            "Andrew",
            "David",
            "Matthew",
            "Logan",
            "Elijah",
            "James",
            "Joseph",
            "Gabriel",
            "Benjamin",
            "Ryan",
            "Samuel",
            "Jackson",
            "John",
            "Nathan",
            "Jonathan",
            "Christian",
            "Liam",
            "Dylan",
            "Landon",
            "Caleb",
            "Tyler",
            "Lucas",
            "Evan",
            "Gavin",
            "Nicholas",
            "Isaac",
            "Brayden",
            "Luke",
            "Angel",
            "Brandon",
            "Jack",
            "Isaiah",
            "Jordan",
            "Owen",
            "Carter",
            "Connor",
            "Justin",
            "Jose",
            "Jeremiah",
            "Julian",
            "Robert",
            "Aaron",
            "Adrian",
            "Wyatt",
            "Kevin",
            "Hunter",
            "Cameron",
            "Zachary",
            "Thomas",
            "Charles",
            "Austin",
            "Eli",
            "Chase",
            "Henry",
            "Sebastian",
            "Jason",
            "Levi",
            "Xavier",
            "Ian",
            "Colton",
            "Dominic",
            "Juan",
            "Cooper",
            "Josiah",
            "Luis",
            "Ayden",
            "Carson",
            "Adam",
            "Nathaniel",
            "Brody",
            "Tristan",
            "Diego",
            "Parker",
            "Blake",
            "Oliver",
            "Cole",
            "Carlos",
            "Jaden",
            "Jesus",
            "Alex",
            "Aidan",
            "Eric",
            "Hayden",
            "Bryan",
            "Max",
            "Jaxon",
            "Brian"
        };

        public static string[] Surnames = new[]
        {
            "Smith",
            "Johnson",
            "Williams",
            "Jones",
            "Brown",
            "Davis",
            "Miller",
            "Wilson",
            "Moore",
            "Taylor",
            "Anderson",
            "Thomas",
            "Jackson",
            "White",
            "Harris",
            "Martin",
            "Thompson",
            "Garcia",
            "Martinez",
            "Robinson",
            "Clark",
            "Rodriguez",
            "Lewis",
            "Lee",
            "Walker",
            "Hall",
            "Allen",
            "Young",
            "Hernandez",
            "King",
            "Wright",
            "Lopez",
            "Hill",
            "Scott",
            "Green",
            "Adams",
            "Baker",
            "Gonzalez",
            "Nelson",
            "Carter",
            "Mitchell",
            "Perez",
            "Roberts",
            "Turner",
            "Phillips",
            "Campbell",
            "Parker",
            "Evans",
            "Edwards",
            "Collins",
            "Stewart",
            "Sanchez",
            "Morris",
            "Rogers",
            "Reed",
            "Cook",
            "Morgan",
            "Bell",
            "Murphy",
            "Bailey",
            "Rivera",
            "Cooper",
            "Richardson",
            "Cox",
            "Howard",
            "Ward",
            "Torres",
            "Peterson",
            "Gray",
            "Ramirez",
            "James",
            "Watson",
            "Brooks",
            "Kelly",
            "Sanders",
            "Price",
            "Bennett",
            "Wood",
            "Barnes",
            "Ross",
            "Henderson",
            "Coleman",
            "Jenkins",
            "Perry",
            "Powell",
            "Long",
            "Patterson",
            "Hughes",
            "Flores",
            "Washington",
            "Butler",
            "Simmons",
            "Foster",
            "Gonzales",
            "Bryant",
            "Alexander",
            "Russell",
            "Griffin",
            "Diaz",
            "Hayes"
        };
    }
}

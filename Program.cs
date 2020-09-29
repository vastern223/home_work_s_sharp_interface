using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{

    class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Director(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public object Clone()
        {
            Director copy = (Director)this.MemberwiseClone();
            return copy;
        }

        public override string ToString()
        {
            return $"FirstName {FirstName} \n" +
                   $"LastName {LastName}";
        }
    }


    public enum Genre
    {
        Drama = 0, Comedy, Horrors, Genreless

    }

    class Movei : IComparable<Movei>, ICloneable
    {
        public Director director;

        public string Title { get; set; }

        public string Contry { get; set; }

        public int Year { get; set; }

        public Genre Genres { get; set; }

        public short Rating { get; set; }

        public int CompareTo(Movei other)
        {
            return this.Rating.CompareTo(other.Rating);
        }

        public override string ToString()
        {
            return $"Title: {Title} \n" +
                   $"Contry: {Contry}\n" +
                   $"Year: {Year} \n" +
                   $"genre: { Genres}\n" +
                   $"rating: {Rating }\n";
        }

        public object Clone()
        {
            Movei copy = (Movei)this.MemberwiseClone();
            copy.director = (Director)director.Clone();
            return copy;
        }
    }

    class Cinema : IEnumerable
    {
        public string Adreess { get; set; }
        public Movei[] movei;

        public Cinema()
        {
            Adreess = "adreess 223";
            movei = new Movei[]
        {
            new  Movei()
                {
                 Title ="John",
                 Contry ="ukrain",
                 Year = 2001,
                 Genres =(Genre)1,
                 Rating =10,
                 director = new Director("vov","kekovich")
                },
             new  Movei()
                {
                 Title ="dororo",
                 Contry ="usa",
                 Year = 2021,
                 Genres =(Genre)2,
                 Rating =18,
                 director = new Director("dno","properti")
                },
              new  Movei()
                {
                 Title ="klon",
                 Contry ="ukrain",
                 Year = 2008,
                 Genres =(Genre)0,
                 Rating =6,
                 director = new Director("dno","kech")
                },
               new  Movei()
                {
                 Title ="vrata",
                 Contry ="ukrain",
                 Year = 2003,
                 Genres =(Genre)2,
                 Rating =18,
                 director = new Director("most","lekh")
                },

            };
        }

        public IEnumerator GetEnumerator()
        {
            return movei.GetEnumerator();
        }

        public void Sort()
        {
            Array.Sort(movei);
        }

        public void Sort(IComparer<Movei> comparer)
        {
            Array.Sort(movei, comparer);
        }
    }


    class ComparaByRating : IComparer<Movei>
    {
        public int Compare(Movei x, Movei y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }

    class ComparaByYear : IComparer<Movei>
    {
        public int Compare(Movei x, Movei y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();

            foreach (var item in cinema)
            {
                Console.WriteLine( item.ToString());
            }

            cinema.Sort();

            Console.WriteLine("_-------------------_\n\n");

            foreach (var item in cinema)
            {
                Console.WriteLine(item.ToString());
            }

            cinema.Sort( new ComparaByYear());

            Console.WriteLine("_-------------------_\n\n");
            foreach (var item in cinema)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

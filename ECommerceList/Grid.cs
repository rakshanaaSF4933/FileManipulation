using System;
using System.Reflection;

namespace ECommerceList
{
    /// <summary>
    /// Class <see cref="Grid"/> used to show data in a grid
    /// </summary>
    /// <typeparam name="DataType">Type of list</typeparam>
    public class Grid<DataType>
    {
        //To show data in a table
        public void ShowTable(CustomList<DataType> list)
        {
            if (list != null && list.Count > 0)
            {
                PropertyInfo[] properties = typeof(DataType).GetProperties();
                Console.WriteLine(new string('-', properties.Length * 20));
                //property names
                Console.Write("|");
                foreach (var property in properties)
                {
                    Console.Write($"{property.Name,-19}|");
                }
                Console.WriteLine();
                Console.WriteLine(new string('-', properties.Length * 20));
                foreach (var data in list)
                {
                    Console.Write("|");
                    foreach (var property in properties)
                    {
                        if (property.CanRead)
                        {
                            if (property.PropertyType == typeof(DateTime))
                            {
                                var value = ((DateTime)property.GetValue(data)).ToString("dd/MM/yyyy");
                                Console.Write($"{value,-19}|");
                            }
                            else
                            {
                                var value = property.GetValue(data);
                                Console.Write($"{value,19}|");
                            }
                        }

                    }
                    Console.WriteLine();
                    Console.WriteLine(new string('-', properties.Length * 20));
                }

            }
        }
    }
}
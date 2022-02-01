using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FruitsAndVegetables
{
    class Program
    {
        static SqlConnection sqlConnection;

        static Program()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FruitsAndVegetables;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int choose = Menu();

                try
                {
                    switch (choose)
                    {
                        case 1:
                            Console.WriteLine();
                            Connect();
                            break;

                        case 2:
                            Console.WriteLine();
                            Disconnsect();
                            break;

                        case 3:
                            Console.WriteLine();
                            AddProduct();
                            break;

                        case 4:
                            Console.WriteLine();
                            ShowGoods();

                            Console.Write("\nName of product: ");
                            string name = Console.ReadLine();

                            DeleteGood(name.Trim().ToLower());
                            break;

                        case 5:
                            Console.WriteLine();
                            ShowGoods();

                            Console.WriteLine("\nPress ENTER");
                            Console.ReadLine();
                            break;

                        case 6:
                            Console.WriteLine();
                            ShowAllNames();
                            break;

                        case 7:
                            Console.WriteLine();
                            ShowAllColors();
                            break;

                        case 8:
                            Console.WriteLine();
                            ShowMaxCalories();
                            break;

                        case 9:
                            Console.WriteLine();
                            ShowMinCalories();
                            break;

                        case 10:
                            Console.WriteLine();
                            ShowAvgCalories();
                            break;

                        case 11:
                            Console.WriteLine();
                            ShowAmountOfFruits();
                            break;

                        case 12:
                            Console.WriteLine();
                            ShowAmountOfVegetables();
                            break;

                        case 13:
                            Console.Write("\n\nEnter a color: ");
                            string color = Console.ReadLine();

                            GetAmountProductsByColor(color);
                            break;

                        case 14:
                            Console.WriteLine();
                            ShowAmountProductsEachColor();
                            break;

                        case 15:
                            Console.Write("\nEnter amount of calories: ");
                            int calories1 = int.Parse(Console.ReadLine());

                            ShowProductsLessCalories(calories1);
                            break;

                        case 16:
                            Console.Write("\nEnter amount of calories: ");
                            int calories2 = int.Parse(Console.ReadLine());

                            ShowProductsGreaterCalories(calories2);
                            break;

                        case 17:
                            Console.Write("\nEnter calories that should be greater: ");
                            int caloriesGreater = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter calories that should be less: ");
                            int caloriesLess = int.Parse(Console.ReadLine());

                            ShowProductsWithDiapasonCalories(caloriesGreater, caloriesLess);
                            break;

                        case 18:
                            Console.WriteLine();
                            ShowProductsWithConcreteColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }
        }

        static int Menu()
        {
            Console.WriteLine("1. Connect");
            Console.WriteLine("2. Disconnect");
            Console.WriteLine("3. Add product");
            Console.WriteLine("4. Delete product");
            Console.WriteLine("5. Show products");
            Console.WriteLine("6. Show all names");
            Console.WriteLine("7. Show all colors");
            Console.WriteLine("8. Show max calories");
            Console.WriteLine("9. Show min calories");
            Console.WriteLine("10. Show avg calories");
            Console.WriteLine("11. Show amount of fruits");
            Console.WriteLine("12. Show amount of vegetables");
            Console.WriteLine("12. Show amount of vegetables");
            Console.WriteLine("13. Show amount of products by color");
            Console.WriteLine("14. Show amount of products each color");
            Console.WriteLine("15. Show products less then calories");
            Console.WriteLine("16. Show products greater then calories");
            Console.WriteLine("17. Show products with diapason of calories");
            Console.WriteLine("18. Show products with concrete color");
            Console.Write("Make your choose: ");
            int choose = int.Parse(Console.ReadLine());

            return choose;
        }

        static List<Good> ReadProducts(SqlDataReader sqlDataReader, List<Good> goods)
        {
            while (sqlDataReader.Read())
            {
                goods.Add(new Good()
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                    Type = sqlDataReader.GetString(2),
                    Color = sqlDataReader.GetString(3),
                    Calories = sqlDataReader.GetInt32(4)
                });
            }

            return goods;
        }

        static void Connect()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Connsection was succesfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connsection was not succesfully.");
                Console.WriteLine(ex.Message);
            }
        }

        static void Disconnsect()
        {
            try
            {
                sqlConnection.Close();
                Console.WriteLine("Disconnection was succesfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Disconnection was not succesfully.");
                Console.WriteLine(ex.Message);
            }
        }

        static void AddProduct()
        {
            Console.Write("Name of product: ");
            string name = Console.ReadLine();

            Console.Write("Type (vegetable or fruit): ");
            string type = Console.ReadLine();

            Console.Write("Color of product: ");
            string color = Console.ReadLine();

            Console.Write("Calories of product: ");
            int calories = int.Parse(Console.ReadLine());

            AddGood(new Good() { Name = name, Type = type, Color = color, Calories = calories });
        }

        static void AddGood(Good good)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Goods(Name, Type, Color, Calories) " +
                "VALUES(@name, @type, @color, @calories)", sqlConnection);

            SqlParameter name = sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            name.Value = good.Name.ToLower();

            SqlParameter type = sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar, 50);
            type.Value = good.Type.ToLower();

            SqlParameter color = sqlCommand.Parameters.Add("@color", SqlDbType.NVarChar, 50);
            color.Value = good.Color.ToLower();

            SqlParameter calories = sqlCommand.Parameters.Add("@calories", SqlDbType.Float);
            calories.Value = good.Calories;

            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Product was succesfully added");
            }
            catch (Exception)
            {
                Console.WriteLine("Product was not added");
            }
        }

        static void ShowGoods()
        {
            List<Good> goods = GetAllGoods();

            foreach (Good good in goods)
            {
                Console.WriteLine($"Name: {good.Name}\n\t " +
                    $"Type: {good.Type}\n\t Color: {good.Color}\n\t Calories: {good.Calories}");
            }
        }

        static List<Good> GetAllGoods()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Goods", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Good> goods = new List<Good>();

            if (!sqlDataReader.HasRows)
            {
                throw new ApplicationException("Not products");
            }

            ReadProducts(sqlDataReader, goods);
            sqlDataReader.Close();
            return goods;
        }

        static void DeleteGood(string name)
        {
            string query = string.Format("DELETE FROM Goods WHERE Name='{0}'", name);

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Product was deleted succesfully.");
            }
            catch (Exception)
            {
                Console.WriteLine("Product was not deleted.");
            }
        }

        static void ShowAllNames()
        {
            List<Good> goods = GetAllGoods();
            uint counter = 1;

            foreach (Good good in goods)
            {
                Console.WriteLine($"{counter}. {good.Name}");
                counter++;
            }
        }

        static void ShowAllColors()
        {
            List<Good> goods = GetAllGoods();
            uint counter = 1;

            foreach (Good good in goods)
            {
                Console.WriteLine($"{counter}. {good.Color}");
                counter++;
            }
        }

        static void ShowMaxCalories()
        {
            List<Good> goods = GetProductsWithMaxCalories();
            uint counter = 1;

            foreach (Good good in goods)
            {
                Console.WriteLine($"{counter}. {good.Calories} calories");
                counter++;
            }
        }

        static List<Good> GetProductsWithMaxCalories()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Goods " +
                "where Calories=(select max(Calories) from Goods)", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Good> goods = new List<Good>();

            if (!sqlDataReader.HasRows)
            {
                throw new ApplicationException("Not products");
            }

            ReadProducts(sqlDataReader, goods);
            sqlDataReader.Close();
            return goods;
        }

        static void ShowMinCalories()
        {
            List<Good> goods = GetProductsWithMinCalories();
            uint counter = 1;

            foreach (Good good in goods)
            {
                Console.WriteLine($"{counter}. {good.Calories} calories");
                counter++;
            }
        }

        static List<Good> GetProductsWithMinCalories()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Goods " +
                "where Calories=(select min(Calories) from Goods)", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Good> goods = new List<Good>();

            if (!sqlDataReader.HasRows)
            {
                throw new ApplicationException("Not products");
            }

            ReadProducts(sqlDataReader, goods);
            sqlDataReader.Close();
            return goods;
        }

        static void ShowAvgCalories()
        {
            int calories = GetAvgCalories();
            Console.WriteLine($"Avarage calories is {calories} calories");
        }

        static int GetAvgCalories()
        {
            SqlCommand sqlCommand = new SqlCommand("select avg(Calories) from Goods", sqlConnection);
            object avg = sqlCommand.ExecuteScalar();

            return (int)avg;
        }

        static void ShowAmountOfFruits()
        {
            int amount = GetAmountOfFruits();
            Console.WriteLine($"Amount of fruits is {amount}");
        }

        static int GetAmountOfFruits()
        {
            SqlCommand sqlCommand = new SqlCommand("select count(*) from Goods where [Type] = 'Fruit'", sqlConnection);
            object amount = sqlCommand.ExecuteScalar();

            return (int)amount;
        }

        static void ShowAmountOfVegetables()
        {
            int amount = GetAmountOfVegetables();
            Console.WriteLine($"Amount of vegetables is {amount}");
        }

        static int GetAmountOfVegetables()
        {
            SqlCommand sqlCommand = new SqlCommand("select count(*) from Goods where [Type] = 'Vegetables'", sqlConnection);
            object amount = sqlCommand.ExecuteScalar();

            return (int)amount;
        }

        static void ShowProductsByColor(string color)
        {
            int amount = GetAmountProductsByColor(color);
            Console.WriteLine($"\nAmount of products with {color} color, is {amount}");
        }

        static int GetAmountProductsByColor(string color)
        {
            string query = string.Format("select count(*) from Goods where Color='{0}'", color);

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            object amount = sqlCommand.ExecuteScalar();

            return (int)amount;
        }

        static void ShowAmountProductsEachColor()
        {
            SortedList<string, int> amountColors = GetAmountProductsEachColor();

            foreach (KeyValuePair<string, int> pair in amountColors)
            {
                Console.WriteLine($"{pair.Key} = {pair.Value}");
            }
        }

        static SortedList<string, int> GetAmountProductsEachColor()
        {
            SqlCommand sqlCommand = new SqlCommand("select Color, count(*) from Goods group by Color", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            SortedList<string, int> amountColors = new SortedList<string, int>();

            while (sqlDataReader.Read())
            {
                amountColors.Add(sqlDataReader.GetString(0).ToLower(), sqlDataReader.GetInt32(1));
            }

            return amountColors;
        }

        static void ShowProductsLessCalories(int calories)
        {
            List<Good> goods = GetProductsLessCalories(calories);

            foreach (Good good in goods)
            {
                Console.WriteLine($"Name: {good.Name}\n\t " +
                    $"Type: {good.Type}\n\t Color: {good.Color}\n\t Calories: {good.Calories}");
            }
        }

        static List<Good> GetProductsLessCalories(int calories)
        {
            string query = string.Format("select * from Goods where Calories < {0}", calories);

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Good> goods = new List<Good>();

            if (!sqlDataReader.HasRows)
            {
                throw new ApplicationException("No products");
            }

            ReadProducts(sqlDataReader, goods);
            sqlDataReader.Close();
            return goods;
        }

        static void ShowProductsGreaterCalories(int calories)
        {
            List<Good> goods = GetProductsGreaterCalories(calories);

            foreach (Good good in goods)
            {
                Console.WriteLine($"Name: {good.Name}\n\t " +
                    $"Type: {good.Type}\n\t Color: {good.Color}\n\t Calories: {good.Calories}");
            }
        }

        static List<Good> GetProductsGreaterCalories(int calories)
        {
            string query = string.Format("select * from Goods where Calories > {0}", calories);

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Good> goods = new List<Good>();

            if (!sqlDataReader.HasRows)
            {
                throw new ApplicationException("No products");
            }

            ReadProducts(sqlDataReader, goods);
            sqlDataReader.Close();
            return goods;
        }

        static void ShowProductsWithDiapasonCalories(int caloriesGreater, int caloriesLess)
        {
            List<Good> goods = GetProductsWithDiapasonCalorie(caloriesGreater, caloriesLess);

            foreach (Good good in goods)
            {
                Console.WriteLine($"Name: {good.Name}\n\t " +
                    $"Type: {good.Type}\n\t Color: {good.Color}\n\t Calories: {good.Calories}");
            }
        }

        static List<Good> GetProductsWithDiapasonCalorie(int caloriesGreater, int caloriesLess)
        {
            string query = string.Format("select * from Goods " +
                "where Calories > {0} and Calories < {1}", caloriesGreater, caloriesLess);

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Good> goods = new List<Good>();

            if (!sqlDataReader.HasRows)
            {
                throw new ApplicationException("No products");
            }

            ReadProducts(sqlDataReader, goods);
            sqlDataReader.Close();
            return goods;
        }

        static void ShowProductsWithConcreteColor()
        {
            List<Good> goods = GetProductsWithConcreteColor();

            foreach (Good good in goods)
            {
                Console.WriteLine($"Name: {good.Name}\n\t " +
                    $"Type: {good.Type}\n\t Color: {good.Color}\n\t Calories: {good.Calories}");
            }
        }

        static List<Good> GetProductsWithConcreteColor()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Goods where Color='red' or Color='yellow'", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Good> goods = new List<Good>();

            if (!sqlDataReader.HasRows)
            {
                throw new ApplicationException("No products");
            }

            ReadProducts(sqlDataReader, goods);
            sqlDataReader.Close();
            return goods;
        }
    }
}

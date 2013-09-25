using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ConsoleApplication3
{
    public class Program
    {
        private static char[] letters = new char[52];

        static DateTime dtGenerator = new DateTime(1999, 1, 1);

		static SqlConnection conn = new SqlConnection(
			@"Server=.;Database=PerformanceDb;Integrated security = true;");
			
		
        //static MySqlConnection conn = new MySqlConnection(
        //        @"Server=localhost;Database=PerformanceDb;Uid=user;Pwd=pass;");

        static void Main()
        {


            conn.Open();
            for (int i = 0; i < 52; i++)
            {
                letters[i] = i < ('Z' - 'A') + 1 ? (char)('a' + i) : (char)('A' + i - ('Z' - 'A' + 1));
            }

            InsertPermutations(new int[4], 0);
        }

        private static void InsertPermutations(int[] indices, int index)
        {
            if (index >= indices.Length)
            {
                string str = "";
                for (int i = 0; i < indices.Length; i++)
                {
                    str += letters[indices[i]];
                }
				SqlCommand command =  new SqlCommand(
                //MySqlCommand command = new MySqlCommand(
                    @"INSERT INTO Posts(PostText, PostDate)
                    VALUES (@text, @date)", conn);

                command.Parameters.AddWithValue("@text", str);
                command.Parameters.AddWithValue("@date", dtGenerator);

                command.ExecuteNonQuery();

                dtGenerator = dtGenerator.AddMinutes(1);
                return;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                indices[index] = i;
                InsertPermutations(indices, index + 1);
            }
        }
    }
}

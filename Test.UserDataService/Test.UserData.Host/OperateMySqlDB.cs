using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Test.UserData.Host
{
    public class OperateMySqlDB
    {
        public static void Main(string[] args)
        {
            new OperateMySqlDB().OperateUserDb();
        }
        public void OperateUserDb()
        {
            String connetStr = "server=127.0.0.1;port=3306;user=root;password=root; database=airticket;";
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                            //string sql = "select * from user where username='"+username+"' and password='"+password+"'"; //我们自己按照查询条件去组拼
                string sql = "select * from UserData";//在sql语句中定义parameter，然后再给parameter赋值
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MUser mUser = new MUser();
                //cmd.Parameters.AddWithValue("para1", username);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())//如果用户名和密码正确则能查询到一条语句，即读取下一行返回true
                {
                    Console.WriteLine(reader.GetString("KeyID"));//"userid"是数据
                }
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
   


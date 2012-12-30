using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using EpamAspProject.DataAccessor;
using EpamAspProject.Types;
using System;

namespace EpamAspProject.Model
{
    public class Users
    {
        private static Random _random = new Random();

        private static string Hash(string s)
        {
            var password = new StringBuilder();

            //перевожу строку в байт массив
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаю обьект для получения средств шифрования
            var cs5 = new MD5CryptoServiceProvider();

            //вычисляем хэш представление в байтах
            byte[] hachByte = cs5.ComputeHash(bytes);

            foreach (byte b in hachByte)
            {
                password.Append(string.Format("{0:x2}", b));
            }
            return password.ToString();
        }

        public static bool IsCorrectLogin(User user)
        {
            RichUser baseLogin;
            try
            {
                baseLogin = UserAccess.GetUserByLogin(user.Login);
            }
            catch(InvalidCastException)
            {
                return false;
            }
            if (baseLogin != null)
            {
                return Hash(user.Password) == baseLogin.Password;
            }
            return false;
        }

        public static bool IsAdminUser(User user)
        {
            RichUser baseLogin;
            try
            {
                baseLogin = UserAccess.GetUserByLogin(user.Login);
            }
            catch (InvalidCastException)
            {
                return false;
            }
            if (baseLogin != null)
            {
                return baseLogin.IsAdmin;
            }
            return false;
        }

        public static bool AddNewUser(RichUser newLogin)
        {
            var addLogin = newLogin.Clone();
            addLogin.Password = Hash(newLogin.Password);
            return UserAccess.AddNewUser(addLogin);
        }

        public static bool IsExistEmail(string eMail)
        {
            var baseLogin = UserAccess.GetUserByEMail(eMail);
            return baseLogin != null;
        }

        public static bool IsExistLogin(string login)
        {
            var baseLogin = UserAccess.GetUserByLogin(login);
            return baseLogin != null;
        }

        public static int GenerateSecretKey()
        {
            return _random.Next(10000, 99999);
        }

        public static string GenerateNewPass()
        {
            var newPass = new StringBuilder();
            var n = _random.Next(1, 26);
            switch(n)
            {
                case 1:
                    newPass.Append("Q"); break;
                case 2:
                    newPass.Append("W"); break;
                case 3:
                    newPass.Append("E"); break;
                case 4:
                    newPass.Append("R"); break;
                case 5:
                    newPass.Append("T"); break;
                case 6:
                    newPass.Append("Y"); break;
                case 7:
                    newPass.Append("U"); break;
                case 8:
                    newPass.Append("I"); break;
                case 9:
                    newPass.Append("O"); break;
                case 10:
                    newPass.Append("P"); break;
                case 11:
                    newPass.Append("A"); break;
                case 12:
                    newPass.Append("S"); break;
                case 13:
                    newPass.Append("D"); break;
                case 14:
                    newPass.Append("F"); break;
                case 15:
                    newPass.Append("G"); break;
                case 16:
                    newPass.Append("H"); break;
                case 17:
                    newPass.Append("J"); break;
                case 18:
                    newPass.Append("K"); break;
                case 19:
                    newPass.Append("L"); break;
                case 20:
                    newPass.Append("Z"); break;
                case 21:
                    newPass.Append("X"); break;
                case 22:
                    newPass.Append("C"); break;
                case 23:
                    newPass.Append("V"); break;
                case 24:
                    newPass.Append("B"); break;
                case 25:
                    newPass.Append("N"); break;
                case 26:
                    newPass.Append("M"); break;
            }
            for (int i = 0; i < 6; ++i)
            {
                n = _random.Next(1, 26);
                switch (n)
                {
                    case 1:
                        newPass.Append("q");
                        break;
                    case 2:
                        newPass.Append("w");
                        break;
                    case 3:
                        newPass.Append("e");
                        break;
                    case 4:
                        newPass.Append("r");
                        break;
                    case 5:
                        newPass.Append("t");
                        break;
                    case 6:
                        newPass.Append("y");
                        break;
                    case 7:
                        newPass.Append("u");
                        break;
                    case 8:
                        newPass.Append("i");
                        break;
                    case 9:
                        newPass.Append("o");
                        break;
                    case 10:
                        newPass.Append("p");
                        break;
                    case 11:
                        newPass.Append("a");
                        break;
                    case 12:
                        newPass.Append("s");
                        break;
                    case 13:
                        newPass.Append("d");
                        break;
                    case 14:
                        newPass.Append("f");
                        break;
                    case 15:
                        newPass.Append("g");
                        break;
                    case 16:
                        newPass.Append("h");
                        break;
                    case 17:
                        newPass.Append("j");
                        break;
                    case 18:
                        newPass.Append("k");
                        break;
                    case 19:
                        newPass.Append("l");
                        break;
                    case 20:
                        newPass.Append("z");
                        break;
                    case 21:
                        newPass.Append("x");
                        break;
                    case 22:
                        newPass.Append("c");
                        break;
                    case 23:
                        newPass.Append("v");
                        break;
                    case 24:
                        newPass.Append("b");
                        break;
                    case 25:
                        newPass.Append("n");
                        break;
                    case 26:
                        newPass.Append("m");
                        break;
                }
            }
            n = _random.Next(0, 9);
            newPass.Append(n.ToString(CultureInfo.InvariantCulture));
            return newPass.ToString();
        }

        public static bool ChangePassTo(User oldUser)
        {
            var changeUser = oldUser.Clone();
            changeUser.Password = Hash(oldUser.Password);
            return UserAccess.ChangePassTo(changeUser);
        }

        public static RichUser GetLoginByEmail(string eMail)
        {
            return UserAccess.GetUserByEMail(eMail);
        }

        public static int GetIDUser(User login)
        {
            return UserAccess.GetIDByLogin(login.Login);
        }

        public static RichUser GetUserById(int id)
        {
            return  UserAccess.GetUserById(id);
        }
    }
}
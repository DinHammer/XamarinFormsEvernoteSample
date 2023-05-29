using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinEvernote.Constants
{
    public class ConstStrings : Evernote.Abstractions.Constants.ConstText
    {

        public class KeyMoq
        {
            public const string strPhone = "+79261234567";
            public const string strPassoword = "test123";
        }

        public class KeySecureStorage
        {
            public const string str_set_data = nameof(str_set_data);
            public const string str_get_data = nameof(str_get_data);

            public const string str_token_access = nameof(str_token_access);
            public const string str_token_refresh = nameof(str_token_refresh);            
        }

    }

    public class PgLogin
    {
        public const string header = "Введите номер телефона";
        public const string entrPlaceholderInputLogin = "Введите логин";
        public const string entrPlaceholderPassword = "*********";
        public const string lblEntryHeaderInputLogin = "Телефон";
        public const string lblEntryHeaderPassword = "Пароль";
        public const string lblForgotPassword = "Забыли пароль";
        public const string lblInputByPhone = "Войти по телефону";
        public const string btnInput = "Войти";
    }

    public class PgSettings
    {        
        public const string btnLogOut = "Войти из аккаунта";
    }

    public class TabBarNames
    {
        public const string notes = "Заметки";
        public const string settings = "Настройки";        
    }
}

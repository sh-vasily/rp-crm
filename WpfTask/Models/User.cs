namespace WpfTask.Models
{
    class User
    {
        #region Private fields

        private int id;
        private string name;
        private string login;
        private string password;

        #endregion

        #region Constructor

        public User(int _id, string _name, string _login, string _password)
        {
            Id = _id;
            Name = _name;
            Login = _login;
            Password = _password;
        }

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Login
        {
            get => login;
            set => login = value;
        }
        public string Password
        {
            get => password;
            set => password = value;
        }
        #endregion

    }
}

namespace WpfTask.Models
{
    class Company
    {
        #region Private fields

        private int id;
        private string name;
        private string contructStatus;

        #endregion

        #region Constructor

        public Company(int _id, string _name, string _contructStatus)
        {
            Id = _id;
            Name = _name;
            ContructStatus = _contructStatus;
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
        public string ContructStatus
        {
            get => contructStatus;
            set => contructStatus = value;
        }
        #endregion
    }
}

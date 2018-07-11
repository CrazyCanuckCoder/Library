using System;
using System.Windows.Input;

namespace Library.WPF
{
    /// <summary>
    /// An ICommand class suitable for use in MVVM based applications.
    /// </summary>
    /// 
    /// <remarks>
    /// This version of the Command object is designed to be flexible and for use in MVVM or a
    /// similar design pattern based applications.
    /// 
    /// The original idea came from the book Pro WPF and Silverlight MVVM by Gary McLean Hall.
    /// 
    /// Example usage:
    /// 
    /// public class LogInViewModel
    /// {
    ///     public LogInViewModel()
    ///     {
    ///         _logInModel = new LogInModel();
    ///         _logInCommand = new RelayCommand(param => this.AttemptLogIn(), param => this.CanAttemptLogIn());
    ///     }
    /// 
    ///     private RelayCommand _logInCommand;
    ///     private LogInModel _logInModel;
    /// 
    ///     public string UserName { get; set; }
    /// 
    ///     public string Password { get; set; }
    /// 
    ///     public ICommand LogInCommand
    ///     {
    ///         get
    ///         {
    ///             return _logInCommand;
    ///         }
    ///     }
    /// 
    ///     private void AttemptLogIn()
    ///     {
    ///         _logInModel.LogIn(UserName, Password);
    ///     }
    /// 
    ///     private bool CanAttemptLogIn()
    ///     {
    ///         return !String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(Password);
    ///     }
    /// }
    ///
    /// </remarks>
    /// 
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Initializes the RelayCommand with an Execute method.
        /// </summary>
        /// 
        /// <param name="Execute">
        /// The method to use for the Execute method of the class.
        /// </param>
        /// 
        public RelayCommand(Action<object> Execute) : this(Execute, null)
        {
        }

        /// <summary>
        /// Initializes the RelayCommand with Execute and CanExecute methods.
        /// </summary>
        /// 
        /// <param name="Execute">
        /// The method to use for the Execute method of the class.
        /// </param>
        /// 
        /// <param name="CanExecute">
        /// The method to use for the CanExecute method of the class.
        /// </param>
        /// 
        public RelayCommand(Action<object> Execute, Predicate<object> CanExecute)
        {
            if (Execute == null)
            {
                throw new ArgumentNullException("Execute");
            }
            this._execute    = Execute;
            this._canExecute = CanExecute;
        }


        /// <summary>
        /// A reference to the method that executes the command.
        /// </summary>
        /// 
        private readonly Action<object> _execute;

        /// <summary>
        /// A reference to the method that indicates whether to command can be executed.
        /// </summary>
        /// 
        private readonly Predicate<object> _canExecute;


        /// <summary>
        /// Fires to indicate the CanExecute condition should be checked.
        /// </summary>
        ///
        /// <remarks>
        /// Automatically handled by the CommandManager object.
        /// </remarks> 
        ///
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Verifies that the conditions are met so the Execute method will function properly.
        /// </summary>
        /// 
        /// <param name="Parameter">
        /// Any object the CanExecute command needs to determine the ability to run the Execute method.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate the Execute method can be run and false if not.
        /// </returns>
        /// 
        public bool CanExecute(object Parameter)
        {
            return this._canExecute == null ? true : this._canExecute(Parameter);
        }

        /// <summary>
        /// Runs the command associated with this class.
        /// </summary>
        /// 
        /// <param name="Parameter">
        /// Any object that is needed as a parameter for the command.
        /// </param>
        /// 
        public void Execute(object Parameter)
        {
            this._execute(Parameter);
        }
    }
}

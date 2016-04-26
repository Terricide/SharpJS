using System;

namespace ExaPhaser.WebForms
{
	/// <summary>
	/// A command that takes a parameter
	/// </summary>
	public class ParameterizedCommand : ICommand
	{
		#region Private Fields

		private readonly Action<ICommandParameter> _executeAction;

		#endregion Private Fields

		#region Public Constructors

		public ParameterizedCommand(Action<ICommandParameter> executeAction)
		{
			_executeAction = executeAction;
		}

		#endregion Public Constructors

		#region Public Methods

		public void Execute(ICommandParameter parameter)
		{
			_executeAction?.Invoke(parameter);
		}

		#endregion Public Methods
	}
}
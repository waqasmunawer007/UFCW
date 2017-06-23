// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace UFCW.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
	    private static ISettings AppSettings
	    {
	      get
	      {
	        return CrossSettings.Current;
	      }
	    }

	    #region Setting Constants

	    private const string SettingsKey = "settings_key";
		private const string SSNKey = "ssn_key";
		private const string TokenKey = "token_key";
		private const string EmailKey = "email_key";

	    private static readonly string SettingsDefault = string.Empty;
		private static readonly string SSNDefault = string.Empty;
		private static readonly string TokenDefault = "0000";
		private static readonly string EmailDefault = string.Empty;

	    #endregion


	    public static string GeneralSettings
	    {
	      get
	      {
	        return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
	      }
	      set
	      {
	        AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
	      }
	    }

		/// <summary>
		/// Gets or sets the user email.
		/// </summary>
		/// <value>The user email.</value>
		public static string UserEmail
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(EmailKey, EmailDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(EmailKey, value);
			}
		}

		/// <summary>
		/// Gets or sets the user token.
		/// </summary>
		/// <value>The user token.</value>
		public static string UserToken
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(TokenKey, TokenDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(TokenKey, value);
			}
		}

		/// <summary>
		/// Gets or sets the user unique ssn number.
		/// </summary>
		/// <value>The user ssn.</value>
		public static string UserSSN
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(SSNKey, SSNDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(SSNKey, value);
			}
		}

  }
}
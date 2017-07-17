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
		private const string PensionEnrolledKey = "pension_enrolled_key";
		private const string InsuranceEnrolledKey = "insurance_enrolled_key";
		private const string RetireeOrActiveKey = "retiree_or_ctive_key";

	    private static readonly string SettingsDefault = string.Empty;
		private static readonly string SSNDefault = string.Empty;
		private static readonly string TokenDefault = "0000";
		private static readonly string EmailDefault = string.Empty;

		private static readonly bool BoolDefault = false;
		private static readonly string StringDefault = string.Empty;

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
		/// Gets or sets the Pension Enrolled Status
		/// </summary>
		/// <value>The Pension Enrolled.</value>
		public static bool PensionEnrolled
		{
			get
			{
				return AppSettings.GetValueOrDefault<bool>(PensionEnrolledKey, BoolDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<bool>(PensionEnrolledKey, value);
			}
		}

		/// <summary>
		/// Gets or sets the Insurance Enrolled Status
		/// </summary>
		/// <value>The Insurance Enrolled.</value>
		public static bool InsuranceEnrolled
		{
			get
			{
				return AppSettings.GetValueOrDefault<bool>(InsuranceEnrolledKey, BoolDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<bool>(InsuranceEnrolledKey, value);
			}
		}

		/// <summary>
		/// Gets or sets the Retiree Or Active Status
		/// </summary>
		/// <value>The Retiree Or Active.</value>
		public static string RetireeOrActive
		{
			get
			{
                return AppSettings.GetValueOrDefault<string>(RetireeOrActiveKey, StringDefault);
			}
			set
			{
                AppSettings.AddOrUpdateValue<string>(RetireeOrActiveKey, value);
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
﻿namespace BuckarooSdk.Services.P24.TransactionRequest
{
	/// <summary>
	/// The Pay action is used to perform a single P24 payment. Important note: a P24 payment can only be done in Polish zloty. 
	/// Therefore, make sure to provide value "PLN" as the currency in the request.
	/// </summary>
	public class P24PayRequest
	{
		public string CustomerEmail { get; set; }
		public string CustomerFirstName { get; set; }
		public string CustomerLastName { get; set; }

	}
}
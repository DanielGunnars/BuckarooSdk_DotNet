﻿using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.CreditCards.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Nexi
{
	[TestClass]
	public class NexiTests
	{
		private SdkClient _sdkClient;
		private string TestName => nameof(NexiTests).ToUpper();

		[TestInitialize]
		public void Setup()
		{
			this._sdkClient = new SdkClient(Constants.TestSettings.Logger);
		}

		[TestMethod]
		public void PayTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					Description = $"{ TestName }_SDK_UNITTEST",
				})
				.Nexi()
				.Pay(new CreditCardPayRequest()
				{
					//set properties
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void RefundTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountCredit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					OriginalTransactionKey = "59915ADC227149F4A3ACE9E0C8589D3C",
					Description = $"{ TestName }_SDK_UNITTEST",
				})
				.Nexi()
				.Refund(new CreditCardRefundRequest()
				{
					//set properties
				});
			var response = request.Execute();
		}

		[TestMethod]
		public void AuthorizeTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					Description = $"{ TestName }_SDK_UNITTEST",

				})
				.Nexi()
				.Authorize(new CreditCardAuthorizeRequest()
				{
					//set properties
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void CaptureTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Nexi()
				.Capture(new CreditCardCaptureRequest()
				{
					//set properties
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void PayRecurrentTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Nexi()
				.PayRecurrent(new CreditCardPayRecurrentRequest()
				{
					//define properties
				});
			var response = request.Execute();
		}

		[TestMethod]
		public void PayRemainderTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Nexi()
				.PayRemainder(new CreditCardPayRemainderRequest()
				{
					//define properties
				});

			var response = request.Execute();
		}
	}
}

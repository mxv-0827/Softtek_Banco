using ÄPI.DTOs;
using ÄPI.Entities;
using ÄPI.Infrastructure.CustomExceptions;
using ÄPI.Services;
using ÄPI.Services.APIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ÄPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public CurrencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("GetCurrencies")]
        public async Task<IActionResult> GetCurrencies(string accountType)
        {
            try
            {
                int accountTypeID = await _unitOfWork.AccountTypeRepo.GetID(accountType); //Gets ID of the accountType
                List<AccountType_Currency> fullAvailableCurrencies = await _unitOfWork.AccountTypeCurrencyRepo.GetAvailableCurrencies(accountTypeID); //Gets the full register.

                List<string> currenciesAvailable = new List<string>();

                foreach (AccountType_Currency accountTypeCurrency in fullAvailableCurrencies)
                {
                    currenciesAvailable.Add(await _unitOfWork.CurrencyRepo.GetCurrency(accountTypeCurrency.CurrencyID)); //Gets the name of the currency based on its ID. Adds it to the list.
                }

                return ResponseFactory.CreateSuccessResponse(202, currenciesAvailable);
            }

            catch (Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(404, ex.Message);
            }
        }


        [HttpGet("GetConvertionValue")]
        public async Task<IActionResult> GetConvertionValue([FromQuery] ConvertionValueDTO convertionValue)
        {
            try
            {
                if (!ModelState.IsValid) { }

                return ResponseFactory.CreateSuccessResponse(202, await CurrencyConvertionAPI.GetCurrencyConvertion(convertionValue.From_Currency, convertionValue.To_Currency, convertionValue.Amount));
            }

            catch(Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(404, ex.Message);
            }
        }
    }
}

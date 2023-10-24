using ÄPI.Entities;
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
        public async Task<ActionResult<IEnumerable<string>>> GetCurrencies(string accountType)
        {
            try
            {
                int accountTypeID = await _unitOfWork.AccountTypeRepo.GetID(accountType); //Gets ID of the accountType
                List<AccountType_Currency> fullAvailableCurrencies = await _unitOfWork.AccountTypeCurrencyRepo.GetAvailableCurrencies(accountTypeID); //Gets the full .

                List<string> currenciesAvailable = new List<string>();

                foreach (AccountType_Currency accountTypeCurrency in fullAvailableCurrencies)
                {
                    currenciesAvailable.Add(await _unitOfWork.CurrencyRepo.GetCurrency(accountTypeCurrency.CurrencyID)); //Gets the name of the currency based on its ID. Adds it to the list.
                }

                return Ok(currenciesAvailable);
            }

            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetConvertionValue")]
        public async Task<ActionResult> GetConvertionValue(string fromCurrency, string toCurrency, int amount)
        {
            try
            {
                return Ok(await CurrencyConvertionAPI.GetCurrencyConvertion(fromCurrency, toCurrency, amount));
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

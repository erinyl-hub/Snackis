using Microsoft.AspNetCore.Mvc;

namespace CodeAlongKassabok.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        // Hämtar alla transaktioner
        [HttpGet]
        public List<Models.Transaction> GetAllTransactions()
        {
            if(DAL.TransactionManager.GetTransactions().Count == 0)
            {
                DAL.TransactionManager.CreateTransaction(new Models.Transaction() { Title = "Lön", Amount = 32000, Date = DateTime.Now});
            }
            return DAL.TransactionManager.GetTransactions();
        }

        // Hämta en utvald transaktion "api/Transaction/123"

        [HttpGet("{id}")]
        public Models.Transaction GetTransaction(int id)
        {
            return DAL.TransactionManager.GetTransaction(id);
        }

        [HttpPost]
        public void PostTransaction([FromBody]Models.Transaction transaction)
        {
            DAL.TransactionManager.CreateTransaction(transaction);
        }

            

    }
}

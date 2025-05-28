namespace CodeAlongKassabok.DAL
{
    public static class TransactionManager
    {
        //Vår "databas"
        private static List<Models.Transaction> Transactions { get; set; } = new List<Models.Transaction>();


        public static List<Models.Transaction> GetTransactions() 
        { return Transactions; }

        public static Models.Transaction GetTransaction(int id)
        {
            return Transactions.Where(t => t.Id == id).SingleOrDefault();
        }


        public static void CreateTransaction(Models.Transaction transaction)
        {
            transaction.Id = Random.Shared.Next(1, 1000);
            Transactions.Add(transaction);
        }




    }
}

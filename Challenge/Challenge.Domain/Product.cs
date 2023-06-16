namespace Challenge.Domain
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ApplicationException("Product name can not be empty");
            }

            if(Price == 0)
            {
                throw new ApplicationException("Produc price can not be empty");
            }
        }
    }
}

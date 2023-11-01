namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        public void AddItem(Product product, int quantity)
        {
            CartLine? Line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();
            if (Line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                Line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductId.Equals(product.ProductId));
        public void ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);
        public void Clear()=>Lines.Clear();

    }
}








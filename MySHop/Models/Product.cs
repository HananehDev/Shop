namespace MySHop.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation property
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public Item item { get; set; }
    }
}

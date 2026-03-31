namespace AppCarrinho
{
    public class Item
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
    }

    public class Carrinho
    {
        public List<Item> itens = new(); 
        /* Se voce utilizar o Assert.Empty() com esse atributo no private ele vai dar 
        erro porque a classe do teste ele não conseguira ver esse atributo collection la 
        agora se deixar no public, ele sim conseguirá ver esse atributo la na classe teste.
        */
        public void Adicionar(Item item)
        {
            itens.Add(item);
        }

        public double Total()
        {
            return itens.Sum(i => i.Preco);
        }

        public int Quantidade()
        {
            return itens.Count;
        }
        public void Limpar()
        {
            itens.Clear();
        }
    }
}
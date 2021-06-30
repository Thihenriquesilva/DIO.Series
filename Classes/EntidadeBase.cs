namespace DIO.Series
{
    //Classe abstrata, sera usada por todas as classes dentro desta aplicação
    public abstract class EntidadeBase
    {
        //ID que todas as classes irão ter
        public int Id { get; protected set; }
    }
}
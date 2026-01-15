namespace Classes.ThisReference;

public class Panda
{
    public Panda Mate;

    public void Marry(Panda partner)
    {
        Mate = partner;
        partner.Mate = this;
    }
}

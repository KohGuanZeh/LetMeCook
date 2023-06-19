public class RecyclingAction : Action
{
    public override void GoodOutcome()
    {
        // Something Good
        print("Correct Bin");
    }

    // Update is called once per frame
    public override void BadOutcome()
    {
       // Something Bad 
       print("Wrong Bin brO");
    }
}

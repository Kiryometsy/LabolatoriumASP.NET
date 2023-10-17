using Labolatorium2.Controllers;
public class BirthModel
{
    public string name {  get; set; }
    public DateTime dateOfBirth { get; set; }

    public bool IsValid()
    {
        return name != null && dateOfBirth <= DateTime.Now;
    }
    public double Age()
    {
        var today = DateTime.Today;

        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (a - b) / 10000;
    }
}

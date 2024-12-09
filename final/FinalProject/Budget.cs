using System.Diagnostics.CodeAnalysis;

public class Budget
{
    private string _name;
    private string _description;
    private List<Expense> _expenses;
    private List<Income> _incomes;
    private List<Investment> _investments;
    private DateTime _startDate;
    private DateTime _endDate;


    // Constructor
    public Budget(string name, string description)
    {
        _name = name;
        _description = description;
        _startDate = DateTime.Now;
        _endDate = _startDate.AddYears(1);
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public List<Expense> GetExpenses()
    {
        return _expenses;
    }

    public List<Income> GetIncomes()
    {
        return _incomes;
    }

    public List<Investment> GetInvestments()
    {
        return _investments;
    }

    public DateTime GetStartDate()
    {
        return _startDate;
    }

    public DateTime GetEndDate()
    {
        return _endDate;
    }

    public string GetDisplay()
    {
        return "Displaying Budget";
    }

    // Setter Methods
    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
    }

    public void AddIncome(Income income)
    {
        _incomes.Add(income);
    }

    public void AddInvestment(Investment investment)
    {
        _investments.Add(investment);
    }

    public void SetStartDate(DateTime date)
    {
        _startDate = date;
    }

    public void SetEndDate(DateTime date)
    {
        _endDate = date;
    }

}
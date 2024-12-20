using System.Diagnostics.CodeAnalysis;

public class Budget
{
    private string _name;
    private string _description;
    public List<Expense> _expenses;
    public  List<Income> _incomes;
    public List<Investment> _investments;
    private DateTime _startDate;
    private DateTime _endDate;


    // Constructor
    public Budget(string name, string description)
    {
        _name = name;
        _description = description;
        _startDate = DateTime.Now;
        _endDate = _startDate.AddYears(1);
        _expenses = [];
        _incomes = [];
        _investments = [];
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

    public float GetTotalExpenses()
    {
        float total = 0;
        foreach(Expense exp in _expenses)
        {
            total += exp.GetValue();
        }

        foreach(Investment inv in _investments)
        {
            total += inv.GetValue();
        }
        return total;
    }

    public float GetTotalIncome()
    {
        float total = 0;
        foreach(Income inv in _incomes)
        {
            total += inv.GetValue();
        }
        return total;
    }
    
    // Serializer
    public string Serialize()
    {
        return $"Budget,{_name},{_description},{_startDate.ToString()},{_endDate.ToString()}";
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
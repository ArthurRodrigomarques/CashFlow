using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("O titulo é obrigatório");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("O valor deve ser maior que zero");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("O horário está errado");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("O pagamento não é válido");
    }
}

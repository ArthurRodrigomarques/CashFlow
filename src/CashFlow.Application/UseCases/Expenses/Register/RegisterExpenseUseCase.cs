﻿using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        // TO DO VALIDATIONS
        Validate(request);

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        //var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        //if (titleIsEmpty) 
        //{
        //    throw new ArgumentException();
        //}

        //if(request.Amount <= 0)
        //{
        //    throw new ArgumentException();
        //}

        //var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        //if(result > 0)
        //{
        //    throw new ArgumentException();
        //}

        //var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        //if (paymentTypeIsValid == false) 
        //{
        //    throw new ArgumentException();
        //}

        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

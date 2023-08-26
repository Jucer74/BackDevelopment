using System;
using System.Collections.Generic;

static class Bank
{
    private static List<IBankAccount> accountList = new List<IBankAccount>();

    public static void CreateAccount(IBankAccount bankAccount)
    {
        // Implementación para crear cuentas
    }

    public static void GetBalanceAccount(string accountNumber)
    {
        // Implementación para obtener saldo de cuentas
    }

    public static void DepositAmount(string accountNumber, decimal amountValue)
    {
        // Implementación para depositar en cuentas
    }

    public static void WithdrawalAmount(string accountNumber, decimal amountValue)
    {
        // Implementación para retirar de cuentas
    }
}
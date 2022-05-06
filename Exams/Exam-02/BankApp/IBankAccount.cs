using System;
namespace BankApp
{
interface IBankAccount
{
void Deposit(double amounttoDeposit);

void Withdraw(double amounttoWithdraw);

double CheckBalance();
}
}
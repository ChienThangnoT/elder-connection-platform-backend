﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TransactionHistory
{
    public int TransactionId { get; set; }

    public string? AccountId { get; set; }

    public string? AccountName { get; set; }

    public float TransactionAmount { get; set; }

    public float WalletBalanceChange { get; set; }
    public float CurrentWallet { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TransactionNo { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? CurrencyCode { get; set; }

    public int Status { get; set; }

    public string? TransactionType { get; set; }

    public virtual Account? Account { get; set; }
}

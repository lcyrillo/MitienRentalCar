﻿namespace Mitien.RentalCar.Business.RequestModels;

public class UserTypeRequestModel
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Mnemonic { get; set; } = string.Empty;
}


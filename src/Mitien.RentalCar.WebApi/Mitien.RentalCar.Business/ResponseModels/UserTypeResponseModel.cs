﻿namespace Mitien.RentalCar.Business.ResponseModels;

public class UserTypeResponseModel
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Mnemonic { get; set; } = string.Empty;
}

